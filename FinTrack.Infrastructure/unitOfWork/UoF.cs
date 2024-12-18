using FinTrack.Core.UnitOfWork;
using FinTrack.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.UnitOfWork
{
    public class UoF : IUoF
    {
        private readonly FinTrackDbContext _context;

        public UoF(FinTrackDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
