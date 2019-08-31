using System;
using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.IOC.Interfaces;
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
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(type);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(type);
                BattleRepository.CreateBattle(battle, sensei);
            }
        }

        private void GrantBonusPoints()
        {
            Type[] battleClasses = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo");
            foreach (Type battle in battleClasses)
            {
                List<BonusPointsAttribute> awards = RetrieveAwards(battle);
                if (awards.Count > 0)
                    ProcessAwards(battle, awards);
            }
        }

        private List<BonusPointsAttribute> RetrieveAwards(Type type)
        {
            List<BonusPointsAttribute> awards = new List<BonusPointsAttribute>();

            foreach (Attribute attribute in type.GetCustomAttributes(false))
            {
                if (attribute is BonusPointsAttribute)
                    awards.Add(attribute as BonusPointsAttribute);
            }

            return awards;
        }

        private void ProcessAwards(Type battleType, List<BonusPointsAttribute> awards)
        {
            WrittenByAttribute player = AttributeUtility.GetAttribute<WrittenByAttribute>(battleType);
            BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(battleType);

            int bonusPoints = 0;
            foreach (BonusPointsAttribute award in awards)
            {
                bonusPoints += award.Points;
                BattleRepository.AssignAwardToPlayer(player, battle, award);
            }

            PlayerRepository.AddPointToHistoricalTotal(player.Name, battle.Type, bonusPoints);
            BattleRepository.GrantPointsToPlayer(battle, player, bonusPoints);
        }
    }
}
