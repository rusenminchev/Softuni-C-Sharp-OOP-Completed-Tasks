using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary )
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; set; }
        

        private Corps TryParseCorps(string corpsString)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsString, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }   
    }
}
