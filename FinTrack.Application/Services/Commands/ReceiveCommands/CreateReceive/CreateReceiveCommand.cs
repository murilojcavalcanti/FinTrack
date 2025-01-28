using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.CreateReceive
{
    public class CreateReceiveCommand:IRequest<ResultViewModel<int>>
    {
        public CreateReceiveCommand(string description, decimal valueReceive, int idBalance)
        {
            Description = description;
            ValueReceive = valueReceive;
            IdBalance = idBalance;
        }

        public string Description { get; private set; }
        public decimal ValueReceive { get; private set; }
        public int IdBalance { get; set; }
        public Receive ToEntity() => new Receive(Description, ValueReceive, IdBalance);
    }
}
