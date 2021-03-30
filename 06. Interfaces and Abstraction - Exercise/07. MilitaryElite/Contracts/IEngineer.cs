using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }

        public void AddRepair(IRepair repair);

    }
}
