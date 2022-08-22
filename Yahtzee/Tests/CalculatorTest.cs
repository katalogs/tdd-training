using Xunit;

namespace Tests
{
    public class CalculatorTest
    {
        //5 dés + combinaison = total
        [Fact]
        public void Aces_with_five_1_should_return_5()
        {
            // But test : Renvoie de la bonne valeur du cas 5 dés de valeur 1

            // Arrange
            var calculator = new Calculator();

            // Act
            int combination = 1;

            int actual = calculator.GetTotal(combination, new int[] { 1, 1, 1, 1, 1 });

            // Assert
            Assert.Equal(5, actual);
        }
    }
}
