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
                Combination.Yahtzee when diceRoll.IsYahtzee() => 50,
                Combination.Chance => rolls.Sum(),
                Combination.SmallStraight when diceRoll.IsSmallStraight() => 30,
                Combination.LargeStraight when diceRoll.IsLargeStraight() => 40,
                Combination.FullHouse when diceRoll.IsFullHouse() => 25,
                Combination.FourOfAKind when diceRoll.IsFourOfAKind() => rolls.Sum(),
                Combination.ThreeOfAKind when diceRoll.IsThreeOfAKind() => rolls.Sum(),
                _ when (int)combination >= (int)Combination.Aces && (int)combination <= (int)Combination.Sixes 
                    => rolls.Where(x => x == (int)combination).Sum(),
                _ => 0
            };
        }
    }
}
 