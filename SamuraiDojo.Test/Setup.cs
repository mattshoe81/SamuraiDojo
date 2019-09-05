using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Test.Interfaces;

namespace SamuraiDojo.Test
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Dojector.Bind<ITestRunner>(typeof(TestRunner));
            Dojector.Bind<ITestExecutionContext>(typeof(TestExecutionContext));
            Dojector.Bind<IUnderTestAttribute>(typeof(UnderTestAttribute));

            HasBeenInitialized = true;
        }
    }
}
