using System;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreEngineTests
    {
        [Fact]
        public void Should_throw_exception_if_value_less_than_1()
        {
            var result = Assert.Throws<ArgumentException>(() => ScoreEngine.GetScore(new[] { 1, 3, 0, 6, 6 }, Combination.Chance));
            Assert.Equal("Dice value should be between 1 and 6", result.Message);
        }

        [Fact]
        public void Should_throw_exception_if_value_more_than_6()
        {
            var result = Assert.Throws<ArgumentException>(() => ScoreEngine.GetScore(new[] { 1, 3, 1, 7, 6 }, Combination.Chance));
            Assert.Equal("Dice value should be between 1 and 6", result.Message);
        }

        [Fact]
        public void Should_throw_exception_if_number_of_dice_greater_than_5()
        {
            var result = Assert.Throws<ArgumentException>(() => ScoreEngine.GetScore(new[] { 1, 3, 1, 6, 6, 1 }, Combination.Chance));
            Assert.Equal("Dice count should be 5", result.Message);
        }

        [Fact]
        public void Should_throw_exception_if_number_of_dice_lower_than_5()
        {
            var result = Assert.Throws<ArgumentException>(() => ScoreEngine.GetScore(new[] { 1, 6, 6, 1 }, Combination.Chance));
            Assert.Equal("Dice count should be 5", result.Message);
        }

        [Fact]
        public void Should_throw_exception_roll_is_null()
        {
            var result = Assert.Throws<ArgumentNullException>(() => ScoreEngine.GetScore(null, Combination.Chance));
            Assert.Equal("roll", result.ParamName);
        }

        [Fact]
        public void Should_give_20_for_chance_and_13466_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 3, 4, 6, 6 }, Combination.Chance);
            Assert.Equal(20, actualScore);
        }

        [Fact]
        public void Should_give_18_for_chance_and_11466_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 4, 6, 6 }, Combination.Chance);
            Assert.Equal(18, actualScore);
        }

        [Fact]
        public void Should_give_2_for_ace_and_11466_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 4, 6, 6 }, Combination.Ace);
            Assert.Equal(2, actualScore);
        }

        [Fact]
        public void Should_give_0_for_ace_and_22466_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 2, 2, 4, 6, 6 }, Combination.Ace);
            Assert.Equal(0, actualScore);
        }

        [Fact]
        public void Should_give_5_for_ace_and_11111_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 1, 1, 1 }, Combination.Ace);
            Assert.Equal(5, actualScore);
        }

        [Fact]
        public void Should_give_2_for_two_and_11211_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 2, 1, 1 }, Combination.Two);
            Assert.Equal(2, actualScore);
        }

        [Fact]
        public void Should_give_0_for_two_and_11466_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 4, 6, 6 }, Combination.Two);
            Assert.Equal(0, actualScore);
        }

        [Fact]
        public void Should_give_3_for_three_and_11311_roll()
        {

            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 3, 1, 1 }, Combination.Three);
            Assert.Equal(3, actualScore);
        }

        [Fact]
        public void Should_give_0_for_three_and_11466_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 4, 6, 6 }, Combination.Three);
            Assert.Equal(0, actualScore);
        }

        [Fact]
        public void Should_give_4_for_four_and_11411_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 4, 1, 1 }, Combination.Four);
            Assert.Equal(4, actualScore);
        }

        [Fact]
        public void Should_give_5_for_five_and_11511_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 5, 1, 1 }, Combination.Five);
            Assert.Equal(5, actualScore);
        }

        [Fact]
        public void Should_give_6_for_six_and_11611_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 1, 1, 6, 1, 1 }, Combination.Six);
            Assert.Equal(6, actualScore);
        }

        [Fact]
        public void Should_give_0_for_Yahtzee_and_22221_roll()
        {
            var actualScore = ScoreEngine.GetScore(new[] { 2, 2, 2, 2, 1 }, Combination.Yahtzee);
            Assert.Equal(0, actualScore);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Should_give_50_for_Yahtzee_and_five_dice_with_same_value(int dice)
        {
            var actualScore = ScoreEngine.GetScore(new[] { dice, dice, dice, dice, dice }, Combination.Yahtzee);
            Assert.Equal(50, actualScore);
        }
    }
}
