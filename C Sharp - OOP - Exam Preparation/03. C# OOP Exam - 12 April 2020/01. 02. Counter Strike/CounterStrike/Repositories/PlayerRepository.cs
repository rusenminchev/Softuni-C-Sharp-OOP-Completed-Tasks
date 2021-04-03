using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.players;
        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(model);
        }

        public bool Remove(IPlayer model)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username == model.Username);

            if (player == null)
            {
                return false;
            }

            this.players.Remove(player);
            return true;
        }

        public IPlayer FindByName(string name)
        {
            IPlayer player = this.players.FirstOrDefault(g => g.Username == name);

            return player;
        }
    }
}
