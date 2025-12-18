using FinTrack.Application.Models;
using MediatR;

namespace FinTrack.Application.Services.Commands.WhatsAppCommands.WhatsAppSendMessage
{
    public class SendMessageCommand : IRequest<ResultViewModel<string>>
    {
        public SendMessageCommand(string phoneNumberId, string recipient, string message, string accessToken)
        {
            this.phoneNumberId = phoneNumberId;
            this.recipient = recipient;
            this.message = message;
            this.accessToken = accessToken;
        }

        public string accessToken { get; set; }
        public string phoneNumberId { get; set; }
        public string recipient { get; set; }
        public string message { get; set; }
    }
}
