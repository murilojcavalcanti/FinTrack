using FinTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Models.CostModel
{
    public class CostViewModel
    {
        public CostViewModel(decimal priceCost, string description, DateTime createdAt, Balance balance)
        {
            PriceCost = priceCost;
            Description = description;
            CreatedAt = createdAt;
            this.balance = balance;
        }

        public decimal PriceCost { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Balance balance { get; set; }

        public static CostViewModel FromEntity(Cost Cost) => new(Cost.PriceCost, Cost.Description, Cost.CreatedAt, Cost.Balance);
    }
}
