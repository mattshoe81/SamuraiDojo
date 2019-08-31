using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.ScoreBoard
{
    public class Setup : ProjectSetup
    {
        private static bool initialized = false;

        protected override bool HasBeenInitialized => initialized;

        protected override void Initialize()
        {
            // TODO - init

            initialized = true;
        }
    }
}