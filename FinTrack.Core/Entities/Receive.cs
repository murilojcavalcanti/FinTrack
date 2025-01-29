using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    public class Receive : BaseEntity
    {
        public Receive(string description, decimal valueReceive, int idBalance)
        {
            Description = description;
            ValueReceive = valueReceive;
            IdBalance = idBalance;
        }
        public string Description { get; private set; }
        public decimal ValueReceive { get; private set; }
        public int IdBalance {  get; private set; }
        public Balance Balance { get; private set; }
        public void Update(decimal value, string description,int idBalance)
        {
            ValueReceive = value;
            Description = description;
            IdBalance = idBalance;
        }
    }
}
