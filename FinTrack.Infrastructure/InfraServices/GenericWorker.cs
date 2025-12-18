using FinTrack.Core.repositories;
using Microsoft.Extensions.Hosting;

namespace FinTrack.Infrastructure.InfraServices
{
    public class GenericWorker<TPayload> : BackgroundService
    {
        private readonly IRabbitMqRepository _rabbitMqRepository;
        private readonly string _queueName;
        private readonly Func<TPayload, Task> _processMessage;

        public GenericWorker(IRabbitMqRepository rabbitMqRepository, string queueName, Func<TPayload, Task> processMessage)
        {
            _rabbitMqRepository = rabbitMqRepository;
            
            _queueName = queueName;
            _processMessage = processMessage;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _rabbitMqRepository.Consume<TPayload>(_queueName, async payload =>
            {
                try
                {
                    await _processMessage(payload);
                }
                catch (Exception ex)
                {

                }
            });

            return Task.CompletedTask;
        }

    }
}
