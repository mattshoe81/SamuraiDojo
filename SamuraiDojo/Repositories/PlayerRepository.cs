using System;
using System.Collections.Generic;
using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;

namespace SamuraiDojo.Repositories
{
    /// <summary>
    /// Repository for players' statistics, such as rank, 
    /// total historical points, sensei count, etc.
    /// </summary>
    public class PlayerRepository : IPlayerRepository
    {
        public Dictionary<string, IPlayer> Players { get; set; }

        public PlayerRepository()
        {
            Players = new Dictionary<string, IPlayer>();
        }

        public IPlayer GetPlayer(string name)
        {
            IPlayer player = null;
            if (name != null)
            {
                name = name.ToUpper();
                if (Players.ContainsKey(name))
                    player = Players[name];
            }

            return player;
        }

        public void AddPointToHistoricalTotal(string samurai, Type battle, int points = 1)
        {
            if (samurai != null)
                samurai = samurai.ToUpper();

            if (Players.ContainsKey(samurai))
            {
                Players[samurai].TotalPoints += points;
                if (Players[samurai].PointsByBattle.ContainsKey(battle))
                {
                    int battlePoints = Players[samurai].PointsByBattle[battle];
                    Players[samurai].PointsByBattle[battle] = battlePoints + points;
                }
                else
                {
                    Players[samurai].PointsByBattle.Add(battle, points);
                }
            }
            else
            {
                IPlayer player = Factory.Get<IPlayer>();
                player.Name = samurai;
                player.TotalPoints = points;
                player.PointsByBattle = new Dictionary<Type, int>
                    {
                        { battle, points }
                    };

                Players.Add(samurai, player);
            }
        }

        public void CreatePlayer(string samurai)
        {
            if (samurai != null)
                samurai = samurai.ToUpper();

            if (!Players.ContainsKey(samurai))
            {
                IPlayer player = Factory.Get<IPlayer>();
                player.Name = samurai;
                player.TotalPoints = 0;
                player.PointsByBattle = new Dictionary<Type, int>();

                Players.Add(samurai, player);
            }
        }
    }
}
