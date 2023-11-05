using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rpg.Data.Repositories
{
    internal interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> Find(Expression<Func<T, bool>> filter);
        Task<T> FindById(int id);
        Task<int> Create(T entity);
        Task<int> CreateRange(IEnumerable<T> entities);
        Task<int> Update(T entity);
        Task<int> UpdateRange(IEnumerable<T> entities);
        Task<int> Delete(T entity);
        Task<int> DeleteRange(IEnumerable<T> entities);
    }
}