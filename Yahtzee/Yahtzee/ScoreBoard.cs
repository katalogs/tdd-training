using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly bool[] _combinationAlreadySet = new bool[6]; // set by order
        private readonly int[] _combinationsScore = new int[6];

        public int CalculateTotalBeforeBonus()
        {
            return _combinationsScore.Sum();
        }

        public void AddCombination(int combination, List<int> dices)
        {
            if (_combinationAlreadySet[combination - 1])
            {
                throw new SameCombinationTwiceException();
            }

            _combinationAlreadySet[combination - 1] = true;

            Calculator calculator = new Calculator();
            _combinationsScore[combination - 1] = calculator.CalculateScoreByCombination(combination, dices);
        }
    }
}