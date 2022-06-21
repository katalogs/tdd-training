using System;
using FluentAssertions;

using Xunit;

using Yahtzee;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void Should_return_total_0_when_game_begins()
        {
            // Arrange
            var game = new Game(new ScoreCalculator());
            var expected = 0;

            // Act
            var score = game.GetUpperSectionTotal();

            // Assert
            score.Should().Be(expected);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5},1)]
        [InlineData(new int[] { 1, 1, 1, 1, 5},4)]
        [InlineData(new int[] { 2, 3, 3, 4, 5},0)]
        public void Should_return_expected_total_when_only_scores_for_combination_aces(int[] roll, int expected)
        {
            // Arrange
            var game = new Game(new ScoreCalculator());

            // Act
            game.Score(Combination.Aces, new DiceRoll(roll));
            var score = game.GetUpperSectionTotal();

            // Assert
            score.Should().Be(expected);
        }

        [Fact]
        public void Should_return_zero_in_the_upper_section_total_if_the_chosen_combination_was_little_straight()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 0;
            
            game.Score(Combination.SmallStraight, new DiceRoll(1,2,3,4,5));
            var score = game.GetUpperSectionTotal();

            score.Should().Be(expectedScore);

        }

        [Fact]
        public void Should_return_zero_in_the_upper_section_total_if_the_combinations_are_from_lower_section()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 1;

            game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5));
            game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));
            game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 4, 4));
            game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));
            game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));
            game.Score(Combination.Yahtzee, new DiceRoll(2, 2, 2, 2, 2));
            game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));
            game.Score(Combination.Aces, new DiceRoll(2, 2, 1, 2, 2));
            var score = game.GetUpperSectionTotal();

            score.Should().Be(expectedScore);
        }

        [Fact]
        public void Should_return_100_when_one_bonus_occured()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 100;

            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 1, 1));
            var score = game.GetYahtzeeBonus();

            score.Should().Be(expectedScore);
        }

        [Fact]
        public void Should_return_0_when_0_yahtzee_occured()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 0;

            game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 1, 1));
            var score = game.GetYahtzeeBonus();

            score.Should().Be(expectedScore);
        }

        [Fact]
        public void Should_return_0_when_wrong_yahtzee_occured()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 0;

            game.Score(Combination.Yahtzee, new DiceRoll(5, 6, 6, 6, 6));
            game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 1, 1));
            var score = game.GetYahtzeeBonus();

            score.Should().Be(expectedScore);
        }

        [Fact]
        public void Should_return_sum_yahtzee_bonus()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 200;

            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 1, 1));
            game.Score(Combination.Threes, new DiceRoll(3, 3, 3, 3, 3));
            var score = game.GetYahtzeeBonus();

            score.Should().Be(expectedScore);
        }
        
        [Fact]
        public void Should_not_add_yahtzee_bonus_before_yahtzee_combination_is_filled()
        {
            var game = new Game(new ScoreCalculator());
            var expectedScore = 100;

            game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 1, 1));
            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            game.Score(Combination.Threes, new DiceRoll(3, 3, 3, 3, 3));
            var score = game.GetYahtzeeBonus();

            score.Should().Be(expectedScore);
        }
        
        [Theory]
        [InlineData(Combination.Twos)]
        [InlineData(Combination.Threes)]
        [InlineData(Combination.Fours)]
        [InlineData(Combination.Fives)]
        [InlineData(Combination.Sixes)]
        public void Should(Combination combination)
        {
            var game = new Game(new ScoreCalculator());

            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            Assert.Throws<InvalidOperationException>(() 
                => game.Score(combination, new DiceRoll(1, 1, 1, 1, 1)));
        }
    }
}
