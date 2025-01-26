using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using FinTrack.Infrastructure.Persistence.Repository;

namespace FinTrack.Infrastructure.Persistence.unitOfWork
{
    public class UoF : IUoF
    {
        private readonly FinTrackDbContext _context;

        private IUserRepository _userRepository;
        private ICostRepository _costRepository;
        private IReceiveRepository _ReceiveRepository;
        private IBalanceRepository _BalanceRepository;
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

        public ICostRepository CostRepository
        {
            get
            {
                return _costRepository = _costRepository ?? new CostRepository(_context);
            }
        }

        public IReceiveRepository ReceiveRepository
        {
            get
            {
                return _ReceiveRepository ?? new ReceiveRepository(_context);
            }
        }
        public IBalanceRepository BalanceRepository
        {
            get
            {
                return _BalanceRepository ?? new BalanceRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
