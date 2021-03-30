using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public interface ITarget
    {
        int Health { get; }
        int GiveExperience();
        bool IsDead();
        void TakeAttack(int attackPoints);

    }
}
