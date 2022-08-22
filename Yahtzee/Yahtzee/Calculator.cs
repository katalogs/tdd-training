using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Calculator
    {
        public int GetTotal(int combination, List<int> dices)
        {
            if (dices.Count > 5)
                throw new MoreThanFiveDicesException();

            return dices.Count(x => x == 1);
        }
    }
}