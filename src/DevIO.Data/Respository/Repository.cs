using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Respository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        
        public virtual async Task<TEntity> Get(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            await SaveChanges();
        }                

        public virtual async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        public virtual async Task Remove(Guid id)
        {
            _context.Remove(new TEntity { Id = id});
            await SaveChanges();
        }
        
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
