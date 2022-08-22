using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Calculator
    {
        public int GetTotal(int combination, List<int> dices)
        {
            return dices.Count(x => x == 1);
        }
    }
}