using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    public class Cost : BaseEntity
    {
        public Cost(decimal priceCost, string description, int idBalance) : base()
        {
            PriceCost = priceCost;
            Description = description;
            IdBalance = idBalance;
        }

        public int IdBalance { get; private set; }
        public decimal PriceCost { get; private set; }
        public string Description { get; private set; }
        public Balance Balance { get; private set; }

        public void Update(decimal priceCost, string description,int idBalance)
        {
            PriceCost = priceCost;
            Description = description;
            IdBalance = idBalance;
        }
    }
}
