using FinTrack.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinTrack.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FinTrackDbContext _context;

        public Repository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<T> Insert(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            return Entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync<T>(predicate);
        }


        public async Task Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
        }        
    }
}
