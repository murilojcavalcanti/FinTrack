using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    public class Receive : BaseEntity
    {
        public Receive(string description, decimal valueReceive)
        {
            Description = description;
            ValueReceive = valueReceive;
        }
        public string Description { get; private set; }
        public decimal ValueReceive { get; private set; }
    }
}
