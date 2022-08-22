using System.Linq;

namespace Tests
{
    public class Calculator
    {
        public int GetTotal(int combination, int[] dices)
        {
            var list = dices.ToList();
            return list.Count(x => x == 1);
        }
    }
}