using System.Collections.Generic;
using Eticket.Dal.Entities;

namespace Eticket.Dal.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        TKey Insert(TEntity entity);
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity data);
        bool Delete(TKey id);
    }
}