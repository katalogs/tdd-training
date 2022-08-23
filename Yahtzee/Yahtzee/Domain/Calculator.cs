using System.Collections.Generic;
using System.Linq;
using Yahtzee.Exceptions;

namespace Yahtzee.Domain
{
    public class Calculator
    {
        public int CalculateScoreByCombination(int combination, List<int> dices)
        {
            if (dices.Count != 5)
                throw new HasNotFiveDicesException();

            return dices.Sum(x => x == combination ? combination : 0);
        }
    }
}