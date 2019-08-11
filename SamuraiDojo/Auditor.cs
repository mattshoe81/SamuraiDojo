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
                ChallengeRepository.AddChallenge(challenge);
            }
        }
    }
}
