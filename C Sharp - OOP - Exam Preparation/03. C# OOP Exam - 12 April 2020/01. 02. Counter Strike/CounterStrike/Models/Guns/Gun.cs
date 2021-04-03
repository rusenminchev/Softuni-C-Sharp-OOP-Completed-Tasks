using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.name = value;
            }
        }
        public int BulletsCount
        {
            get
            {
                return this.bulletCount;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this.bulletCount = value;
            }
        }

        // Not sure is it the best approach to use abstract method and overide it in the child classes
        public abstract int Fire();

    }
}
