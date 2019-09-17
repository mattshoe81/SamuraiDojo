using System;

namespace SamuraiDojo.Interfaces
{
    public interface IBattleAttribute
    {
        DateTime Deadline { get; set; }
        string Name { get; set; }
        ISenseiAttribute Sensei { get; set; }
        Type Type { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}