using SamuraiDojo.Attributes;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Scoring.Interfaces;
using SamuraiDojo.Test.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Scoring.Auditors
{
    internal class TestAuditor : ITestAuditor
    {
        private ITestRunner testRunner;
        private IAttributeUtility attributeUtility;
        private IBattleRepository battleRepository;
        private IPlayerRepository playerRepository;

        public TestAuditor(
            ITestRunner testRunner,
            IAttributeUtility attributeUtility,
            IBattleRepository battleRepository,
            IPlayerRepository playerRepository)
        {
            this.testRunner = testRunner;
            this.attributeUtility = attributeUtility;
            this.battleRepository = battleRepository;
            this.playerRepository = playerRepository;
        }

        public void Audit()
        {
            SetPreTestAction(testRunner);
            SetPassedTestAction(testRunner);

            testRunner.Run();
        }

        private void SetPreTestAction(ITestRunner testRunner)
        {
            testRunner.PreTest = (context) =>
            {
                ISenseiAttribute sensei = attributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);
                IBattleAttribute battle = attributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                battle.Sensei = sensei;
                playerRepository.CreatePlayer(sensei.Name);

                battleRepository.CreateBattle(battle, sensei);
            };
        }

        private void SetPassedTestAction(ITestRunner testRunner)
        {
            testRunner.OnTestPass = (context) =>
            {
                IBattleAttribute battle = attributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                ISenseiAttribute sensei = attributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    playerRepository.AddPointToHistoricalTotal(context.WrittenBy.Name, context.ClassUnderTest, points);
                    battleRepository.GrantPointsToPlayer(battle, context.WrittenBy, points);
                }

            };
        }
    }
}
