using FinTrack.Application.Models;
using FinTrack.Application.Services.Whatsapp;
using FinTrack.Core.WhatsappModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.WhatsappQueries.WhatsappReceiveMessage
{
    public class WhatsappReceiveMessageHandler : IRequestHandler<WhatsappReceiveMessageQuery, ResultViewModel<string>>
    {
        private readonly IMediator _mediator;
        private readonly WhatsappService _whatsappService;
        public WhatsappReceiveMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<ResultViewModel<string>> Handle(WhatsappReceiveMessageQuery request, CancellationToken cancellationToken)
        {
            WhatsappPayload payload = WhatsappPayload.FromWhatsAppRequest(request);


            return Task.FromResult(ResultViewModel<string>.Success("Mensagem enviada"));
        }
    }
}
