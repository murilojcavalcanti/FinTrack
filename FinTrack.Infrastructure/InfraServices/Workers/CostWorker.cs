using FinTrack.Core.Entities;
using FinTrack.Core.repositories;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FinTrack.Application.Services.Commands.CostCommands.CreateCost;

namespace FinTrack.Infrastructure.InfraServices.Workers
{
    public class CostWorker { /*: BackgroundService
    {
        private readonly IRabbitMqRepository _rabbitMqRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CostWorker> _logger;

        public CostWorker(IRabbitMqRepository rabbitMqRepository, IMediator mediator, ILogger<CostWorker> logger)
        {
            _rabbitMqRepository = rabbitMqRepository;
            _mediator = mediator;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _rabbitMqRepository.Consume<Cost>("create-cost", async cost =>
            {
                try
                {

                    // Cria o comando para o CQRS
                    var command = new CreateCostCommand(
                    );

                    // Envia o comando para o handler via MediatR
                    await _mediator.Send(command, stoppingToken);

                    _logger.LogInformation("Cost criado via worker: {Name}", cost.Name);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar Cost no worker");
                }
            });

            return Task.CompletedTask;
        }
    }*/
        }
}
