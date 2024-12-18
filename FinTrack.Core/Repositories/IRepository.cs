using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Expression<Func<T,bool>>predicate);
        Task<T> Insert(T Entity);
        Task Update(T Entity);
    }
}
