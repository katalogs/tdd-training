using FluentAssertions;

using Xunit;

using Yahtzee;

namespace Tests
{
    public class AcceptanceTests
    {
        private readonly Game _game = new Game(new ScoreCalculator());

        [Fact]
        public void Should_return_36_when_game_is_done()
        {
            // Arrange
            var expectedScore = 36;

            // Act
            _game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 3, 4));
            _game.Score(Combination.Twos, new DiceRoll(2, 3, 4, 2, 1));
            _game.Score(Combination.Threes, new DiceRoll(5, 4, 1, 2, 1));
            _game.Score(Combination.Fours, new DiceRoll(4, 4, 4, 2, 2));
            _game.Score(Combination.Fives, new DiceRoll(1, 2, 3, 4, 5));
            _game.Score(Combination.Sixes, new DiceRoll(6, 1, 3, 6, 2));

            _game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5));
            _game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));
            _game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 4, 4));
            _game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));
            _game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));
            _game.Score(Combination.Yahtzee, new DiceRoll(2, 2, 2, 2, 2));
            _game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));
            var score = _game.GetUpperSectionTotal();

            // Assert
            score.Should().Be(expectedScore);
        }
        
        [Fact]
        public void Should_return_0_when_total_upper_section_is_lower_than_63()
        {
            // Arrange
            var expectedBonus = 0;

            // Act
            _game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 3, 4));
            _game.Score(Combination.Twos, new DiceRoll(2, 3, 4, 2, 1));
            _game.Score(Combination.Threes, new DiceRoll(5, 4, 1, 2, 1));
            _game.Score(Combination.Fours, new DiceRoll(4, 4, 4, 2, 2));
            _game.Score(Combination.Fives, new DiceRoll(1, 2, 3, 4, 5));
            _game.Score(Combination.Sixes, new DiceRoll(6, 1, 3, 6, 2));

            _game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5));
            _game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));
            _game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 4, 4));
            _game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));
            _game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));
            _game.Score(Combination.Yahtzee, new DiceRoll(2, 2, 2, 2, 2));
            _game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));
            var score = _game.GetUpperSectionBonus();

            // Assert
            score.Should().Be(expectedBonus);
        }
        
        [Fact]
        public void Should_return_35_when_total_upper_section_is_equal_to_63()
        {
            // Arrange
            var expectedBonus = 35;

            // Act
            _game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 3, 4));
            _game.Score(Combination.Twos, new DiceRoll(2, 2, 4, 2, 1));
            _game.Score(Combination.Threes, new DiceRoll(3, 3, 3 , 2, 1));
            _game.Score(Combination.Fours, new DiceRoll(4, 4, 4, 2, 2));
            _game.Score(Combination.Fives, new DiceRoll(5, 5, 5, 4, 4));
            _game.Score(Combination.Sixes, new DiceRoll(6, 6, 6, 5, 2));

            _game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5));
            _game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));
            _game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 4, 4));
            _game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));
            _game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));
            _game.Score(Combination.Yahtzee, new DiceRoll(2, 2, 2, 2, 2));
            _game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));
            var score = _game.GetUpperSectionBonus();

            // Assert
            score.Should().Be(expectedBonus);
        }
        
        [Fact]
        public void Should_return_35_when_total_upper_section_is_greater_than_to_63()
        {
            // Arrange
            var expectedBonus = 35;

            // Act
            _game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 3, 4));
            _game.Score(Combination.Twos, new DiceRoll(2, 2, 4, 2, 1));
            _game.Score(Combination.Threes, new DiceRoll(3, 3, 3 , 2, 1));
            _game.Score(Combination.Fours, new DiceRoll(4, 4, 4, 2, 2));
            _game.Score(Combination.Fives, new DiceRoll(5, 5, 5, 4, 4));
            _game.Score(Combination.Sixes, new DiceRoll(6, 6, 6, 5, 6));

            _game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5));
            _game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));
            _game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 4, 4));
            _game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));
            _game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));
            _game.Score(Combination.Yahtzee, new DiceRoll(2, 2, 2, 2, 2));
            _game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));
            var score = _game.GetUpperSectionBonus();

            // Assert
            score.Should().Be(expectedBonus);
        }

        [Fact]
        public void Should()
        {
            // Arrange
            var expectedScore = 381;

            // Act
            _game.Score(Combination.Aces, new DiceRoll(1, 1, 1, 1, 1)); //5
            _game.Score(Combination.Yahtzee, new DiceRoll(6, 6, 6, 6, 6)); //50
            _game.Score(Combination.Twos, new DiceRoll(2, 2, 4, 2, 1)); //6
            _game.Score(Combination.Threes, new DiceRoll(3, 3, 3, 2, 1));//9
            _game.Score(Combination.Fours, new DiceRoll(4, 4, 4, 2, 2));//12
            _game.Score(Combination.Fives, new DiceRoll(5, 5, 5, 4, 4));//15
            _game.Score(Combination.Sixes, new DiceRoll(6, 6, 6, 5, 6));//24
            // bonus : 35


            _game.Score(Combination.ThreeOfAKind, new DiceRoll(1, 1, 1, 4, 5)); //12
            _game.Score(Combination.FourOfAKind, new DiceRoll(1, 1, 1, 1, 5));  //9
            _game.Score(Combination.FullHouse, new DiceRoll(2, 2, 2, 2, 2));    //25+100
            _game.Score(Combination.SmallStraight, new DiceRoll(1, 2, 3, 4, 6));//30
            _game.Score(Combination.LargeStraight, new DiceRoll(1, 2, 3, 4, 5));//40
            _game.Score(Combination.Chance, new DiceRoll(2, 2, 1, 2, 2));   //9


            var score = _game.GetScore();

            // Assert
            score.Should().Be(expectedScore);
        }
    }
}
