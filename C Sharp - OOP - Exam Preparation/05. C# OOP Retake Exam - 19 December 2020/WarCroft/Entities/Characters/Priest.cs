using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name)
            : base(name, 50, 25, 40, new Backpack())
        {

        }

        public void Heal(Character character)
        {
            if (this.IsAlive == true && character.IsAlive == true)
            {
                if (character.Health + this.AbilityPoints > character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
                else
                {
                    character.Health += this.AbilityPoints;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
