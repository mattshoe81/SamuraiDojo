using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Models
{
    public class ChallengeResults : IComparable<ChallengeResults>
    {
        public ChallengeAttribute Challenge { get; set; }

        public SenseiAttribute Sensei { get; set; }

        public List<ChallengeResult> Results { get; set; }

        public ChallengeResults()
        {
            Results = new List<ChallengeResult>();
        }

        public void Add(ChallengeResult result, SenseiAttribute sensei)
        {
            Results.Add(result);
            Sensei = sensei;
        }

        public void AddPoint(WrittenByAttribute writtenBy, int points = 1)
        {
            ChallengeResult playerResult = Results.Where((result) => result.Player.Name == writtenBy.Name)?.FirstOrDefault();
            if (playerResult == null)
            {
                Results.Add(new ChallengeResult
                {
                    Player = writtenBy,
                    Points = points
                });
            }
            else
            {
                int index = Results.FindIndex(item => item.Player.Equals(writtenBy));
                Results[index].Points++;
            }
        }

        public ChallengeResult Get(string player)
        {
            ChallengeResult result = Results.Where((challengeResult) => challengeResult.Player.Name == player).FirstOrDefault();
            return result;
        }

        public List<ChallengeResult> All()
        {
            Results.Sort();
            return Results;
        }

        public int CompareTo(ChallengeResults other)
        {
            DateTime thisDeadline = Challenge.Deadline;
            DateTime otherDeadline = other.Challenge.Deadline;

            int result = 0;
            if (thisDeadline > otherDeadline)
                result = -1;
            else if (thisDeadline < otherDeadline)
                result = 1;

            return result;
        }
    }
}
