using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test
{
    public class Setup : IProjectSetup
    {
        private static bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                Factory.Bind<ITestRunner>(typeof(TestRunner));
                Factory.Bind<ITestExecutionContext>(typeof(TestExecutionContext));
                Factory.Bind<IUnderTestAttribute>(typeof(UnderTestAttribute));

                initialized = true;
            }
        }
    }
}
