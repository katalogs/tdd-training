using Xunit;
using Yahtzee;

namespace Tests
{
    public class DiceTest
    {
        [Fact]
        public void dice_should_roll_random_number()
        {
            // Arrange
            var dice = new Dice();

            // Act
            int actual = dice.Roll();

            // Assert
            Assert.True(actual > 0 && actual < 7);
        }
    }
}
