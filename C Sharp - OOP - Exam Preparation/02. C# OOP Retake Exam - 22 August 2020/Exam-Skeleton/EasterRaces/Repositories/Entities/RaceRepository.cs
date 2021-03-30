using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        protected override Func<IRace, bool> GetCurrentModelByName(string name)
        {
            return m => m.Name == name;
        }
    }
}
