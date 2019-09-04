using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC
{
    public static class Setup
    {
        private static bool initialized = false;

        public static void Initialize()
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
