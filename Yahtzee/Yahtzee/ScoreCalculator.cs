using System.Linq;
using System.Collections.Generic;
using Tests;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        private static bool IsThreeOfAKind(IEnumerable<int> dice) =>
            ContainesIdenticalDice(dice, 3);

        private static bool IsFourOfAKind(IEnumerable<int> dice) =>
            ContainesIdenticalDice(dice, 4);

        private static bool ContainesIdenticalDice(IEnumerable<int> dice, int count)
        {
            return dice.GroupBy(x => x).Max(x => x.Count()) >= count;
        }

        public int GetScore(IEnumerable<int> rolls, Combination combination)
        {
            if (combination == Combination.FourOfAKind)
            {
                return IsFourOfAKind(rolls) ? rolls.Sum() : 0;
            }

            if (combination == Combination.ThreeOfAKind)
            {
                return IsThreeOfAKind(rolls) ? rolls.Sum() : 0;
            }
            return rolls.Where(x => x == (int)combination).Sum();
        }
    }
}
