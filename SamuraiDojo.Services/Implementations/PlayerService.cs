using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Interfaces;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.Services.Implementations
{
    internal class PlayerService : ServiceBase, IPlayerService
    {
        private IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository, ILog log) : base(log)
        {
            this.playerRepository = playerRepository;
        }


        public IPlayer GetPlayer(string name)
        {
            IPlayer player = playerRepository.GetPlayer(name);
            return player;
        }

        public List<IPlayer> GetAllPlayers()
        {
            List<IPlayer> players = new List<IPlayer>();
            foreach (KeyValuePair<string, IPlayer> pair in playerRepository.Players)
            {
                IPlayer player = playerRepository.GetPlayer(pair.Key);
                if (player != null)
                    players.Add(player);
            }
            players.Sort();

            return players;
        }
    }
}
