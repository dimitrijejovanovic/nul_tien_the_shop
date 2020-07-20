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
            _entities.Add(entity);
        }

        public List<TEntity> GetAll()
        {
            return _entities;
        }

        public TEntity GetById(int id)
        {
            return _entities.Single(x => x.ID == id);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
