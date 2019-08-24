using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Test
{
    public abstract class DojoTest<T>
    {
        public abstract void Benchmark();

        protected abstract T GetInstance();

    }
}
