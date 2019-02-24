using Mystery.Example.DAL.Common.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Mystery.Example.DAL.Repositories.GenericRepository
{
    using System.Collections.Generic;

    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, new()
    {
        private readonly ShopDbContext context;

        public GenericRepository(ShopDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region CRUD

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public TEntity Get(TId id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }
 
        #endregion
    }
}
