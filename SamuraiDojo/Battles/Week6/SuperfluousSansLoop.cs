using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week6
{
    [Sensei(Samurai.MATT_SHOE)]
    [Battle("9/16/19", "Superfluous Sans Loop", typeof(SuperfluousSansLoop))]
    public abstract class SuperfluousSansLoop
    {
        /// <summary>
        /// Given a positive integer 'n':
        /// Without using any loops (which excludes Linq), build a string such that its value
        /// is "0, 1, 2, ... , n", where n is the value of the input parameter.
        /// 
        /// Constraints:
        ///     1. n will always be a positive integer (0 is positive)
        ///     2. You cannot use any loops. That means no for, foreach, or while statements
        ///     3. You cannot use Linq, since Linq uses loops
        ///     
        /// Notes:
        ///     1. Memory efficiency will likely be the only optimizable factor in this puzzle   
        ///     1. Your control over time efficiency is somewhat hampered by the constraints
        ///     
        /// Examples:
        ///     n=1 => "0, 1"
        ///     n=5 => "0, 1, 2, 3, 4, 5"
        ///     n=0 => "0"
        ///     
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public abstract string Print1toNWithoutLoops(int n);
    }
}
