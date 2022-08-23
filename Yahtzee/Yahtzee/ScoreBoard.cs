using System.Collections.Generic;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly bool[] _combinationAlreadySet = new bool[6]; // set by order

        public int CalculateTotalBeforeBonus()
        {
            return 0;
        }

        public void AddCombination(int combination, List<int> dices)
        {
            if (_combinationAlreadySet[combination - 1])
            {
                throw new SameCombinationTwiceException();
            }

            _combinationAlreadySet[combination - 1] = true;
        }
    }
}