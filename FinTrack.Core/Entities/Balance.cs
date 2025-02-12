using FinTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinTrack.Core.Entities
{
    public class Balance : BaseEntity
    {
        public Balance(int month, int year, int userId) : base()
        {
            Month = month;
            Year = year;
            UserId = userId;
        }
        [Range(1,12,ErrorMessage ="Os valores de Meses do ano devem ser entre 1 e 12")]
        public int Month { get; private set; }
        [Range(1900,2300,ErrorMessage ="o valor minimo é 1900 e o máximo 2300")]
        public int Year { get; private set; }
        public int UserId { get;private set; }
        public User User { get; private set; }
        public List<Cost> Costs { get; private set; }
        public List<Receive> Receives { get; private set; }
        public Decimal TotalCosts{ get; private set; }
        public Decimal TotalReceives{get; private set;}
        public Decimal AmountBalance{get; private set;}

        public void Update(int month,int year)
        {
            Month = month;
            Year = year;
        }

        public void AddCosts(decimal Cost)
        {
            TotalCosts = TotalCosts + Cost;
        }
        public void AddReceives(decimal Receives)
        {
            TotalReceives = TotalReceives + Receives;
        }
        public void RemoveCosts(decimal Cost)
        {
            TotalCosts = TotalCosts - Cost;
        }
        public void RemoveReceives(decimal Receives)
        {
            TotalReceives = TotalReceives - Receives;
        }

        public void CalculateAmountBalance()
        {
            AmountBalance = TotalReceives - TotalCosts;
        }
    }
}
