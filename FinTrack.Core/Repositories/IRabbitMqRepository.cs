using System;
namespace FinTrack.Core.repositories
{
    public interface IRabbitMqRepository
    {
        // Publica uma mensagem na fila
        void Publish<T>(string queue, T message);

        // Consome mensagens assincronamente de uma fila
        void Consume<T>(string queue,Func<T, Task> onMessage);
    }
}
