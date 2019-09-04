using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test
{
    public class Setup : ProjectSetup
    {
        protected override bool HasBeenInitialized { get; set; }

        protected override void Initialize()
        {
            new SamuraiDojo.Setup();
            new SamuraiDojo.Utility.Setup();

            Factory.Bind<ITestRunner>(typeof(TestRunner));
            Factory.Bind<ITestExecutionContext>(typeof(TestExecutionContext));
            Factory.Bind<IUnderTestAttribute>(typeof(UnderTestAttribute));

            HasBeenInitialized = true;
        }
    }
}
