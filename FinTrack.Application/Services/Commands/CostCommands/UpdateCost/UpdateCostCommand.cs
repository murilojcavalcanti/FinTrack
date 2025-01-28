using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.UpdateCost
{
    public class UpdateCostCommand : IRequest<ResultViewModel>
    {
        public UpdateCostCommand(decimal priceCost, string description, int idCost, int idBalance)
        {

            PriceCost = priceCost;
            DescriptionCost = description;
            IdCost = idCost;
            IdBalance = idBalance;
        }

        public int IdCost { get; set; }
        public decimal PriceCost { get; set; }
        public string DescriptionCost { get; set; }
        public int IdBalance { get; set; }
    }
}
