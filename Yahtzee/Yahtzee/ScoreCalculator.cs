using System.Linq;
using System.Collections.Generic;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        public int GetScore(List<int> dice, int combination)
        {
            return dice.Count(x => x == combination);
        }
    }
}
