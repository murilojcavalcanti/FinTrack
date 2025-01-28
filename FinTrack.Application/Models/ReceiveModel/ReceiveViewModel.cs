using FinTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Models.ReceiveModel
{
    public class ReceiveViewModel
    {
        public ReceiveViewModel(string description, decimal valueReceive, Balance balance)
        {
            Description = description;
            ValueReceive = valueReceive;
            Balance = balance;
        }

        public string Description { get; set; }
        public decimal ValueReceive { get; set; }
        public Balance Balance { get; set; }

        public static ReceiveViewModel FromEntity(Receive receive) => new(receive.Description,receive.ValueReceive,receive.Balance);
    }
}
