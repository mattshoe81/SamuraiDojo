﻿using SamuraiDojo.Attributes;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;

namespace SamuraiDojo
{
    internal class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Factory.Bind<IBattleOutcome>(typeof(BattleOutcome));
            Factory.Bind<IEfficiencyResult>(typeof(EfficiencyResult));
            Factory.Bind<IPlayer>(typeof(Player));
            Factory.Bind<IPlayerBattleResult>(typeof(PlayerBattleResult));
            Factory.Bind<IBattleAttribute>(typeof(BattleAttribute));
            Factory.Bind<ISenseiAttribute>(typeof(SenseiAttribute));
            Factory.Bind<IWrittenByAttribute>(typeof(WrittenByAttribute));

            Factory.Bind<IBattleCollection>(typeof(BattleCollection), BindingConfig.Singleton);
            Factory.Bind<IBattleRepository>(typeof(BattleRepository), BindingConfig.Singleton);
            Factory.Bind<IPlayerRepository>(typeof(PlayerRepository), BindingConfig.Singleton);

            HasBeenInitialized = true;
        }
    }
}
