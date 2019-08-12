using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Repositories;
using SamuraiDojo.Utility;

namespace SamuraiDojo
{
    public class Auditor
    {
        public static void Audit()
        {
            try
            {
                AssignSenseisToChallenges();
                GrantBonusPoints();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private static void AssignSenseisToChallenges()
        {
            // Load up all of the challenges and assign their sensei.
            Type[] types = ReflectionUtility.LoadTypesWithAttribute<ChallengeAttribute>("SamuraiDojo");
            foreach (Type type in types)
            {
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(type);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(type);
                ChallengeRepository.AddChallenge(challenge, sensei);
            }
        }

        private static void GrantBonusPoints()
        {

            Type[] solutionTypes = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo");
            foreach (Type type in solutionTypes)
            {
                int bonusPoints = DetermineBonusPoints(type);
                if (bonusPoints > 0)
                {
                    WrittenByAttribute writtenBy = AttributeUtility.GetAttribute<WrittenByAttribute>(type);

                    Type challengeType = type.GetInterfaces().FirstOrDefault();
                    ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(challengeType);

                    PlayerRepository.AddPoint(writtenBy.Name, challengeType, bonusPoints);
                    ChallengeRepository.AddPlayerPoint(challenge, writtenBy, bonusPoints);
                }
            }
        }

        private static int DetermineBonusPoints(Type type)
        {
            int bonusPoints = 0;
            if (AttributeUtility.HasAttribute<MostEfficientAttribute>(type))
                bonusPoints += 5;
            if (AttributeUtility.HasAttribute<MostElegantAttribute>(type))
                bonusPoints += 5;

            return bonusPoints;
        }
    }
}
