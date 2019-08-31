using System.Collections.Generic;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IBattleRepository
    {
        void AssignAwardToPlayer(IWrittenByAttribute player, IBattleAttribute battle, IBonusPointsAttribute award);
        void CreateBattle(IBattleAttribute battle, ISenseiAttribute sensei);
        IBattleOutcome CurrentBattle();
        List<IBattleOutcome> GetAllBattleOutcomes();
        IBattleOutcome GetBattleOutcome(IBattleAttribute battle);
        void GrantPointsToPlayer(IBattleAttribute battle, IWrittenByAttribute writtenBy, int points = 1);
        bool HasBattle(IBattleAttribute battle);
        void SetEfficiencyScore(IBattleAttribute battle, IWrittenByAttribute writtenBy, double efficiencyScore);
    }
}