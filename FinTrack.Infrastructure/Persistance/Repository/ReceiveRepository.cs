using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.Persistance.Repository
{
    internal class ReceiveRepository : Repository<Receive>, IReceiveRepository
    {
        public ReceiveRepository(FinTrackDbContext context) : base(context)
        {
        }
    }
}
