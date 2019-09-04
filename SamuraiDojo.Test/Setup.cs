using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Factory.Bind<ITestRunner>(typeof(TestRunner));
            Factory.Bind<ITestExecutionContext>(typeof(TestExecutionContext));
            Factory.Bind<IUnderTestAttribute>(typeof(UnderTestAttribute));

            HasBeenInitialized = true;
        }
    }
}
