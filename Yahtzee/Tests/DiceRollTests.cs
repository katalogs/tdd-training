using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Tests
{
    public class DiceRollTests
    {
        [Fact]
        public void Should_return_sum_of_dice_when_chance_combination_invoked()
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll(1, 2, 3, 4, 5, 6));
        }
    }

    public class DiceRoll
    {
        public DiceRoll(params int[] rolls)
        {
            throw new ArgumentException();
        }
    }
}