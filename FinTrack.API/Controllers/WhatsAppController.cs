using FinTrack.Application.Services.Commands.WhatsAppCommands.WhatsAppSendMessage;
using FinTrack.Application.Services.Queries.WhatsappQueries.WhatsappReceiveMessage;
using FinTrack.Core.WhatsappModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace FinTrack.API.Controllers
{
    [Route("webhook/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {/*
        private readonly WhatsappService WhatsServices;
        public WhatsAppController(WhatsappService whatsServices)
        {
            WhatsServices = whatsServices;
        }*/
        private readonly IMediator _mediator;

        public WhatsAppController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveMessage(WhatsappReceiveMessageQuery payload)
        {   
            // Aqui você pode logar e inspecionar o payload para depois tratar.
            // O WhatsApp espera um 200 OK para considerar a entrega bem-sucedida.
            WhatsappPayload whatsappPayload = WhatsappPayload.FromWhatsAppRequest(payload);
            
            string numeroFormatado = Regex.Replace(whatsappPayload.WaId, @"^(\d{4})(\d{8})$", "+$19$2");
            SendMessageCommand sendMessageCommand = new SendMessageCommand("874135472441326", "+5581995735218", "Estamos processando sua mensagem.",
            "EAAQ2aWuDgB4BPwxw0cZCH2ec7Vq2ZBFNhCbZBinHidAlUbwudxQKSCVIqZCDATPhgPc6hyyBwFSSMGeLsU1yibTFYuobKuNAubWZAddJ5AH1uridpZATjqzjHJeBA25upYU3ZBQUtKpDTjIltJ0dKg86YyTxdPq9RLuLTDZBguZAMIVwI2RTNirzDCQZCnAuTd3xkntRMBMzcmWrAiyw6JcUuUO3WHztCSG3m0hZCB2gQy4hqHgAEWclhOKqJR0zLLYiaMCdBNKHwCKnqi9MbaFy1Er3ySmRjCJANeHDQZDZD");
            
            var mensagemResult = await SendWhatsAppMessage(sendMessageCommand);
            return Ok();
//          return Ok();// (whatsappPayload);
        }

        [HttpGet]
        public IActionResult VerifyWebhook([FromQuery(Name = "hub.mode")] string mode,
                                  [FromQuery(Name = "hub.challenge")] string challenge,
                                  [FromQuery(Name = "hub.verify_token")] string verifyToken)
        {
            var expectedToken = "SEU_TOKEN_DE_VERIFICACAO";
            if (mode == "subscribe" && verifyToken == expectedToken)
            {
                Console.WriteLine($"Challenge: {challenge}");
                return Ok(challenge);
            }
            return Forbid();
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendWhatsAppMessage(SendMessageCommand sendMessageCommand)
        {
            var result = await _mediator.Send(sendMessageCommand);
            if (!result.IsSuccess) return BadRequest(result.Messsage);
            return Ok(result.Data);
        }

    }
}
