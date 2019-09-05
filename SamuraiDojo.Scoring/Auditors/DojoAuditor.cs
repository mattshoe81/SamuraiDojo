using System;
using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Scoring.Interfaces;

namespace SamuraiDojo.Scoring.Auditors
{
    /// <summary>
    /// Logic to analyze data contained in the SamuraiDojo project, such as 
    /// reflectively gathering all battles, determining their sensei, and 
    /// assigning bonus points to players for each battle.
    /// </summary>
    internal class DojoAuditor : IDojoAuditor
    {
        private IReflectionUtility reflectionUtility;
        private IAttributeUtility attributeUtility;
        private IBattleRepository battleRepository;
        private IPlayerRepository playerRepository;
        private ILog log;

        public DojoAuditor(
            IReflectionUtility reflectionUtility,
            IAttributeUtility attributeUtility,
            IBattleRepository battleRepository,
            IPlayerRepository playerRepository,
            ILog log)
        {
            this.reflectionUtility = reflectionUtility;
            this.attributeUtility = attributeUtility;
            this.battleRepository = battleRepository;
            this.playerRepository = playerRepository;
            this.log = log;
        }

        public void Audit()
        {
            try
            {
                AssignSenseisToBattles();
                GrantBonusPoints();
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
        }

        private void AssignSenseisToBattles()
        {
            // Load up all of the battles, assign their sensei, and send to the repository
            Type[] types = reflectionUtility.LoadTypesWithAttribute<BattleAttribute>("SamuraiDojo");
            foreach (Type type in types)
            {
                IBattleAttribute battle = attributeUtility.GetAttribute<BattleAttribute>(type);
                ISenseiAttribute sensei = attributeUtility.GetAttribute<SenseiAttribute>(type);
                battleRepository.CreateBattle(battle, sensei);
            }
        }

        private void GrantBonusPoints()
        {
            Type[] battleClasses = reflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo");
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
            IWrittenByAttribute player = attributeUtility.GetAttribute<WrittenByAttribute>(battleType);
            IBattleAttribute battle = attributeUtility.GetAttribute<BattleAttribute>(battleType);

            int bonusPoints = 0;
            foreach (IBonusPointsAttribute award in awards)
            {
                bonusPoints += award.Points;
                battleRepository.AssignAwardToPlayer(player, battle, award);
            }

            playerRepository.AddPointToHistoricalTotal(player.Name, battle.Type, bonusPoints);
            battleRepository.GrantPointsToPlayer(battle, player, bonusPoints);
        }
    }
}
