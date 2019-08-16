using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
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
                AssignSenseisToBattles();
                GrantBonusPoints();
            }
            catch(Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private static void AssignSenseisToBattles()
        {
            // Load up all of the battles and assign their sensei.
            Type[] types = ReflectionUtility.LoadTypesWithAttribute<BattleAttribute>("SamuraiDojo");
            foreach (Type type in types)
            {
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(type);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(type);
                BattleRepository.AddBattle(battle, sensei);
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
                    BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(type);



                    PlayerRepository.AddPoint(writtenBy.Name, battle.Type, bonusPoints);
                    BattleRepository.AddPlayerPoint(battle, writtenBy, bonusPoints);
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
