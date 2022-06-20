using System.Linq;
using System.Collections.Generic;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        public int GetScore(List<int> dice, int combination)
        {
            if (combination == 7)
            {
                if (IsThreeOfAKind(dice))
                {
                    return 12;
                }
                return 0;
            }

            return dice.Where(x => x == combination).Sum();
        }

        private static bool IsThreeOfAKind(List<int> dice) =>
            dice.GroupBy(x => x).Max(x => x.Count()) == 3;
    }
}
