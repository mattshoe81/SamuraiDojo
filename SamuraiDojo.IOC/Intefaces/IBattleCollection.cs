using System.Collections.Generic;

namespace SamuraiDojo.IOC.Interfaces
{
    public interface IBattleCollection
    {
        List<IBattleAttribute> All { get; }
        int Count { get; }

        IBattleAttribute Get(int i);
    }
}