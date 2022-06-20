using System.Linq;
using System.Collections.Generic;
using Tests;
using System.Drawing;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        private static bool IsThreeOfAKind(IEnumerable<int> dice) =>
            ContainsIdenticalDice(dice, 3);

        private static bool IsFourOfAKind(IEnumerable<int> dice) =>
            ContainsIdenticalDice(dice, 4);

        private static bool IsFullHouse(IEnumerable<int> dice)
        {
            var groupBy = dice.GroupBy(x => x).ToList();
            return groupBy.Count == 1 || (groupBy.Count == 2 && groupBy.Max(x => x.Count()) == 3);
        }

        private static bool ContainsIdenticalDice(IEnumerable<int> dice, int count)
        {
            return dice.GroupBy(x => x).Max(x => x.Count()) >= count;
        }

        public int GetScore(IEnumerable<int> rolls, Combination combination)
        {
            return combination switch
            {
                Combination.FullHouse => IsFullHouse(rolls) ? 25 : 0,
                Combination.FourOfAKind => IsFourOfAKind(rolls) ? rolls.Sum() : 0,
                Combination.ThreeOfAKind => IsThreeOfAKind(rolls) ? rolls.Sum() : 0,
                _ => rolls.Where(x => x == (int)combination).Sum()
            };

        }
    }
}
