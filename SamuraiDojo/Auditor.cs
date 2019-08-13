using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
                Log.Exception(ex);
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

            Type[] battleClasses = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo");
            foreach (Type type in battleClasses)
            {
                int bonusPoints = RetrieveBonusPoints(type);
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

        private static int RetrieveBonusPoints(Type type)
        {
            int bonusPoints = 0;

            foreach (Attribute attribute in type.GetCustomAttributes(false))
            {
                if (attribute is BonusPointsAttribute)
                    bonusPoints += ((BonusPointsAttribute)attribute).Points;
            }

            return bonusPoints;
        }
    }
}
