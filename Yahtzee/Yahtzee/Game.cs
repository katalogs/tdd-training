using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Game
    {
        private static readonly IEnumerable<Combination> UpperCombinations = new[] { 
            Combination.Aces, Combination.Twos, Combination.Threes,
            Combination.Fours, Combination.Fives, Combination.Sixes };
        private int score = 0;
        private ScoreCalculator _scoreCalculator;

        public Game(ScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
        }

        public int GetUpperSectionTotal()
        {
            return score;
        }

        public void Score(Combination combination, DiceRoll diceRoll)
        {
            if (IsUpperSectionCombination(combination))
            {
                score += _scoreCalculator.GetScore(diceRoll, combination);
            }
        }

        private static bool IsUpperSectionCombination(Combination combination)
        {
            return UpperCombinations.Any(x => x == combination);
        }

        public int GetUpperSectionBonus()
        {
            throw new System.NotImplementedException();
        }
    }
}