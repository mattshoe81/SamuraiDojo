using System.Collections.Generic;
using SamuraiDojo.Interfaces;

namespace SamuraiDojo.Services
{
    internal interface IBattleService
    {
        List<IBattleOutcome> GetAllBattles();
        IBattleOutcome GetMostRecentBattle();
    }
}