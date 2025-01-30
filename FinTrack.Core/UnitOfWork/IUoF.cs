using FinTrack.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.UnitOfWork
{

    public interface IUoF
    {
        public ICostRepository CostRepository { get;}

        public IReceiveRepository ReceiveRepository { get; }
        public IBalanceRepository BalanceRepository { get; }
        public IUserRepository UserRepository { get; }
        void Commit();
    }
}
