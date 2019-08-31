using SamuraiDojo.Attributes;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Scoring.Auditors
{
    internal class TestAuditor : IAuditor
    {
        public void Audit()
        {
            RunUnitTests();
        }

        private void RunUnitTests()
        {
            ITestRunner testRunner = Factory.Get<ITestRunner>();

            SetPreTestAction(testRunner);
            SetPassedTestAction(testRunner);

            testRunner.Run();
        }

        private void SetPreTestAction(ITestRunner testRunner)
        {
            testRunner.PreTest = (context) =>
            {
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                battle.Sensei = sensei;
                Factory.Get<IPlayerRepository>().CreatePlayer(sensei.Name);

                Factory.Get<IBattleRepository>().CreateBattle(battle, sensei);
            };
        }

        private void SetPassedTestAction(ITestRunner testRunner)
        {
            testRunner.OnTestPass = (context) =>
            {
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    Factory.Get<IPlayerRepository>().AddPointToHistoricalTotal(context.WrittenBy.Name, context.ClassUnderTest, points);
                    Factory.Get<IBattleRepository>().GrantPointsToPlayer(battle, context.WrittenBy, points);
                }

            };
        }
    }
}
