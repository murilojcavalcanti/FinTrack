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
        public CostViewModel(decimal priceCost, string description, DateTime createdAt)
        {
            PriceCost = priceCost;
            Description = description;
            CreatedAt = createdAt;
        }

        public decimal PriceCost { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public static CostViewModel FromEntity(Cost Entity) => new(Entity.PriceCost, Entity.Description, Entity.CreatedAt);
    }
}
