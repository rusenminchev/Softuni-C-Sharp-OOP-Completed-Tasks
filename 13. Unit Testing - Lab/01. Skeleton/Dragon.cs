using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class Dragon
    {
        private IIntroducer introducer;
        public Dragon(string name, IIntroducer introducer)
        {
            this.Name = name;
            this.introducer = introducer;
        }
        public string Name { get; private set; }

        public void Introduce()
        {
            this.introducer.Introduce($"Hello, I am {this.Name} - The Dragon! I love to burn things!");
        }
    }
}
