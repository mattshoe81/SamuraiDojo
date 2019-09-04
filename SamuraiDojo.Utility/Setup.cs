using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Utility
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Factory.Bind<IReflectionUtility>(typeof(ReflectionUtility));
            Factory.Bind<IAttributeUtility>(typeof(AttributeUtility));

            Factory.Bind<ILog>(typeof(Log));

            HasBeenInitialized = true;
        }
    }
}
