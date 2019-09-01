using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.Interfaces.Test;

namespace SamuraiDojo.Test.IoC.Models
{
    internal class ParentMultipleConstructors : IParent
    {
        public IChild1 Child1 { get; set; }
        public IChild2 Child2 { get; set; }

        public ParentMultipleConstructors(IChild1 child1, IChild2 child2)
        {
            Child1 = child1;
            Child2 = child2;
        }

        public ParentMultipleConstructors(int stuff) { }

        public ParentMultipleConstructors(int stuff, string moreStuff) { }

        public ParentMultipleConstructors(int stuff, string moreStuff, double things) { }

        public ParentMultipleConstructors(float things, char stuff) { }


    }
}
