using System;

namespace Mystery.Example.DAL.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TModel, TId> GetGenericRepository<TModel, TId>() where TModel : class, new();

        int SaveChanges();
    }
}
