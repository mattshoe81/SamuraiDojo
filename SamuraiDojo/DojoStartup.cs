using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;

namespace SamuraiDojo
{
    public class DojoStartup : IProjectStartup
    {
        private static bool initialized = false;

        public void ProjectInit()
        {
            if (!initialized)
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
}
