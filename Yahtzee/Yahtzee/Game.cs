using System.Collections.Generic;

namespace Yahtzee
{
    public class Game
    {
        private int score = 0;

        public int GetUpperSectionTotal()
        {
            return score;
        }

        public void Score(Combination combination, DiceRoll diceRoll)
        {
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            score += scoreCalculator.GetScore(diceRoll, combination);
        }
    }
}