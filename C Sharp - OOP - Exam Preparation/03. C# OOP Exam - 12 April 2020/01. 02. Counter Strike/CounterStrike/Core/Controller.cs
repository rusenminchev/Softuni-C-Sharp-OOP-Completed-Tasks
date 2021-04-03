using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Guns.Models;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                // possible mistake in the problem description
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);
            return $"Successfully added gun {name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;

            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type == "Terrorist")
            {
                player = new Terrorist(username,health,armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);
            return $"Successfully added player {username}.";
        }

        public string StartGame()
        {
            return this.map.Start(this.players.Models.ToList());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.players.Models.OrderBy(p => p.GetType().Name)
                .ThenByDescending(p=> p.Health).ThenBy(p=> p.Username))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
