using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class DiceRoll
    {
        private readonly int[] _roll;
        private static readonly IEnumerable<IEnumerable<int>> SmallStraight = new[] { new[] { 1, 2, 3, 4 }, new[] { 5, 2, 3, 4 }, new[] { 3, 4, 5, 6 } };
        private static readonly IEnumerable<IEnumerable<int>> LargeStraight = new[] { new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 6 } };

        public DiceRoll(params int[] rolls)
        {
            if (rolls.Length != 5 || rolls.Any(d => d is <1 or >6))
                throw new ArgumentException();

            _roll = rolls;
        }

        public IEnumerable<int> GetRoll()
        {
            return _roll.ToList();
        }

        internal bool IsYahtzee()
        {
            return ContainsIdenticalDice(5);
        }

        private bool ContainsIdenticalDice( int count)
        {
            return _roll.GroupBy(x => x).Max(x => x.Count()) >= count;
        }

        internal bool IsSmallStraight() =>
            SmallStraight.Any(s => s.Intersect(_roll).Count() == 4) || IsYahtzee();

        internal bool IsLargeStraight() =>
            LargeStraight.Any(s => s.Intersect(_roll).Count() == 5) || IsYahtzee();

        internal bool IsFullHouse()
        {
            var groupBy = _roll.GroupBy(x => x).ToList();
            return groupBy.Count == 1 || (groupBy.Count == 2 && groupBy.Max(x => x.Count()) == 3);
        }

        internal bool IsFourOfAKind() =>
            ContainsIdenticalDice(4);

        internal bool IsThreeOfAKind() =>
            ContainsIdenticalDice(3);
    }
}
