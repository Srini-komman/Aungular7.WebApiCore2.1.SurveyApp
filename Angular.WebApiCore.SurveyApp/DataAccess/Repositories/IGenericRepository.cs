using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.WebApiCore.SurveyApp.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();        
        void Add(TEntity entity);
        void AddRange(TEntity[] entity);
        void AddRangeAsync(List<TEntity> entity);
        void Remove(TEntity entity);
    }
}
