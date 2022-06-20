using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class DiceRoll
    {
        private readonly int[] _roll;

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
    }
}
