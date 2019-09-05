using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Interfaces;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC;

namespace SamuraiDojo.Repositories
{
    /// <summary>
    /// Repository for Battle data, tracking scores for each player for each battle.
    /// </summary>
    internal class BattleRepository : IBattleRepository
    {
        private List<IBattleOutcome> battles;

        public BattleRepository()
        {
            battles = new List<IBattleOutcome>();
        }

        public void GrantPointsToPlayer(IBattleAttribute battle, IWrittenByAttribute writtenBy, int points = 1)
        {
            if (HasBattle(battle))
            {
                IBattleOutcome battleOutcome = GetBattleOutcome(battle);
                battleOutcome.AddPoint(writtenBy, points);
            }
            else
            {
                IBattleOutcome battleResults = Factory.Get<IBattleOutcome>();
                battleResults.Battle = battle;
                battleResults.AddPoint(writtenBy, points);
                battles.Add(battleResults);
            }
        }

        public void AssignAwardToPlayer(IWrittenByAttribute player, IBattleAttribute battle, IBonusPointsAttribute award)
        {
            if (HasBattle(battle))
            {
                IBattleOutcome battleOutcome = GetBattleOutcome(battle);
                battleOutcome.AddAward(player, award);
            }
            else
            {
                IBattleOutcome battleOutcome = Factory.Get<IBattleOutcome>();
                battleOutcome.Battle = battle;
                battleOutcome.AddAward(player, award);
                battles.Add(battleOutcome);
            }
        }

        public void CreateBattle(IBattleAttribute battle, ISenseiAttribute sensei)
        {
            if (!HasBattle(battle))
            {
                IBattleOutcome battleOutcome = Factory.Get<IBattleOutcome>();
                battleOutcome.Battle = battle;
                battleOutcome.Sensei = sensei;
                battles.Add(battleOutcome);
            }
        }

        public void SetEfficiencyScore(IBattleAttribute battle, IWrittenByAttribute writtenBy, double efficiencyScore)
        {
            if (HasBattle(battle))
            {
                IBattleOutcome battleOutcome = GetBattleOutcome(battle);
                //battleOutcome.SetEfficiencyScore(writtenBy, efficiencyScore);
            }
        }

        public List<IBattleOutcome> GetAllBattleOutcomes()
        {
            for (int i = 0; i < battles.Count; i++)
                battles[i].Results.Sort();

            battles.Sort();

            return battles;
        }

        public IBattleOutcome GetBattleOutcome(IBattleAttribute battle)
        {
            IBattleOutcome results = battles.Where((x) => x.Battle.Equals(battle))?.FirstOrDefault();
            return results;
        }

        public bool HasBattle(IBattleAttribute battle)
        {
            bool hasBattle = GetBattleOutcome(battle) != null;

            return hasBattle;
        }

        public IBattleOutcome CurrentBattle()
        {
            List<IBattleOutcome> battleOutcomes = GetAllBattleOutcomes();
            DateTime max = battleOutcomes.Max((battle) => battle.Battle.Deadline);
            IBattleOutcome current = battleOutcomes.Where((battle) => battle.Battle.Deadline == max).FirstOrDefault();
            //IBattleOutcome current = battleOutcomes.Where((battle) => battle.Battle.Name == "Census Maximus").FirstOrDefault();

            return current;
        }
    }
}
