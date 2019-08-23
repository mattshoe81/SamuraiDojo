using SamuraiDojo.Attributes;
using SamuraiDojo.Repositories;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Scoring
{
    internal class TestAuditor
    {
        public static void Audit()
        {
            RunUnitTests();
        }

        private static void RunUnitTests()
        {
            TestRunner testRunner = new TestRunner();

            SetPreTestAction(testRunner);
            SetPassedTestAction(testRunner);

            testRunner.Run();
        }

        private static void SetPreTestAction(TestRunner testRunner)
        {
            testRunner.PreTest = (context) =>
            {
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                battle.Sensei = sensei;
                PlayerRepository.AddPlayer(sensei.Name);

                BattleRepository.AddBattle(battle, sensei);
            };
        }

        private static void SetPassedTestAction(TestRunner testRunner)
        {
            testRunner.OnTestPass = (context) =>
            {
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    PlayerRepository.AddPoint(context.WrittenBy.Name, context.ClassUnderTest, points);
                    BattleRepository.AddPlayerPoint(battle, context.WrittenBy, points);
                }

            };
        }
    }
}
