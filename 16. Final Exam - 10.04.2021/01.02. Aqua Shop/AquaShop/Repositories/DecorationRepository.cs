using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>) this.decorations;
        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            IDecoration decoration = this.decorations
                .FirstOrDefault(d => d.GetType().Name == model.GetType().Name);

            if (decoration == null)
            {
                return false;
            }

            this.decorations.Remove(model);
            return true;
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = this.decorations
                .FirstOrDefault(d => d.GetType().Name == type);

            return decoration;
        }
    }
}
