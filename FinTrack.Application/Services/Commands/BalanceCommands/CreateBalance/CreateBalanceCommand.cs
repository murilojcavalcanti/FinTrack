using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.BalanceCommands.CreateBalance
{
    public class CreateBalanceCommand:IRequest<ResultViewModel<int>>
    {
        public CreateBalanceCommand(int month, int year, int userId)
        {
            Month = month;
            Year = year;
            UserId = userId;
        }

        [Range(1,12,ErrorMessage ="Os meses do ano vão de 1 a 12")]
        public int Month { get; set; }
        public int Year { get; set; }
        public int UserId { get; set; }

        public Balance ToEntity() => new Balance(Month,Year,UserId);
    }
}
