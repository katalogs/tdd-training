using System;
using System.Linq;
using System.Collections.Generic;

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

        [Fact]
        public void Should()
        {
            // Arrange
            var expected = new[] { 1, 2, 3, 4, 5 };
            var diceRoll = new DiceRoll(1, 2, 3, 4, 5);

            // Act
            var roll = diceRoll.GetRoll();

            // Assert
            Assert.True(expected.Intersect(roll).Count() == 5);
        }
    }

    public class DiceRoll
    {
        private readonly int[] _roll;

        public DiceRoll(params int[] rolls)
        {
            if (rolls.Length != 5)
                throw new ArgumentException();

            _roll = rolls;
        }

        public IEnumerable<int> GetRoll()
        {
            return _roll.ToList();
        }
    }
}