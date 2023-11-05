using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using rpg.Data;

namespace Rpg.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext db;
        internal DbSet<T> dbSet;

        public Repository(DataContext db)
        {
            this.db=db;
            this.dbSet = db.Set<T>();
        }
        public async Task<int> Create(T entity)
        {
            dbSet.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> CreateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(T entity)
        {
            dbSet.Remove(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Find(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(T entity)
        {
            dbSet.Update(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}