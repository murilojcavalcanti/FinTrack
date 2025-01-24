using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.UpdateReceive
{
    public class UpdateReceiveCommand:IRequest<ResultViewModel>
    {
        public UpdateReceiveCommand(string description, decimal valueReceive, int receiveId)
        {
            Description = description;
            ValueReceive = valueReceive;
            ReceiveId = receiveId;
        }

        public int ReceiveId { get; set; }
        public string Description { get; private set; }
        public decimal ValueReceive { get; private set; }

    }
}
