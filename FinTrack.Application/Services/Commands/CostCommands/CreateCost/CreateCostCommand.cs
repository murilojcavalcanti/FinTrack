using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.CreateCost
{
    public class CreateCostCommand : IRequest<ResultViewModel<int>>
    {
        public CreateCostCommand(decimal priceCost, string description, int idBalance)
        {
            PriceCost = priceCost;
            Description = description;
            IdBalance = idBalance;
        }

        public int IdBalance { get; set; }
        public decimal PriceCost { get; set; }
        public string Description { get; set; }
       
        public Cost ToEntity() => new(PriceCost, Description,IdBalance);
    }
}
