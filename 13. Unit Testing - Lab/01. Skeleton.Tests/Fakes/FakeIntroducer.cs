using Castle.DynamicProxy.Generators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fakes
{
    public class FakeIntroducer : IIntroducer
    {
        public string Message { get; private set; }
        public void Introduce(string message)
        {
            this.Message = message;
        }
    }
}
