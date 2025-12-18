using FinTrack.Core.repositories;
using FinTrack.Core.WhatsappModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace FinTrack.Infrastructure.InfraServices.Repositories
{
    public class RabbitMqRepository : IRabbitMqRepository, IDisposable
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMqRepository(string hostname, string username, string password)
        {
            _hostname = hostname;
            _username = username;
            _password = password;
            CreateConnection();
        }

        private void CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();
        }

        public void Publish<T>(string queueName, T message)
        {
            using var channel = _connection.CreateModel();
            
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        public void Consume<T>(string queueName, Func<T, Task> onMessageReceived)
        {
            var channel = _connection.CreateModel();
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));
                await onMessageReceived(message!);
                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
