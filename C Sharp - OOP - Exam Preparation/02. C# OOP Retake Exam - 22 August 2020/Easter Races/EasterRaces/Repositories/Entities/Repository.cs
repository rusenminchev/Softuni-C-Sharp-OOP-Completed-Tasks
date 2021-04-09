using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)this.models;
        }

        public T GetByName(string name)
        {
            T model = this.models.FirstOrDefault(GetCurrentModelByName(name));

            return model;
        }

        public bool Remove(T name)
        {
            if (this.models.Contains(name))
            {
                this.models.Remove(name);

                return true;
            }
            return false;
        }

        protected abstract Func<T, bool> GetCurrentModelByName(string name);
    }
}
