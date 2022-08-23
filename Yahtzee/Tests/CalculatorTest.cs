using System.Collections.Generic;
using Xunit;
using Yahtzee.Domain;
using Yahtzee.Exceptions;

namespace Tests
{
    public class CalculatorTest
    {
        [Theory]
        [MemberData(nameof(DataCombinationUpperSectionSuccessCases))]
        public void GetTotalSuccess(List<int> dices, int expected, int combination)
        {
            // Arrange
            var calculator = new Calculator(); 

            // Act
            var actual = calculator.CalculateScoreByCombination(combination, dices);

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
            Assert.Throws<HasNotFiveDicesException>(() => calculator.CalculateScoreByCombination(1, dices));
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
                new object[] { new List<int> { 1, 1, 1, 2, 5 }, 3, 1 },
                new object[] { new List<int> { 3, 1, 3, 3, 4 }, 9, 3 },
                new object[] { new List<int> { 1, 4, 5, 2, 4 }, 0, 3 },
                new object[] { new List<int> { 1, 4, 4, 4, 4 }, 16, 4 },
                new object[] { new List<int> { 3, 5, 5, 3, 2 }, 0, 4 },
                new object[] { new List<int> { 5, 5, 5, 3, 4 }, 15, 5 },
                new object[] { new List<int> { 3, 4, 6, 3, 4 }, 0, 5 },
                new object[] { new List<int> { 6, 1, 1, 1, 6 }, 12, 6 },
                new object[] { new List<int> { 3, 4, 5, 3, 4 }, 0, 6 }
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