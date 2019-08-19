using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.Models;

namespace SamuraiDojo.Repositories
{
    public class BattleRepository
    {
        private static List<BattleOutcome> battles;

        static BattleRepository()
        {
            battles = new List<BattleOutcome>();
        }

        public static void AddPlayerPoint(BattleAttribute battle, WrittenByAttribute writtenBy, int points = 1)
        {
            if (HasBattle(battle))
            {
                BattleOutcome battleOutcome = GetBattleOutcome(battle);
                battleOutcome.AddPoint(writtenBy, points);
            }
            else
            {
                BattleOutcome battleResults = new BattleOutcome();
                battleResults.Battle = battle;
                battleResults.AddPoint(writtenBy, points);
                battles.Add(battleResults);
            }
        }

        public static void AddAward(WrittenByAttribute player, BattleAttribute battle, BonusPointsAttribute award)
        {
            if (HasBattle(battle))
            {
                BattleOutcome battleOutcome = GetBattleOutcome(battle);
                battleOutcome.AddAward(player, award);
            }
            else
            {
                BattleOutcome battleOutcome = new BattleOutcome();
                battleOutcome.Battle = battle;
                battleOutcome.AddAward(player, award);
                battles.Add(battleOutcome);
            }
        }

        public static void AddBattle(BattleAttribute battle, SenseiAttribute sensei)
        {
            if (!HasBattle(battle))
            {
                BattleOutcome battleOutcome = new BattleOutcome();
                battleOutcome.Battle = battle;
                battleOutcome.Sensei = sensei;
                battles.Add(battleOutcome);
            }
        }

        public static void SetEfficiencyScore(BattleAttribute battle, WrittenByAttribute writtenBy, double efficiencyScore)
        {
            if (HasBattle(battle))
            {
                BattleOutcome battleOutcome = GetBattleOutcome(battle);
                battleOutcome.SetEfficiencyScore(writtenBy, efficiencyScore);
            }
        }

        public static List<BattleOutcome> GetAllBattleOutcomes()
        {
            for (int i = 0; i < battles.Count; i++)
                battles[i].Results.Sort();

            battles.Sort();

            return battles;
        }

        public static BattleOutcome GetBattleOutcome(BattleAttribute battle)
        {
            BattleOutcome results = battles.Where((x) => x.Battle.Equals(battle))?.FirstOrDefault();
            return results;
        }

        public static bool HasBattle(BattleAttribute battle)
        {
            bool hasBattle = GetBattleOutcome(battle) != null;

            return hasBattle;
        }

        public static BattleOutcome CurrentBattle()
        {
            List<BattleOutcome> battleOutcomes = GetAllBattleOutcomes();
            DateTime max = battleOutcomes.Max((battle) => battle.Battle.Deadline);
            BattleOutcome current = battleOutcomes.Where((battle) => battle.Battle.Deadline == max).FirstOrDefault();

            return current;
        }
    }
}
