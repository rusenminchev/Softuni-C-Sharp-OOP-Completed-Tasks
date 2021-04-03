using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.guns;
        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);
        }

        public bool Remove(IGun model)
        {
            IGun gun = this.guns.FirstOrDefault(g => g.Name == model.Name);

            if (gun == null)
            {
                return false;
            }

            this.guns.Remove(gun);
            return true;
        }

        public IGun FindByName(string name)
        {
            IGun gun = this.guns.FirstOrDefault(g => g.Name == name);

            return gun;
        }
    }
}
