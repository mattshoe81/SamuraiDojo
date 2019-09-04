using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC.Interfaces.Test
{
    public interface ICircularDependency1
    {
        ICircularDependency2 CircularDependency { get; set; }
    }
}
