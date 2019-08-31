﻿using SamuraiDojo.Attributes;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;

namespace SamuraiDojo
{
    public class Setup : ProjectSetup
    {
        private static bool initialized = false;

        protected override bool HasBeenInitialized => initialized;

        protected override void Initialize()
        {
            Factory.Bind<IBattleOutcome>(typeof(BattleOutcome));
            Factory.Bind<IEfficiencyResult>(typeof(EfficiencyResult));
            Factory.Bind<IPlayer>(typeof(Player));
            Factory.Bind<IPlayerBattleResult>(typeof(PlayerBattleResult));
            Factory.Bind<IBattleAttribute>(typeof(BattleAttribute));
            Factory.Bind<ISenseiAttribute>(typeof(SenseiAttribute));
            Factory.Bind<IWrittenByAttribute>(typeof(WrittenByAttribute));

            Factory.BindSingleton<IBattleCollection>(typeof(BattleCollection));
            Factory.BindSingleton<IBattleRepository>(typeof(BattleRepository));
            Factory.BindSingleton<IPlayerRepository>(typeof(PlayerRepository));

            initialized = true;
        }
    }
}
