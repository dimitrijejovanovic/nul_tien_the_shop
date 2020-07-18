using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Common;
using TheShop.Models.Entities;

namespace TheShop.Utils
{
    public sealed class InMemorySet<TEntity> : IDatabaseSet<TEntity>
       where TEntity : Entity
    {
        private List<TEntity> _entities;

        public InMemorySet()
        {
            _entities = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entity.ID = _entities.Count > 0 ? _entities.Last().ID + 1 : 1;
            _entities.Add(entity);
        }

        public List<TEntity> GetAll()
        {
            return _entities;
        }

        public TEntity GetById(int id)
        {
            return _entities.SingleOrDefault(x => x.ID == id);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
