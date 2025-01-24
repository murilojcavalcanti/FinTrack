using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.DeleteReceive
{
    public class DeleteReceiveCommand:IRequest<ResultViewModel>
    {
        public int Receiveid { get; private set; }

        public DeleteReceiveCommand(int receiveid)
        {
            Receiveid = receiveid;
        }
    }
}
