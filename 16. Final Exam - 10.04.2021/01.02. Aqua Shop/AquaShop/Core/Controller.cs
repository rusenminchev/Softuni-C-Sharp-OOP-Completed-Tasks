using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException
                    (string.Format(Utilities.Messages.ExceptionMessages
                    .InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (aquarium == null)
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(Utilities.Messages
                .OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (aquarium == null)
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            if (IsWaterSuitable(fish, aquarium))
            {
                aquarium.AddFish(fish);
                return string.Format(Utilities.Messages
                    .OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return "Water not suitable.";
            }
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (aquarium == null)
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }
            
            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (aquarium == null)
            {
                throw new InvalidOperationException
                    (Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            var aquariumValue = aquarium.Decorations.Sum(d=>d.Price) + aquarium.Fish.Sum(f => f.Price);

            return $"The value of Aquarium {aquariumName} is {aquariumValue:f2}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private bool IsWaterSuitable(IFish fish, IAquarium aquarium)
        {
            return (fish.GetType().Name.Contains("Freshwater") && aquarium.GetType().Name.Contains("Freshwater"))
                   || (fish.GetType().Name.Contains("Saltwater") && aquarium.GetType().Name.Contains("Saltwater"));
        }
    }
}
