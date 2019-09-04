using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC.Interfaces.Test
{
    public interface IParent
    {
        IChild1 Child1 { get; set; }
        IChild2 Child2 { get; set; }
    }
}
