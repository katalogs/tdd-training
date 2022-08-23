using System.Collections.Generic;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreBoardTests
    {

        [Fact]
        public void On_game_start_should_return_score_0()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();

            // Act
            var actual = scoreBoard.CalculateTotalBeforeBonus();

            // Assert
            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void All_combination_with_zero_should_return_score_0()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            scoreBoard.AddCombination(1, new List<int> { 2, 5, 3, 1, 5 });
            scoreBoard.AddCombination(2, new List<int> { 1, 5, 3, 1, 5 });
            scoreBoard.AddCombination(3, new List<int> { 1, 5, 5, 1, 2 });
            scoreBoard.AddCombination(4, new List<int> { 1, 5, 5, 1, 2 });
            scoreBoard.AddCombination(5, new List<int> { 1, 2, 3, 1, 2 });
            scoreBoard.AddCombination(6, new List<int> { 1, 5, 5, 1, 2 });

            // Act
            var actual = scoreBoard.CalculateTotalBeforeBonus();

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Add_same_combination_twice_should_throw_exception()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            scoreBoard.AddCombination(1, new List<int> { 1, 5, 3, 1, 5 });

            // Act
            Assert.Throws<SameCombinationTwiceException>(() => scoreBoard.AddCombination(1, new List<int> { 4, 2, 3, 1, 3 }));
        }
    }
}