using FinTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Models.BalanceModel
{
    public class BalanceViewModel
    {
        public BalanceViewModel(int month, int year)
        {
            Month = month;
            Year = year;
        }

        public int Month { get; private set; }
        public int Year { get; private set; }

        public static BalanceViewModel FromEntity(Balance balance ) => new(balance.Month, balance.Year);
    }
}
