namespace Mystery.Example.DAL
{
    using Mystery.Example.DAL.Common.Interfaces;
    using Ninject;

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new StandardKernel(new DataModule()));
        }
    }
}