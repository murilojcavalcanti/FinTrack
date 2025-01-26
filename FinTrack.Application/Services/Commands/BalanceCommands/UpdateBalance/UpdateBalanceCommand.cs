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
        public UpdateBalanceCommand(int month, int year)
        {
            Month = month;
            Year = year;
        }

        public int BalanceId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

    }
}
