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
        [InlineData(2, new [] {1, 3, 4, 6, 6 })]
        [InlineData(3, new [] {1, 1, 4, 6, 6 })]
        [InlineData(4, new [] {1, 1, 6, 6, 6 })]
        [InlineData(5, new [] {1, 1, 4, 6, 6 })]
        [InlineData(6, new [] {1, 1, 4, 5, 2 })]
        public void Should_return_zero_for_simple_combination_when_no_die_has_the_combination_value(int combination, IEnumerable<int> rolls)
        {
            // Act
            var score = _calculator.GetScore(rolls.ToList(), combination);

            // Assert
            Assert.Equal(0, score);
        }

        [Theory]
        [InlineData(1,new [] { 1, 3, 4, 6, 6 },1)]
        [InlineData(2,new [] { 1, 3, 4, 2, 2 },4)]
        [InlineData(3,new [] { 1, 3, 4, 2, 2 },3)]
        [InlineData(4,new [] { 1, 3, 4, 2, 2 },4)]
        [InlineData(5,new [] { 1, 3, 5, 5, 5 },15)]
        [InlineData(6,new [] { 1, 3, 6, 2, 6 },12)]
        public void Should_return_the_sum_of_dice_of_the_combination_value_for_upper_section_combinations(int combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange;

            // Act
            var score = _calculator.GetScore(rolls.ToList(), combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }

        [Theory]
        [InlineData(7,new [] { 1, 1, 1, 4, 5 },12)]
        [InlineData(7, new[] { 1, 1, 4, 4, 5 }, 0)]
        public void Should(int combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange

            // Act
            var score = _calculator.GetScore(rolls.ToList(), combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }
    }
}
