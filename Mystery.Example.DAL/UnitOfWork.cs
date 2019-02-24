namespace Mystery.Example.DAL
{
    using System;
    using Mystery.Example.DAL.Common.Interfaces;
    using Mystery.Example.DAL.Helpers;
    using Mystery.Example.DAL.Repositories.GenericRepository;
    using Ninject;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly StandardKernel kernel;

        public UnitOfWork(StandardKernel kernel)
        {
            this.kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
            ScopeHelper.StartNewLifeTime();
        }

        public void Dispose() => this.kernel.Dispose();

        public IGenericRepository<TModel, TId> GetGenericRepository<TModel, TId>() where TModel : class, new() 
            => new GenericRepository<TModel, TId>(this.GetContext());

        public int SaveChanges() => this.GetContext().SaveChanges();

        private ShopDbContext GetContext()
        {
            return this.kernel.TryGet<ShopDbContext>();
        }
    }
}
