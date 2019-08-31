using System.Collections.Generic;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IBattleCollection
    {
        List<IBattleAttribute> All { get; }
        int Count { get; }

        IBattleAttribute Get(int i);
    }
}