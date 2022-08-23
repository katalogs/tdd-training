using System.Collections.Generic;
using System.Linq;
using Yahtzee.Exceptions;

namespace Yahtzee.Domain
{
    public class ScoreBoard
    {
        private readonly bool[] _combinationAlreadySet = new bool[6]; // set by order
        private readonly int[] _combinationsScore = new int[6];
        private readonly Calculator _calculator = new();

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
            _combinationsScore[combination - 1] = _calculator.CalculateScoreByCombination(combination, dices);
        }
    }
}