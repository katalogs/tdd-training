using System;
using System.Collections.Generic;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private int _count = 0;
        public int CalculateTotalBeforeBonus()
        {
            return 0;
        }

        public void AddCombination(int combination, List<int> dices)
        {
            if (_count != 0 && combination == 1)
                throw new SameCombinationTwiceException();
            _count++;
        }
    }
}