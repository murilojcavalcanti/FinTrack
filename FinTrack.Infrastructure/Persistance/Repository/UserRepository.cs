using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;
using FinTrack.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.Persistance.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FinTrackDbContext _context) : base(_context)
        {
        }

    }
}
