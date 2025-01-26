using FinTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinTrack.Core.Entities
{
    public class Balance : BaseEntity
    {
        public Balance(int month ,int year) : base()
        {
            Month = month;
            Year = year;
        }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public void Update(int month,int year)
        {
            Month = month;
            Year = year;

        }
    }
}
