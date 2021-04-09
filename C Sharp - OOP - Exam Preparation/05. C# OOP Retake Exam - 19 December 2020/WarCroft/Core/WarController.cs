using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private ICollection<Item> items;
        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;

            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string
                    .Format(Constants.ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string
                    .Format(Constants.ExceptionMessages.InvalidItem, itemName));
            }

            this.items.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var items = this.items.ToList();

            Item itemToPickUp = items[this.items.Count - 1];

            character.Bag.AddItem(itemToPickUp);

            return $"{characterName} picked up {itemToPickUp.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters
                .OrderByDescending(c => c.IsAlive == true)
                .ThenByDescending(c => c.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characters.FirstOrDefault(c => c.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            Character receiver = this.characters.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attacker.GetType().Name == "Priest")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Warrior warrior = (Warrior)attacker;

            warrior.Attack(receiver);

            string outputMessage = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} " +
                                   $"hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP " +
                                   $"and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.IsAlive == false)
            {
                outputMessage += $"{Environment.NewLine}{receiver.Name} is dead!";
            }

            return outputMessage;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characters.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            Character receiver = this.characters.FirstOrDefault(c => c.Name == healingReceiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healer.GetType().Name == "Warrior")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            Priest priest = (Priest)healer;

            priest.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
                   $"{receiver.Name} has {receiver.Health} health now!";

        }
    }
}
