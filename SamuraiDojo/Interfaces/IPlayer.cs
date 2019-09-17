using System;
using System.Collections.Generic;

namespace SamuraiDojo.Interfaces
{
    public interface IPlayer : IComparable<IPlayer>
    {
        int BattlesCompleted { get; }
        string Name { get; set; }
        Dictionary<Type, int> PointsByBattle { get; set; }
        int Rank { get; set; }
        int SenseiCount { get; set; }
        int TotalPoints { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}