using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        public int GetScore(DiceRoll diceRoll, Combination combination)
        {
            var rolls = diceRoll.GetRoll();
            return combination switch
            {
                Combination.Yahtzee => diceRoll.IsYahtzee() ? 50 : 0,
                Combination.Chance => rolls.Sum(),
                Combination.SmallStraight => diceRoll.IsSmallStraight() ? 30 : 0,
                Combination.LargeStraight => diceRoll.IsLargeStraight() ? 40 : 0,
                Combination.FullHouse => diceRoll.IsFullHouse() ? 25 : 0,
                Combination.FourOfAKind => diceRoll.IsFourOfAKind() ? rolls.Sum() : 0,
                Combination.ThreeOfAKind => diceRoll.IsThreeOfAKind() ? rolls.Sum() : 0,
                _ => rolls.Where(x => x == (int)combination).Sum()
            };
        }
    }
}
 