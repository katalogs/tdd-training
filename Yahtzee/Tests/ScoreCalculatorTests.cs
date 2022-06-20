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
        [InlineData(Combination.Aces, new [] {2, 3, 4, 6, 6 })]
        [InlineData(Combination.Twos, new [] {1, 3, 4, 6, 6 })]
        [InlineData(Combination.Threes, new [] {1, 1, 4, 6, 6 })]
        [InlineData(Combination.Fours, new [] {1, 1, 6, 6, 6 })]
        [InlineData(Combination.Fives, new [] {1, 1, 4, 6, 6 })]
        [InlineData(Combination.Sixes, new [] {1, 1, 4, 5, 2 })]
        public void Should_return_zero_for_simple_combination_when_no_die_has_the_combination_value(Combination combination, IEnumerable<int> rolls)
        {
            // Act
            var score = _calculator.GetScore(rolls, combination);

            // Assert
            Assert.Equal(0, score);
        }

        [Theory]
        [InlineData(Combination.Aces,new [] { 1, 3, 4, 6, 6 },1)]
        [InlineData(Combination.Twos,new [] { 1, 3, 4, 2, 2 },4)]
        [InlineData(Combination.Threes,new [] { 1, 3, 4, 2, 2 },3)]
        [InlineData(Combination.Fours,new [] { 1, 3, 4, 2, 2 },4)]
        [InlineData(Combination.Fives,new [] { 1, 3, 5, 5, 5 },15)]
        [InlineData(Combination.Sixes,new [] { 1, 3, 6, 2, 6 },12)]
        public void Should_return_the_sum_of_dice_of_the_combination_value_for_upper_section_combinations(Combination combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange;

            // Act
            var score = _calculator.GetScore(rolls, combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }
        
        [Theory]
        [InlineData(Combination.ThreeOfAKind,new [] { 1, 1, 1, 4, 5 },12)]
        [InlineData(Combination.ThreeOfAKind, new[] { 1, 1, 4, 4, 5 }, 0)]
        [InlineData(Combination.ThreeOfAKind, new[] { 2, 2, 2, 4, 5 }, 15)]
        [InlineData(Combination.ThreeOfAKind, new[] { 2, 2, 2, 2, 5 }, 13)]
        public void Should_return_the_sum_of_dice_with_three_of_a_kind(Combination combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange

            // Act
            var score = _calculator.GetScore(rolls, combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }

        [Theory]
        [InlineData(Combination.FourOfAKind, new[] { 1, 1, 1, 1, 5 }, 9)]
        [InlineData(Combination.FourOfAKind, new[] { 1, 1, 2, 1, 5 }, 0)]
        [InlineData(Combination.FourOfAKind, new[] { 1, 1, 1, 1, 1 }, 5)]
        public void Should_return_the_sum_of_dice_with_four_of_a_kind(Combination combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange

            // Act
            var score = _calculator.GetScore(rolls, combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }

        [Theory]
        [InlineData(Combination.FullHouse, new[] { 1, 1, 1, 2, 2 }, 25)]
        [InlineData(Combination.FullHouse, new[] { 1, 1, 5, 2, 2 }, 0)]
        [InlineData(Combination.FullHouse, new[] { 1, 1, 1, 1, 3 }, 0)]
        [InlineData(Combination.FullHouse, new[] { 1, 1, 1, 1, 1 }, 25)]

        public void Should_return_twenty_five_when_dice_represents_full_house(Combination combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange

            // Act
            var score = _calculator.GetScore(rolls, combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }

        [Theory]
        [InlineData(Combination.SmallStraight, new[] { 1, 2, 3 ,4 ,4 }, 30)]
        [InlineData(Combination.SmallStraight, new[] { 1, 2, 1 ,4 ,4 }, 0)]
        [InlineData(Combination.SmallStraight, new[] { 1, 2, 5 ,4 ,5 }, 0)]
        [InlineData(Combination.SmallStraight, new[] { 5, 2, 3 ,4 ,5 }, 30)]
        [InlineData(Combination.SmallStraight, new[] { 5, 6, 3 ,4 ,5 }, 30)]

        public void Should_return_thirty_when_dice_represents_small_straight(Combination combination, IEnumerable<int> rolls, int expectedScore)
        {
            // Arrange

            // Act
            var score = _calculator.GetScore(rolls, combination);

            // Assert
            Assert.Equal(expectedScore, score);
        }
    }
}
