using FinTrack.Core.repositories;
using FinTrack.Core.WhatsappModels;

namespace FinTrack.Application.Services.Whatsapp
{
    public class WhatsappService
    {
        private readonly IRabbitMqRepository _rabbitMqRepository;

        public WhatsappService(IRabbitMqRepository rabbitMqRepository)
        {
            _rabbitMqRepository = rabbitMqRepository;
        }

        public WhatsappIntent Resolve(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return WhatsappIntent.Unknown;

            message = message.ToUpperInvariant();

            if (message.Contains("CUSTO"))
                return WhatsappIntent.AddCost;

            if (message.Contains("RECEBIMENTO") || message.Contains("ENTRADA"))
                return WhatsappIntent.AddReceive;

            if (message.Contains("BALANÇO") || message.Contains("SALDO"))
                return WhatsappIntent.MonthlyBalance;

            return WhatsappIntent.Unknown;
        }

        public void RedirectToQueue(WhatsappPayload payload)
        {
            /*
             case var message when message.Contains("create-cost", StringComparison.OrdinalIgnoreCase):
                _rabbitMqRepository.Publish("create-cost", message);
                break;

            case var message when message.Contains("create-receive", StringComparison.OrdinalIgnoreCase):
                _rabbitMqRepository.Publish("create-receive", message);
                break;

            case var message when message.Contains("consult-balance", StringComparison.OrdinalIgnoreCase):
                _rabbitMqRepository.Publish("consult-balance", message);
                break;
            
            default:
                throw new InvalidOperationException("Tipo de mensagem não suportado.");
            }*/
        }

    }
}
