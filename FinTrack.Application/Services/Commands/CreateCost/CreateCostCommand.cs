using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CreateCost
{
    public class CreateCostCommand:IRequest<ResultViewModel<int>>
    {
        public CreateCostCommand(decimal priceCost, string description, DateTime createdAt)
        {
            PriceCost = priceCost;
            Description = description;
            CreatedAt = createdAt != DateTime.Now ? createdAt: DateTime.Now;
        }

        public decimal PriceCost { get; set; }
        public string Description { get; set; }
        DateTime CreatedAt { get; set; }

        public Cost ToEntity() => new(CreatedAt,PriceCost, Description);
    }
}
