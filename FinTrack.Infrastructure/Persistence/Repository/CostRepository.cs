using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;
using FinTrack.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.Persistence.Repository
{
    public class CostRepository : Repository<Cost>, ICostRepository
    {
        public CostRepository(FinTrackDbContext context) : base(context)
        {
        }
    }
}
