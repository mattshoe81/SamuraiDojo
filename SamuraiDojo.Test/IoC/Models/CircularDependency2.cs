using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.Interfaces.Test;

namespace SamuraiDojo.Test.IoC.Models
{
    class CircularDependency2 : ICircularDependency2
    {
        public ICircularDependency1 CircularDependency { get; set; }

        public CircularDependency2(ICircularDependency1 dependency) { }
    }
}
