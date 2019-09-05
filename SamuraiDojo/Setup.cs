using SamuraiDojo.Attributes;
using SamuraiDojo.Interfaces;
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
            Dojector.Bind<IBattleOutcome>(typeof(BattleOutcome));
            Dojector.Bind<IEfficiencyResult>(typeof(EfficiencyResult));
            Dojector.Bind<IPlayer>(typeof(Player));
            Dojector.Bind<IPlayerBattleResult>(typeof(PlayerBattleResult));
            Dojector.Bind<IBattleAttribute>(typeof(BattleAttribute));
            Dojector.Bind<ISenseiAttribute>(typeof(SenseiAttribute));
            Dojector.Bind<IWrittenByAttribute>(typeof(WrittenByAttribute));

            Dojector.Bind<IBattleCollection>(typeof(BattleCollection), BindingConfig.Singleton);
            Dojector.Bind<IBattleRepository>(typeof(BattleRepository), BindingConfig.Singleton);
            Dojector.Bind<IPlayerRepository>(typeof(PlayerRepository), BindingConfig.Singleton);

            HasBeenInitialized = true;
        }
    }
}
