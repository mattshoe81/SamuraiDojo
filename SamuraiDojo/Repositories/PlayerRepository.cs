using System;
using System.Collections.Generic;
using SamuraiDojo.Battles.Week1;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;

namespace SamuraiDojo.Repositories
{
    /// <summary>
    /// Repository for players' statistics, such as rank, 
    /// total historical points, sensei count, etc.
    /// </summary>
    public class PlayerRepository 
    {
        public readonly static Dictionary<string, Player> Players;

        static PlayerRepository()
        {
            Players = new Dictionary<string, Player>();
        }

        public static Player GetPlayer(string name)
        {
            Player player = null;
            if (name != null)
            {
                name = name.ToUpper();
                if (Players.ContainsKey(name))
                    player = Players[name];
            }

            return player;
        }

        public static void AddPointToHistoricalTotal(string samurai, Type battle, int points = 1)
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
                Players.Add(samurai, new Player
                {
                    Name = samurai,
                    TotalPoints = points,
                    PointsByBattle = new Dictionary<Type, int>
                    {
                        { battle, points }
                    }
                });
            }
        }

        public static void CreatePlayer(string samurai)
        {
            if (samurai != null)
                samurai = samurai.ToUpper();

            if (!Players.ContainsKey(samurai))
            {
                Players.Add(samurai, new Player
                {
                    Name = samurai,
                    TotalPoints = 0,
                    PointsByBattle = new Dictionary<Type, int>()
                });
            }
        }
    }
}
