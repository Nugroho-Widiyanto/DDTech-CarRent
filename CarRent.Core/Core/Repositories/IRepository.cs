using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Core.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Get(int id);

        Task<IEnumerable<TEntity>> GetAll();

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}
