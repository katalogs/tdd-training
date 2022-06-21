using System;
using FluentAssertions;

using Xunit;

using Yahtzee;

namespace Tests
{
    public class YahtzeeBonusTests
    {
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
        [InlineData(Combination.ThreeOfAKind)]
        [InlineData(Combination.FourOfAKind)]
        [InlineData(Combination.FullHouse)]
        [InlineData(Combination.SmallStraight)]
        [InlineData(Combination.LargeStraight)]
        [InlineData(Combination.Chance)]
        public void Should_throw_an_exception_when_try_use_bonu_yahtzee_in_inappropriated_combination(Combination combination)
        {
            var game = new Game(new ScoreCalculator());

            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            Assert.Throws<InvalidOperationException>(() 
                => game.Score(combination, new DiceRoll(1, 1, 1, 1, 1)));
        }
        
        [Theory]
        [InlineData(Combination.Twos)]
        [InlineData(Combination.Threes)]
        [InlineData(Combination.Fours)]
        [InlineData(Combination.Fives)]
        [InlineData(Combination.Sixes)]
        [InlineData(Combination.ThreeOfAKind)]
        [InlineData(Combination.FourOfAKind)]
        [InlineData(Combination.FullHouse)]
        [InlineData(Combination.SmallStraight)]
        [InlineData(Combination.LargeStraight)]
        [InlineData(Combination.Chance)]
        public void Should_not_throw_exception(Combination combination)
        {
            var game = new Game(new ScoreCalculator());

            Action calculateGameScore = () => game.Score(combination, new DiceRoll(1, 1, 1, 1, 1));
            
            calculateGameScore.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_allow_any_lower_combination_for_bonus_yahtzee_when_appropriated_upper_section_combination_is_filled()
        {
            var game = new Game(new ScoreCalculator());

            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            game.Score(Combination.Aces, new DiceRoll(1, 2, 1, 2, 1));
            game.Score(Combination.SmallStraight, new DiceRoll(1, 1, 1, 1, 1));

            var expectedScore = 183;
            var score = game.GetScore();

            score.Should().Be(expectedScore);
        }
        
        [Fact]
        public void Should()
        {
            var game = new Game(new ScoreCalculator());

            game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6));
            game.Score(Combination.Aces, new DiceRoll(1, 2, 1, 2, 1));
            game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 2, 3, 4, 5));
            game.Score(Combination.FourOfAKind, new DiceRoll(1, 2, 3, 4, 5));
            game.Score(Combination.FullHouse, new DiceRoll(1, 1, 2, 1, 1));
            game.Score(Combination.SmallStraight, new DiceRoll(1, 1, 2, 1, 1));
            game.Score(Combination.LargeStraight, new DiceRoll(1, 1, 2, 1, 1));
            game.Score(Combination.Chance, new DiceRoll(1, 1, 2, 1, 1));
            game.Score(Combination.Twos, new DiceRoll(1, 1, 1, 1, 1));

            var expectedScore = 159;
            var score = game.GetScore();

            score.Should().Be(expectedScore);
        }
    }
}
