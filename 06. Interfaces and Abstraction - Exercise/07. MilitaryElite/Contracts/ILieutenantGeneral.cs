using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(Private @private);
    }
}
