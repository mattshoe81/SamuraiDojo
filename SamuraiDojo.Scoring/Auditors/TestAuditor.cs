using SamuraiDojo.Attributes;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Repositories;
using SamuraiDojo.Test;
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
            TestRunner testRunner = new TestRunner();

            SetPreTestAction(testRunner);
            SetPassedTestAction(testRunner);

            testRunner.Run();
        }

        private void SetPreTestAction(TestRunner testRunner)
        {
            testRunner.PreTest = (context) =>
            {
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                battle.Sensei = sensei;
                PlayerRepository.CreatePlayer(sensei.Name);

                BattleRepository.CreateBattle(battle, sensei);
            };
        }

        private void SetPassedTestAction(TestRunner testRunner)
        {
            testRunner.OnTestPass = (context) =>
            {
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    PlayerRepository.AddPointToHistoricalTotal(context.WrittenBy.Name, context.ClassUnderTest, points);
                    BattleRepository.GrantPointsToPlayer(battle, context.WrittenBy, points);
                }

            };
        }
    }
}
