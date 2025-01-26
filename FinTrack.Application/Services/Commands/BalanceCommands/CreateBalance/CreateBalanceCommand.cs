using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.BalanceCommands.CreateBalance
{
    public class CreateBalanceCommand:IRequest<ResultViewModel<int>>
    {
        public CreateBalanceCommand(int month, int year)
        {
            Month = month;
            Year = year;
        }

        public int Month { get; set; }
        public int Year { get; set; }

        public Balance ToEntity() => new Balance(Month,Year);
    }
}
