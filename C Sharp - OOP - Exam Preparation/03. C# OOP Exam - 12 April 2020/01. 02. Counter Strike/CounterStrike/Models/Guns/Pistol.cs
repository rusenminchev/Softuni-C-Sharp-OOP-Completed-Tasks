﻿using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns;

namespace CounterStrike.Guns.Models
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if (this.BulletsCount < 1)
            {
                return 0;
            }

            this.BulletsCount--;

            return 1;
        }
    }
}
