using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class CalculatorTest
    {
        private List<int> _dices;



        //5 dés + combinaison = total
        [Fact]
        public void Aces_with_five_1_should_return_5()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 1, 1, 1, 1, 1 };

            // Act
            var actual = calculator.GetTotal(1, _dices);

            // Assert
            Assert.Equal(5, actual);
        }

        [Fact]
        public void Aces_with_three_1_should_return_3()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 1, 1, 1, 2, 5 };

            // Act
            var actual = calculator.GetTotal(1, _dices);

            // Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Aces_with_zero_1_should_return_zero()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 4, 3, 2, 2, 5 };

            // Act
            var actual = calculator.GetTotal(1, _dices);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Calculator_with_more_than_5_dices_should_throw_exception()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 4, 3, 2, 2, 5, 3, 5 };

            // Act
            var actual = Assert.Throws<HasNotFiveDicesException>(() => calculator.GetTotal(1, _dices));

            // Assert
            Assert.IsType<HasNotFiveDicesException>(actual);
        }

        [Fact]
        public void Calculator_with_less_than_5_dices_should_throw_exception()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 4, 3, 2 };

            // Assert
            Assert.Throws<HasNotFiveDicesException>(() => calculator.GetTotal(1, _dices));
        }

        [Fact]
        public void Twos_with_five_2_should_return_10()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 2, 2, 2, 2, 2 };

            // Act
            var actual = calculator.GetTotal(2, _dices);

            // Assert
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Twos_with_zeros_2_should_return_0()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 3, 4, 5, 3, 4 };

            // Act
            var actual = calculator.GetTotal(2, _dices);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Twos_with_three_2_should_return_6()
        {
            // Arrange
            var calculator = new Calculator();
            _dices = new List<int> { 2, 2, 2, 3, 4 };

            // Act
            var actual = calculator.GetTotal(2, _dices);

            // Assert
            Assert.Equal(6, actual);
        }

    }
}