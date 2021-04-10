﻿using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        public Fish(string name, string species, decimal price, int size)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = size;
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
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }

        public string Species
        {
            get
            {
                return this.species;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidFishSpecies);
                }
                this.species = value;
            }
        }

        public int Size { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidFishPrice);
                }
                this.price = value;
            }
        }

        public abstract void Eat();
    }
}
