using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Angular.WebApiCore.SurveyApp.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
                        
            this.dbSet = context.Set<TEntity>();
        }
        public virtual TEntity GetByID(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsyn()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }        

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void AddRange(TEntity[] entity)
        {
            dbSet.AddRange(entity);
        }
        public virtual async void AddRangeAsync(List<TEntity> entity)
        {
            await dbSet.AddRangeAsync(entity);
        }
        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}
