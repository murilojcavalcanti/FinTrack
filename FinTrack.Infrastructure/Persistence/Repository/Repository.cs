using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;
using FinTrack.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinTrack.Infrastructure.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
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
            return await _context.Set<T>().Where(e => e.IsActive == true).AsNoTracking().ToListAsync();
        }

        public Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(e => e.IsActive == true).SingleOrDefaultAsync(predicate);   
        }


        public async Task Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
        }

        public async Task Delete(BaseEntity Entity)
        {
            Entity.setAsDeleted();
            _context.Set<BaseEntity>().Update(Entity);
        }
    }
}
