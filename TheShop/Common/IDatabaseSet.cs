using System.Collections.Generic;
using TheShop.Models.Entities;

namespace TheShop.Common
{
    public interface IDatabaseSet<TEntity>
         where TEntity : Entity
    {
        void Add(TEntity entity);

        TEntity GetById(int id);

        List<TEntity> GetAll();

        void Remove(TEntity entity);

    }
}
