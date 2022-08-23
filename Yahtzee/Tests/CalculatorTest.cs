using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class CalculatorTest
    {
        private List<int> _dices;

        [Theory]
        [MemberData(nameof(DataCombinationUpperSectionSuccessCases))]
        public void GetTotalSuccess(List<int> dices, int expected, int combination)
        {
            // Arrange
            var calculator = new Calculator(); 

            // Act
            var actual = calculator.GetTotal(combination, dices);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(DataCombinationUpperSectionThrowException))]
        public void Calculator_with_not_5_dices_should_throw_exception(List<int> dices)
        {
            // Arrange
            var calculator = new Calculator();

            // Act & Assert
            Assert.Throws<HasNotFiveDicesException>(() => calculator.GetTotal(1, dices));
        } 

        public static List<object[]> DataCombinationUpperSectionSuccessCases()
        {
            return new List<object[]> {
                new object[] { new List<int> { 1, 1, 1, 1, 1 }, 5, 1 },
                new object[] { new List<int> { 2, 2, 2, 2, 2 }, 10, 2 },
                new object[] { new List<int> { 3, 3, 3, 3, 3 }, 15, 3 },
                new object[] { new List<int> { 4, 4, 4, 4, 4 }, 20, 4 },
                new object[] { new List<int> { 5, 5, 5, 5, 5 }, 25, 5 },
                new object[] { new List<int> { 6, 6, 6, 6, 6 }, 30, 6 },
                new object[] { new List<int> { 2, 2, 2, 3, 4 }, 6, 2 },
                new object[] { new List<int> { 3, 4, 5, 3, 4 }, 0, 2 },
                new object[] { new List<int> { 4, 3, 2, 2, 5 }, 0, 1 },
                new object[] { new List<int> { 1, 1, 1, 2, 5 }, 3, 1 }
            };
        }

        public static List<object[]> DataCombinationUpperSectionThrowException()
        {
            return new List<object[]> {
                new object[] { new List<int> { 1,2,5,4,6,8,5,4 }},
                new object[] { new List<int> { 1,5,4 }}
            };
        }
    }
}