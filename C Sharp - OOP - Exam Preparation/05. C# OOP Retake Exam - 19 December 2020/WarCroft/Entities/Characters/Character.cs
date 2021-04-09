using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {

        private string name;
        private double health;
        private double armor;
        private string status = "Alive";

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = Armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
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
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value > 0 && value <= this.BaseHealth)
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = this.BaseArmor;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {

            EnsureAlive();

            if (this.armor - hitPoints >= 0)
            {
                this.armor -= hitPoints;
            }
            else if (this.armor - hitPoints < 0)
            {
                hitPoints -= this.armor;
                this.armor = 0;
                if (this.health - hitPoints >= 1)
                {
                    this.health -= hitPoints;
                }
                else
                {
                    this.health = 0;
                    this.IsAlive = false;
                    this.status = "Dead";
                }
            }

        }

        public void UseItem(Item item)
        {

            EnsureAlive();

            item.AffectCharacter(this);

        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public override string ToString()
        {
            return
                $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {this.status}";
        }
    }
}