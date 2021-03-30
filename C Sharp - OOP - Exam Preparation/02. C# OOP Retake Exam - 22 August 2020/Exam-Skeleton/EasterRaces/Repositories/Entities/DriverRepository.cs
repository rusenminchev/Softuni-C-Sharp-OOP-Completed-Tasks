using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        protected override Func<IDriver, bool> GetCurrentModelByName(string name)
        {
            return m => m.Name == name;
        }
    }
}
