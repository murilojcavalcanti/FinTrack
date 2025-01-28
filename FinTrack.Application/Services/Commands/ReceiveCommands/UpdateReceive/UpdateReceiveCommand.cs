using FinTrack.Application.Models;
using FinTrack.Core.Entities;
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
        public UpdateReceiveCommand(string description, decimal valueReceive, int receiveId, int idBalance)
        {
            Description = description;
            ValueReceive = valueReceive;
            ReceiveId = receiveId;
            IdBalance = idBalance;
        }

        public int ReceiveId { get; set; }
        public string Description { get; set; }
        public decimal ValueReceive { get; set; }

        public int IdBalance { get; set; }
    }
}
