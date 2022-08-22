using System;
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
            var actual = Assert.Throws<MoreThanFiveDicesException>(() => calculator.GetTotal(1, _dices));

            // Assert
            Assert.IsType<MoreThanFiveDicesException>(actual);
        }
    }
}
