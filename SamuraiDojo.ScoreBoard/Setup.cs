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
        protected override bool HasBeenInitialized { get; set; } 

        protected override void Initialize()
        {
            new SamuraiDojo.Utility.Setup();
            new SamuraiDojo.Scoring.Setup();

            HasBeenInitialized = true;
        }
    }
}