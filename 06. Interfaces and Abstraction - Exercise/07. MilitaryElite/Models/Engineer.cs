using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }
        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine($"Repairs:");

            foreach (var repair in this.repairs)
            {
                sb.AppendLine($"  {repair}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
