using FinTrack.Application.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinTrack.Application.Services.Commands.WhatsAppCommands.WhatsAppSendMessage
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand, ResultViewModel<string>>
    {
        private readonly IConfiguration _configuration;

        public SendMessageHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultViewModel<string>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var url = $"https://graph.facebook.com/v19.0/{request.phoneNumberId}/messages";
            var accessToken = _configuration["WhatsApp:AccessToken"];
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", request.accessToken);
            var payload = new
            {
                messaging_product = "whatsapp",
                to = request.recipient,
                type = "text",
                text = new { body = request.message }
            };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content, cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync();
            return ResultViewModel<string>.Success(responseBody);
        }
    }
}
