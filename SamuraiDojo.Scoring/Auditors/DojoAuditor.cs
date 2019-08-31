using System;
using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Repositories;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Scoring.Auditors
{
    /// <summary>
    /// Logic to analyze data contained in the SamuraiDojo project, such as 
    /// reflectively gathering all battles, determining their sensei, and 
    /// assigning bonus points to players for each battle.
    /// </summary>
    internal class DojoAuditor : IAuditor
    {
        public void Audit()
        {
            try
            {
                AssignSenseisToBattles();
                GrantBonusPoints();
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private void AssignSenseisToBattles()
        {
            // Load up all of the battles, assign their sensei, and send to the repository
            Type[] types = ReflectionUtility.LoadTypesWithAttribute<BattleAttribute>("SamuraiDojo");
            foreach (Type type in types)
            {
                IBattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(type);
                ISenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(type);
                Factory.Get<IBattleRepository>().CreateBattle(battle, sensei);
            }
        }

        private void GrantBonusPoints()
        {
            Type[] battleClasses = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo");
            foreach (Type battle in battleClasses)
            {
                List<IBonusPointsAttribute> awards = RetrieveAwards(battle);
                if (awards.Count > 0)
                    ProcessAwards(battle, awards);
            }
        }

        private List<IBonusPointsAttribute> RetrieveAwards(Type type)
        {
            List<IBonusPointsAttribute> awards = new List<IBonusPointsAttribute>();

            foreach (Attribute attribute in type.GetCustomAttributes(false))
            {
                if (attribute is IBonusPointsAttribute)
                    awards.Add(attribute as IBonusPointsAttribute);
            }

            return awards;
        }

        private void ProcessAwards(Type battleType, List<IBonusPointsAttribute> awards)
        {
            IWrittenByAttribute player = AttributeUtility.GetAttribute<WrittenByAttribute>(battleType);
            IBattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(battleType);

            int bonusPoints = 0;
            foreach (IBonusPointsAttribute award in awards)
            {
                bonusPoints += award.Points;
                Factory.Get<IBattleRepository>().AssignAwardToPlayer(player, battle, award);
            }

            Factory.Get<IPlayerRepository>().AddPointToHistoricalTotal(player.Name, battle.Type, bonusPoints);
            Factory.Get<IBattleRepository>().GrantPointsToPlayer(battle, player, bonusPoints);
        }
    }
}
