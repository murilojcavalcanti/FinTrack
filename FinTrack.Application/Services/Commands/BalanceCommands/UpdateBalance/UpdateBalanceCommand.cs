using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.BalanceCommands.UpdateBalance
{
    public class UpdateBalanceCommand:IRequest<ResultViewModel>
    {
        public UpdateBalanceCommand(byte month, byte year, int balanceId, int userId)
        {
            Month = month;
            Year = year;
            BalanceId = balanceId;
            UserId = userId;
        }

        public int BalanceId { get; set; }
        public int UserId { get; set; }
        public byte Month { get; set; }
        public byte Year { get; set; }

    }
}
