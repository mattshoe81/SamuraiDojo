using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC
{
    public class Setup : IProjectSetup
    {
        private static bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                // TODO - init project

                initialized = true;
            }
        }
    }

    public enum Project
    {
        Dojo,
        Test,
        Benchmarking,
        ScoreBoard,
        Scoring,
        Utility
    }
}
