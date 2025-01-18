using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    public class Cost : BaseEntity
    {
        public Cost(DateTime createdAt, decimal priceCost, string description) : base(createdAt)
        {
            PriceCost = priceCost;
            Description = description;
        }

        public decimal PriceCost { get; private set; }
        public string Description { get; private set; }
    }
}
