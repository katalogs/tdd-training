using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class CalculatorTest
    {
        //5 dés + combinaison = total

        public void calculator_should_return_total()
        {
            // But test : Renvoie de la bonne valeur du cas 5 dés de valeur 1

            // Arrange
            var calcultor = new Calculator();

            // Act
            int combinaison = 1;

            int actual = calcultor.getTotal(combinaison, new int[] { 1, 1, 1, 1, 1 });

            // Assert
            Assert.Equals(5, actual);
        }



    }
}
