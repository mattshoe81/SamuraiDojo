using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.ScoreBoard
{
    public class Setup : IProjectSetup
    {
        private static bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                // TODO - init

                initialized = true;
            }
        }
    }
}