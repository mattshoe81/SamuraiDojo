using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC.Interfaces.Test
{
    public interface INestedParent
    {
        IParent ParentNested { get; set; }
    }
}
