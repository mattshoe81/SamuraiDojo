using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week4;

namespace SamuraiDojo.Test.Week4
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : PalindromaniaTest
    {
        protected override Palindromania GetInstance()
        {
            return new SamuraiDojo.Battles.Week4.MattShoe();
        }
    }
}
