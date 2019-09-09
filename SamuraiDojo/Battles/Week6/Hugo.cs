﻿using System.Collections.Generic;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week6
{
    [WrittenBy(Samurai.Hugo)]
    public class Hugo : SuperfluousSansLoop
    {
        private Stack<int> numbers = new Stack<int>();

        public override string Print1toNWithoutLoops(int n)
        {
            PushNumbers(n);
            return string.Join(", ", numbers);
        }

        private void PushNumbers(int n)
        {
            if (n >= 0)
            {
                numbers.Push(n);
                n--;
                PushNumbers(n);
            }
        }

    }
}
