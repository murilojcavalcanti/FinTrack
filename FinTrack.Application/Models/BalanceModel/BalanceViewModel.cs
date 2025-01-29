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
        public BalanceViewModel(int month, int year, decimal? totalCosts, decimal? totalReceives, decimal? amountBalance, int id)
        {
            Month = month;
            Year = year;
            TotalCosts = totalCosts;
            TotalReceives = totalReceives;
            AmountBalance = amountBalance;
            Id = id;
        }

        public int Id { get; set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public decimal? TotalCosts { get; set; }
        public decimal? TotalReceives { get; set; }
        public decimal? AmountBalance { get; set; }

        public static BalanceViewModel FromEntity(Balance balance ) => new(balance.Month, balance.Year,balance.TotalCosts,balance.TotalReceives,balance.AmountBalance,balance.Id);
    }
}
