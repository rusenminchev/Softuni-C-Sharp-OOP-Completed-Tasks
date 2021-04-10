using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
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
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }
        public int Comfort => this.decorations.Sum(d => d.Comfort);
        public ICollection<IDecoration> Decorations => (ICollection<IDecoration>)this.decorations;
        public ICollection<IFish> Fish => (ICollection<IFish>)this.fish;

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.fish.Count)
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            IFish fishToRemove = this.fish.FirstOrDefault(f => f.Name == fish.Name);

            if (fishToRemove == null)
            {
                return false;
            }

            this.fish.Remove(fishToRemove);
            return true;
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fish.Select(f => f.Name))}");
            }

            sb.AppendLine($"Decorations: {this.decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
