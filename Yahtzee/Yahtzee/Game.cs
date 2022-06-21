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

        public int GetUpperSectionTotal()
        {

            return score;
        }

        public void Score(Combination combination, DiceRoll diceRoll)
        {
            ScoreCalculator scoreCalculator = new ScoreCalculator();

            if (IsUpperSectionCombination(combination))
            {
                score += scoreCalculator.GetScore(diceRoll, combination);
            }
        }

        private static bool IsUpperSectionCombination(Combination combination)
        {
            return UpperCombinations.Any(x => x == combination);
        }
    }
}