using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Utility
{
    public class Setup : ProjectSetup
    {
        protected override bool HasBeenInitialized { get; set; }

        protected override void Initialize()
        {
            Factory.Bind<IReflectionUtility>(typeof(ReflectionUtility));
            Factory.Bind<IAttributeUtility>(typeof(AttributeUtility));
            Factory.Bind<ILog>(typeof(Log));

            HasBeenInitialized = true;
        }
    }
}
