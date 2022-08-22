using Xunit;

namespace Tests
{
    public class CalculatorTest
    {
        //5 dés + combinaison = total
        [Fact]
        public void Aces_with_five_1_should_return_5()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.GetTotal(1, new[] { 1, 1, 1, 1, 1 });

            // Assert
            Assert.Equal(5, actual);
        }
        
        [Fact]
        public void Aces_with_three_1_should_return_3()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.GetTotal(1, new[] { 1, 1, 1, 2, 5 });

            // Assert
            Assert.Equal(3, actual);
        }
    }
}
