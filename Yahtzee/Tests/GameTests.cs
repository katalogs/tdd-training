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
            var game = new Game();
            var expected = 0;

            // Act
            var score = game.GetUpperSectionTotal();

            // Assert
            score.Should().Be(expected);
        }

        [Fact]
        public void Should_return_total_1_when_aces_scores_1_point()
        {
            // Arrange
            var game = new Game();
            var expected = 1;

            // Act
            game.Score(Combination.Aces, new DiceRoll(1, 2, 3, 4, 5));
            var score = game.GetUpperSectionTotal();

            // Assert
            score.Should().Be(expected);
        }
    }

    internal class Game
    {
        public Game()
        {
        }

        public int GetUpperSectionTotal()
        {
            return score;
        }

        public void Score(Combination aces, DiceRoll diceRoll)
        {
            score += 1;
        }

        private int score = 0;
    }
}
