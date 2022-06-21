using FluentAssertions;

using Xunit;

using Yahtzee;

namespace Tests
{
    public class AcceptanceTests
    {
        [Fact]
        public void Should_return_36_when_game_is_done()
        {
            // Arrange
            var game = new Game();
            var expectedScore = 36;

            // Act
            game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 3, 4));
            game.Score(Combination.Twos, new DiceRoll(2, 3, 4, 2, 1));
            game.Score(Combination.Threes, new DiceRoll(5, 4, 1, 2, 1));
            game.Score(Combination.Fours, new DiceRoll(4, 4, 4, 2, 2));
            game.Score(Combination.Fives, new DiceRoll(1, 2, 3, 4, 5));
            game.Score(Combination.Sixes, new DiceRoll(6, 1, 3, 6, 2));

            game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5));
            game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));
            game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 4, 4));
            game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));
            game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));
            game.Score(Combination.Yahtzee, new DiceRoll(2, 2, 2, 2, 2));
            game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));
            var score = game.GetUpperSectionTotal();

            // Assert
            score.Should().Be(expectedScore);
        }
    }
}
