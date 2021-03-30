using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        IReadOnlyCollection<IPrivate> ILieutenantGeneral.Privates => (IReadOnlyCollection<Private>)this.privates;

        public void AddPrivate(Private @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}")
                .AppendLine($"Privates:");

            foreach (var @private in this.privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
