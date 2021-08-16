using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {        
        Task<TEntity> Get(Guid id);
        Task<List<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(Guid id);

        Task<int> SaveChanges();

    }
}
