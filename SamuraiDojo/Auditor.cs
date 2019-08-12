using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Stats;
using SamuraiDojo.Utility;

namespace SamuraiDojo
{
    public class Auditor
    {
        public static void Audit()
        {
            Type[] types = ReflectionUtility.LoadTypesWithAttribute<ChallengeAttribute>("SamuraiDojo");
            foreach (Type type in types)
            {
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(type);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(type);
                ChallengeRepository.AddChallenge(challenge, sensei);
            }

            Type[] solutionTypes = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo");
            foreach (Type type in solutionTypes)
            {
                WrittenByAttribute writtenBy = AttributeUtility.GetAttribute<WrittenByAttribute>(type);

                // Code smell if i ever smelt one
                Type challengeType = type.GetInterfaces().FirstOrDefault();
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(challengeType);


                int bonusPoints = 0;
                if (AttributeUtility.HasAttribute<MostEfficientAttribute>(type))
                    bonusPoints += 5;
                if (AttributeUtility.HasAttribute<MostElegantAttribute>(type))
                    bonusPoints += 5;

                if (bonusPoints > 0)
                {
                    ScoreKeeper.AddPoint(writtenBy.Name, challengeType, bonusPoints);
                    ChallengeRepository.AddPlayerPoint(challenge, writtenBy, bonusPoints);
                }
            }
        }
    }
}
