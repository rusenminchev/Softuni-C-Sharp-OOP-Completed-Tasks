﻿using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns;

namespace CounterStrike.Guns.Models
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if (this.BulletsCount < 10)
            {
                return 0;
            }

            this.BulletsCount -= 10;

            return 10;
        }
    }
}
