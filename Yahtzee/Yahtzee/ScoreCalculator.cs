using System;
using System.Collections.Generic;
using System.Linq;
using Tests;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        private static readonly IEnumerable<IEnumerable<int>> _smallStraight = new[] { new[] { 1, 2, 3, 4 }, new[] { 5, 2, 3, 4 }, new[] { 3, 4, 5, 6 } };

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

        private static bool IsSmallStraight(IEnumerable<int> dice) =>
            _smallStraight.Any(s => s.Intersect(dice).Count() == 4) || dice.GroupBy(x => x).Count() == 1;

        public int GetScore(IEnumerable<int> rolls, Combination combination)
        {
            return combination switch
            {
                Combination.SmallStraight => IsSmallStraight(rolls) ? 30 : 0,
                Combination.FullHouse => IsFullHouse(rolls) ? 25 : 0,
                Combination.FourOfAKind => IsFourOfAKind(rolls) ? rolls.Sum() : 0,
                Combination.ThreeOfAKind => IsThreeOfAKind(rolls) ? rolls.Sum() : 0,
                _ => rolls.Where(x => x == (int)combination).Sum()
            };

        }
    }
}
