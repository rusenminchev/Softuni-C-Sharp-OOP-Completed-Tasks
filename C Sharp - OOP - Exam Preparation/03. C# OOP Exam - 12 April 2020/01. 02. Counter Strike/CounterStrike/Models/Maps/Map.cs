using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                var playerType = player.GetType().Name;

                if (playerType == "Terrorist")
                {
                    this.terrorists.Add(player);
                }
                else if (playerType == "CounterTerrorist")
                {
                    this.counterTerrorists.Add(player);
                }
            }

            while (this.terrorists.Any(t => t.IsAlive == true) &&
                   this.counterTerrorists.Any(c => c.IsAlive == true))
            {
                // I have to some this problem. When someone dies continue to shoot the enemies.

                foreach (var terrorst in this.terrorists)
                {
                    foreach (var counterTerrorist in this.counterTerrorists)
                    {
                        // Probably this validation is obsolete
                        if (terrorst.IsAlive == false || counterTerrorist.IsAlive == false)
                        {
                            continue;
                        }

                        counterTerrorist.TakeDamage(terrorst.Gun.Fire());
                    }
                }

                foreach (var counterTerrorist in this.counterTerrorists)
                {
                    foreach (var terrorst in this.terrorists)
                    {
                        if (terrorst.IsAlive == false || counterTerrorist.IsAlive == false)
                        {
                            continue;
                        }

                        terrorst.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (this.terrorists.Any(t => t.IsAlive == true))
            {
                return "Terrorist wins!";
            }

            return "Counter Terrorist wins!";

        }
    }
}
