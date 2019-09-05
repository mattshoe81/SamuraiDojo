using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.Utility
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Dojector.Bind<IReflectionUtility>(typeof(ReflectionUtility));
            Dojector.Bind<IAttributeUtility>(typeof(AttributeUtility));

            Dojector.Bind<ILog>(typeof(Log));

            HasBeenInitialized = true;
        }
    }
}
