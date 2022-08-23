using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class ScoreBoardTests
    {

        [Fact]
        public void On_game_start_should_return_score_0()
        {
            //1 - Score 0
            //2 - Test de l'ensemble des combinaisons (vérifier feuille blanche)

            // Arrange
            var scoreBoard = new ScoreBoard();

            var combination = 1;
            var dices = new List<int>();

            // Act
            var actual = scoreBoard.CalculateTotalBeforeBonus(combination, dices);

            // Assert
            Assert.Equal(0, actual);

        }

    }
}