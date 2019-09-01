using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.Interfaces.Test;

namespace SamuraiDojo.Test.IoC.Models
{
    public class NestedParent : INestedParent
    {
        public IParent ParentNested { get; set; }

        public NestedParent(IParent parent)
        {
            ParentNested = parent;
        }
    }
}
