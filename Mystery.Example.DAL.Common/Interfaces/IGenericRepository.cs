using System.Linq;

namespace Mystery.Example.DAL.Common.Interfaces
{
    using System.Collections.Generic;

    public interface IGenericRepository<TEntity, in TId> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(TId id);

        TEntity Add(TEntity model);

        TEntity Update(TEntity model);

        void Delete(TEntity model);
    }
}
