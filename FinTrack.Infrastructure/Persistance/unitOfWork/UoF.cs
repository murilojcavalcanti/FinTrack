using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using FinTrack.Infrastructure.Persistance;
using FinTrack.Infrastructure.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.Persistance.unitOfWork
{
    public class UoF : IUoF
    {
        private readonly FinTrackDbContext _context;

        private IUserRepository _userRepository;
        public UoF(FinTrackDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
            }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
