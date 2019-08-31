using System;
using System.Collections.Generic;
using SamuraiDojo.IOC.Interfaces;

namespace SamuraiDojo.IOC.Interfaces
{
    public interface IBattleOutcome : IComparable<IBattleOutcome>
    {
        IBattleAttribute Battle { get; set; }
        List<IPlayerBattleResult> Results { get; set; }
        ISenseiAttribute Sensei { get; set; }

        void Add(IPlayerBattleResult result, ISenseiAttribute sensei);
        void AddAward(IWrittenByAttribute player, IBonusPointsAttribute award);
        void AddPoint(IWrittenByAttribute writtenBy, int points = 1);
        List<IPlayerBattleResult> All();
        IPlayerBattleResult Get(string player);
    }
}