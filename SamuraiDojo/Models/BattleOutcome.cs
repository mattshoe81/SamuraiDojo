using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Models
{
    public class BattleOutcome : IComparable<BattleOutcome>
    {
        public BattleAttribute Battle { get; set; }

        public SenseiAttribute Sensei { get; set; }

        public List<BattleResult> Results { get; set; }

        public BattleOutcome()
        {
            Results = new List<BattleResult>();
        }

        public void Add(BattleResult result, SenseiAttribute sensei)
        {
            Results.Add(result);
            Sensei = sensei;
        }

        public void AddPoint(WrittenByAttribute writtenBy, int points = 1)
        {
            BattleResult playerResult = Results.Where((result) => result.Player.Name == writtenBy.Name)?.FirstOrDefault();
            if (playerResult == null)
            {
                Results.Add(new BattleResult
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

        public void SetEfficiencyScore(WrittenByAttribute writtenBy, double efficiencyScore)
        {
            BattleResult result = Get(writtenBy.Name);

            //if (result != null)
            //    result.Efficiency = efficiencyScore;
        }

        public BattleResult Get(string player)
        {
            BattleResult result = Results.Where((battleResult) => battleResult.Player.Name == player).FirstOrDefault();
            return result;
        }

        public List<BattleResult> All()
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
