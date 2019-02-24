using Mystery.Example.DAL.Common.Interfaces;
using Ninject.Modules;

namespace Mystery.Example.DAL
{
    using Mystery.Example.DAL.Helpers;

    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ShopDbContext>().ToSelf().InScope(s => ScopeHelper.LifeTimeContainer);
            Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
        }
    }
}
