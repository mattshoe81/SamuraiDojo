using System.Collections.Generic;

namespace SamuraiDojo.Interfaces
{
    public interface IBattleCollection
    {
        List<IBattleAttribute> All { get; }
        int Count { get; }

        IBattleAttribute Get(int i);
    }
}