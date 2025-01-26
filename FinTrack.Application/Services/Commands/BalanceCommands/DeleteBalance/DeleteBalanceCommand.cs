using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.BalanceCommands.DeleteBalance
{
    public class DeleteBalanceCommand : IRequest<ResultViewModel>
    {
        public int BalanceId { get; set; }

        public DeleteBalanceCommand(int balanceId)
        {
            BalanceId = balanceId;
        }
    }
}
