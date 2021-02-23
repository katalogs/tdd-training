using System;
using Xunit;
using Yahtzee;
using Moq;

namespace Tests
{
    public class TurnTests
    {
        private readonly Mock<IDiceRoller> _diceRollerMock;
        private readonly Turn _turn;

        public TurnTests()
        {
            _diceRollerMock = new Mock<IDiceRoller>();
            _turn = new Turn(_diceRollerMock.Object);
        }

        [Fact]
        public void New_turn_should_roll_five_dices()
        {
            _diceRollerMock.Setup(mock => mock.Roll())
                .Returns(new int[] { 1, 1, 1, 1, 1 });
            _turn.RollDices();
            int[] roll = _turn.GetLastRoll();

            Assert.Equal(5, roll.Length);
        }

        [Fact]
        public void New_roll_Should_register_score_into_grid()
        {
            _diceRollerMock.Setup(mock => mock.Roll())
                .Returns(new int[] { 1, 1, 1, 1, 1 });
            _turn.RollDices();

            var grid = new ScoreGrid();
            _turn.RegisterScore(grid, Combination.Ace);

            var actualScore = grid.GetScore(Cell.Ace);

            Assert.Equal(5, actualScore);
        }

        [Fact]
        public void A_turn_should_have_only_three_rolls()
        {
            var expectedRoll = new[] { 1, 1, 1, 1, 1 };
            _diceRollerMock.Setup(mock => mock.Roll())
                .Returns(expectedRoll);
            _turn.RollDices();
            _turn.RollDices();
            _turn.RollDices();
            _diceRollerMock.Setup(mock => mock.Roll())
               .Returns(new[] { 1, 2, 1, 1, 1 });

            RunIgnoreException(() => _turn.RollDices());
            
            var roll = _turn.GetLastRoll();

            Assert.Equal(expectedRoll, roll);
        }

        [Fact]
        public void Rolling_dice_four_time_should_throw_an_exception()
        {
            _turn.RollDices();
            _turn.RollDices();
            _turn.RollDices();
            
            var exception = Assert.Throws<InvalidOperationException>(() => _turn.RollDices());
            
            Assert.Equal("Only three rolls allowed", exception.Message);
        }

        private static void RunIgnoreException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception)
            {
                //tout est bon
            }
        }
    }
}
