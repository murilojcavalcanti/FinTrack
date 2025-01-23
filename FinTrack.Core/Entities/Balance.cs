using FinTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    internal class Balance : BaseEntity
    {
        public Balance() : base()
        {
            Month = DateTime.UtcNow.Month;
            Year = DateTime.UtcNow.Year;
        }
        public int Month { get; private set; }
        public int Year { get; private set; }
    }
}
