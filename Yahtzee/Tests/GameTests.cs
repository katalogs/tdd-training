using System;
using Xunit;
using Yahtzee;
using Moq;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void New_game_wait_for_player1()
        {
            Mock<IInput> input = new Mock<IInput>();
            Mock<IOutput> output = new Mock<IOutput>();

            Game game = new Game(input.Object, output.Object);
            game.Start();

            output.Verify(o => o.ShowMessage("Player 1 : go !"));
        }

        [Fact]
        public void First_player_should_be_able_to_roll_dices()
        {
            //Game game = new Game();
            //game.Input(GameAction);
            Assert.True(true);
            
        }
    }
}
