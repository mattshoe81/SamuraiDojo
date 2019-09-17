using System.Collections.Generic;
using SamuraiDojo.Interfaces;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.Services.Implementations
{
    internal class BattleService : ServiceBase, IBattleService
    {
        private IBattleRepository battleRepository;

        public BattleService(IBattleRepository battleRepository, ILog log) : base(log)
        {
            this.battleRepository = battleRepository;
        }

        public IBattleOutcome GetMostRecentBattle()
        {
            IBattleOutcome battle = battleRepository.CurrentBattle();
            return battle;
        }

        public List<IBattleOutcome> GetAllBattles()
        {
            List<IBattleOutcome> battles = battleRepository.GetAllBattleOutcomes();
            return battles;
        }
    }
}
