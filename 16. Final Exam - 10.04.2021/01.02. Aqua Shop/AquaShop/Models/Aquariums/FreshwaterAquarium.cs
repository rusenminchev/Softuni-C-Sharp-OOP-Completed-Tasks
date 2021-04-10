using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        public FreshwaterAquarium(string name)
            : base(name, 50)
        {
        }
    }
}
