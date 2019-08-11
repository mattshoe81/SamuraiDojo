using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;

namespace SamuraiDojo.Stats
{
    public class ChallengeRepository
    {
        private static List<ChallengeResults> challenges;

        static ChallengeRepository()
        {
            challenges = new List<ChallengeResults>();
        }

        public static void AddPlayerPoint(ChallengeAttribute challenge, WrittenByAttribute writtenBy)
        {
            if (HasChallenge(challenge))
            {
                ChallengeResults challengeResults = GetChallengeResults(challenge);
                challengeResults.AddPoint(writtenBy);
            }
            else
            {
                ChallengeResults challengeResults = new ChallengeResults();
                challengeResults.Challenge = challenge;
                challengeResults.AddPoint(writtenBy);
                challenges.Add(challengeResults);
            }
        }

        public static void AddChallenge(ChallengeAttribute challenge)
        {
            if (!HasChallenge(challenge))
            {
                ChallengeResults challengeResults = new ChallengeResults();
                challengeResults.Challenge = challenge;
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
            ChallengeResults current = GetAllChallengeResults().Where((challenge) => challenge.Challenge.Deadline == max).FirstOrDefault();

            return current;
        }
    }
}
