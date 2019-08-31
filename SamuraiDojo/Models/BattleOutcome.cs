using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// The total results of a battle for every player.
    /// </summary>
    public class BattleOutcome : IComparable<BattleOutcome>
    {
        public BattleAttribute Battle { get; set; }

        public SenseiAttribute Sensei { get; set; }

        public List<PlayerBattleResult> Results { get; set; }

        public BattleOutcome()
        {
            Results = new List<PlayerBattleResult>();
        }

        public void Add(PlayerBattleResult result, SenseiAttribute sensei)
        {
            Results.Add(result);
            Sensei = sensei;
        }

        public void AddPoint(WrittenByAttribute writtenBy, int points = 1)
        {
            PlayerBattleResult playerResult = Results.Where((result) => result.Player.Name == writtenBy.Name)?.FirstOrDefault();
            if (playerResult == null)
            {
                Results.Add(new PlayerBattleResult
                {
                    Player = writtenBy,
                    Points = points
                });
            }
            else
            {
                int index = Results.FindIndex(item => item.Player.Equals(writtenBy));
                Results[index].Points += points;
            }
        }

        public void AddAward(WrittenByAttribute player, BonusPointsAttribute award)
        {
            PlayerBattleResult result = Get(player.Name);

            if (result != null)
                result.Awards.Add(award);
            else
            {
                Results.Add(new PlayerBattleResult
                {
                    Player = player,
                    Points = 0,
                    Awards = new List<BonusPointsAttribute> { award }
                });
            }
        }

        public void SetEfficiencyScore(WrittenByAttribute writtenBy, double efficiencyScore)
        {
            PlayerBattleResult result = Get(writtenBy.Name);

            //if (result != null)
            //    result.Efficiency = efficiencyScore;
        }

        public PlayerBattleResult Get(string player)
        {
            PlayerBattleResult result = Results.Where((battleResult) => battleResult.Player.Name == player).FirstOrDefault();
            return result;
        }

        public List<PlayerBattleResult> All()
        {
            Results.Sort();
            return Results;
        }

        public int CompareTo(BattleOutcome other)
        {
            DateTime thisDeadline = Battle.Deadline;
            DateTime otherDeadline = other.Battle.Deadline;

            int result = 0;
            if (thisDeadline > otherDeadline)
                result = -1;
            else if (thisDeadline < otherDeadline)
                result = 1;

            return result;
        }
    }
}
