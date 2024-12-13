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
        public Balance(DateTime createdAt, MonthEnum mes) : base(createdAt)
        {
            Mes = mes;
        }
        public MonthEnum Mes { get; private set; }
    }
}
