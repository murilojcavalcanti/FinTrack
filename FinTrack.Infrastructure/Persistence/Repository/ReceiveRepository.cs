using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;

namespace FinTrack.Infrastructure.Persistence.Repository
{
    internal class ReceiveRepository : Repository<Receive>, IReceiveRepository
    {
        public ReceiveRepository(FinTrackDbContext context) : base(context)
        {
        }
    }
}
