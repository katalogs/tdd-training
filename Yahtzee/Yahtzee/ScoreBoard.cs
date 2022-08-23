using System;
using System.Collections.Generic;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private bool Aces;

        private bool Twos;

        public int CalculateTotalBeforeBonus()
        {
            return 0;
        }

        public void AddCombination(int combination, List<int> dices)
        {
            if (combination == 1)
            {
                if (Aces)
                {
                    throw new SameCombinationTwiceException();
                }
                else
                {
                    Aces = true;
                }
            }
            else if ( combination == 2)
            {
                if (Twos)
                {
                    throw new SameCombinationTwiceException();
                }
                else
                {
                    Twos = true;
                }
            }
            
        }
    }
}