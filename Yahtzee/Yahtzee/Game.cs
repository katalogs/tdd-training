using System.Collections.Generic;

namespace Yahtzee
{
    public class Game
    {
        private int score = 0;

        private Combination combination;

        public int GetUpperSectionTotal()
        {

            return combination is Combination.SmallStraight or Combination.LargeStraight ? 0 : score;
        }

        public void Score(Combination combination, DiceRoll diceRoll)
        {
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            this.combination = combination; 
            score += scoreCalculator.GetScore(diceRoll, combination);
        }
    }
}