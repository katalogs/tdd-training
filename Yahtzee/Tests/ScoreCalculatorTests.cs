using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreCalculatorTests
    {
        private readonly ScoreCalculator _calculator = new ScoreCalculator();

        [Theory]
        [InlineData(1, new [] {2, 3, 4, 6, 6 })]
        public void Should_return_zero_for_simple_combination_when_no_die_has_the_combination_value(int combination, IEnumerable<int> rolls)
        {
            // Act
            var score = _calculator.GetScore(rolls.ToList(), combination);

            // Assert
            Assert.Equal(0, score);
        }

        [Fact]
        public void Should_return_number_of_one_when_dice_has_ones()
        {
            // Arrange
            var dice = new List<int> { 1, 3, 4, 6, 6 };

            // Act
            var score = _calculator.GetScore(dice, 1);

            // Assert
            Assert.Equal(1, score);
        }

        [Fact]
        public void Should_return_sum_of_two_when_containing_only_one_two()
        {
            // Arrange
            var dice = new List<int> { 1, 2, 4, 6, 6 };

            // Act
            var score = _calculator.GetScore(dice, 2);

            // Assert
            Assert.Equal(2, score);
        }
    }
}
