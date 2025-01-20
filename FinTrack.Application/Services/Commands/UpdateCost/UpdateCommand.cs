using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UpdateCost
{
    public class UpdateCommand:IRequest<ResultViewModel>
    {
        public UpdateCommand(decimal priceCost, string description, int idCost)
        {

            PriceCost = priceCost;
            DescriptionCost = description;
            IdCost = idCost;
        }

        public int IdCost { get; set; }
        public decimal PriceCost { get; set; }
        public string DescriptionCost { get; set; }
    }
}
