using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }
        public void AddMission(IMission mission);
    }
}
