using System.Linq;
using System.Collections.Generic;
using Tests;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        public int GetScore(IEnumerable<int> dice, int combination)
        {
            if (combination == 7)
            {
                return IsThreeOfAKind(dice) ? dice.Sum() : 0;
            }

            return dice.Where(x => x == combination).Sum();
        }

        private static bool IsThreeOfAKind(IEnumerable<int> dice) =>
            dice.GroupBy(x => x).Max(x => x.Count()) == 3;

        public int GetScore(IEnumerable<int> rolls, Combination combination)
        {
            return GetScore(rolls, (int)combination);
        }
    }
}
