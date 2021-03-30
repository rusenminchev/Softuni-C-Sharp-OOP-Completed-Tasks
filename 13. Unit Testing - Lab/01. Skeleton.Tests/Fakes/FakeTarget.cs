using Skeleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public const int TargetExperience = 200;

        public int Health => 0;

        public int GiveExperience() => TargetExperience;
       
        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {

        }
    }
}
