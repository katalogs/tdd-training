using System;
using FluentAssertions;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class DiceRollTests
    {
        [Fact]
        public void Should_return_sum_of_dice_when_chance_combination_invoked()
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll(1, 2, 3, 4, 5, 6));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 7})]
        [InlineData(new int[] { 0, 2, 3, 4, 5})]
        public void Should_throw_ArgumentException_when_die_value_invalid(int[] roll)
        {
            Assert.Throws<ArgumentException>(() => new DiceRoll(roll));
        }

        [Fact]
        public void Should_provide_dice_list()
        {
            // Arrange
            var expected = new[] { 1, 2, 3, 4, 5 };
            var diceRoll = new DiceRoll(1, 2, 3, 4, 5);

            // Act
            var roll = diceRoll.GetRoll();

            // Assert
            roll.Should().BeEquivalentTo(expected);
        }
    }

}