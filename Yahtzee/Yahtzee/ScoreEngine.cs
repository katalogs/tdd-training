using System;
using System.Linq;

namespace Yahtzee
{
    public static class ScoreEngine
    {
        public static int GetScore(int[] roll, Combination combination)
        {
            ValidateRoll(roll);

            switch (combination)
            {
                case Combination.Ace:
                    return SumOnly(roll, 1);
                case Combination.Two:
                    return SumOnly(roll, 2);
                case Combination.Three:
                    return SumOnly(roll, 3);
                case Combination.Four:
                    return SumOnly(roll, 4);
                case Combination.Five:
                    return SumOnly(roll, 5);
                case Combination.Six:
                    return SumOnly(roll, 6);
                case Combination.Yahtzee:
                    return roll.Distinct().Count() == 1 ? 50 : 0;
                default:
                    return roll.Sum();
            }
        }

        private static int SumOnly(int[] roll, int value)
        {
            return roll.Count(d => d == value) * value;
        }

        private static void ValidateRoll(int[] roll)
        {
            if (roll == null) throw new ArgumentNullException(nameof(roll));
            if (roll.Length != 5) throw new ArgumentException("Dice count should be 5");
            if (roll.Any(d => d > 6 || d < 1))
            {
                throw new ArgumentException("Dice value should be between 1 and 6");
            }
        }
    }
}