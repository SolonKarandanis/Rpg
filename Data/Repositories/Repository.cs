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
            // foreach(var entity in entities.Chunk(10)){

            // }
            dbSet.AddRange(entities);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            dbSet.Remove(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return await db.SaveChangesAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> filter,string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
           return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
           return await dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PageResponse<T>> FindAll(Paging paging)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            var totalNumber = await query.CountAsync();

            var page = paging.Page -1;
            var pageResults = paging.Size;
            var pageCount = (totalNumber + page)/ paging.Page;
            var skippedElements = page * pageResults;

            var result = await query
                .Skip(skippedElements)
                .Take(pageResults)
                .ToListAsync();
            var response = new PageResponse<T>(result,totalNumber,pageCount);
            return response;
        }

        public async Task<int> Update(T entity)
        {
            dbSet.Update(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateRange(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
            return await db.SaveChangesAsync();
        }

    }
}