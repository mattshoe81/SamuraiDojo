using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.Interfaces.Test;

namespace SamuraiDojo.Test.IoC.Models
{
    class CircularDependency1 : ICircularDependency1
    {
        public ICircularDependency2 CircularDependency { get; set; }

        public CircularDependency1(ICircularDependency2 dependency) { }
    }
}
