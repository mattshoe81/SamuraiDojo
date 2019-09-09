using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Services.Implementations;

namespace SamuraiDojo.Services
{
    internal class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Dojector.Bind<IPlayerService>(typeof(PlayerService));
            Dojector.Bind<IBattleService>(typeof(BattleService));
        }
    }
}
