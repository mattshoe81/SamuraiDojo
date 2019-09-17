using System;
using System.Collections.Generic;

namespace SamuraiDojo.Interfaces
{
    public interface IPlayerRepository
    {
        Dictionary<string, IPlayer> Players { get; set; }

        void AddPointToHistoricalTotal(string samurai, Type battle, int points = 1);
        void CreatePlayer(string samurai);
        IPlayer GetPlayer(string name);
    }
}