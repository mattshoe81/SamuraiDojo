using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test
{
    public class Setup : ProjectSetup
    {
        private static bool initialized = false;

        protected override bool HasBeenInitialized => initialized;

        protected override void Initialize()
        {
            new SamuraiDojo.Setup();

            Factory.Bind<ITestRunner>(typeof(TestRunner));
            Factory.Bind<ITestExecutionContext>(typeof(TestExecutionContext));
            Factory.Bind<IUnderTestAttribute>(typeof(UnderTestAttribute));

            initialized = true;
        }
    }
}
