using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.ScoreBoard
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            HasBeenInitialized = true;
        }
    }
}