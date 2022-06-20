using System.Collections.Generic;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreCalculatorTests
    {
        private readonly ScoreCalculator _calculator = new ScoreCalculator();

        [Fact]
        public void Should_return_zero_for_combination_aces_when_no_die_has_value_one()
        {
            // Arrange
            var dice = new List<int> { 2, 3, 4, 6, 6 };

            // Act
            var score = _calculator.GetScore(dice, 1);

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
    }
}
