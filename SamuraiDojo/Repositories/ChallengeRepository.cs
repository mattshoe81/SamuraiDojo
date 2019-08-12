using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;

namespace SamuraiDojo.Repositories
{
    public class ChallengeRepository
    {
        private static List<ChallengeResults> challenges;

        static ChallengeRepository()
        {
            challenges = new List<ChallengeResults>();
        }

        public static void AddPlayerPoint(ChallengeAttribute challenge, WrittenByAttribute writtenBy, int points = 1)
        {
            if (HasChallenge(challenge))
            {
                ChallengeResults challengeResults = GetChallengeResults(challenge);
                challengeResults.AddPoint(writtenBy, points);
            }
            else
            {
                ChallengeResults challengeResults = new ChallengeResults();
                challengeResults.Challenge = challenge;
                challengeResults.AddPoint(writtenBy, points);
                challenges.Add(challengeResults);
            }
        }

        public static void AddChallenge(ChallengeAttribute challenge, SenseiAttribute sensei)
        {
            if (!HasChallenge(challenge))
            {
                ChallengeResults challengeResults = new ChallengeResults();
                challengeResults.Challenge = challenge;
                challengeResults.Sensei = sensei;
                challenges.Add(challengeResults);
            }
        }

        public static List<ChallengeResults> GetAllChallengeResults()
        {
            for (int i = 0; i < challenges.Count; i++)
                challenges[i].Results.Sort();

            challenges.Sort();

            return challenges;
        }

        public static ChallengeResults GetChallengeResults(ChallengeAttribute challenge)
        {
            ChallengeResults results = challenges.Where((x) => x.Challenge.Equals(challenge))?.FirstOrDefault();
            return results;
        }

        public static bool HasChallenge(ChallengeAttribute challenge)
        {
            bool hasChallenge = GetChallengeResults(challenge) != null;

            return hasChallenge;
        }

        public static ChallengeResults CurrentChallenge()
        {
            List<ChallengeResults> challenges = GetAllChallengeResults();
            DateTime max = challenges.Max((challenge) => challenge.Challenge.Deadline);
            ChallengeResults current = challenges.Where((challenge) => challenge.Challenge.Deadline == max).FirstOrDefault();

            return current;
        }
    }
}
