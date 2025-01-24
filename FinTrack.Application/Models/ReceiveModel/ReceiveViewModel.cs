using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Models.ReceiveModel
{
    public class ReceiveViewModel
    {
        public ReceiveViewModel(string description, decimal valueReceive)
        {
            Description = description;
            ValueReceive = valueReceive;
        }

        public string Description { get; private set; }
        public decimal ValueReceive { get; private set; }
    }
}
