using System;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreGridTest
    {
        private readonly ScoreGrid _grid = new ScoreGrid();

        [Fact]
        public void New_grid_should_return_null_score_for_ace_combination()
        {
            int? score = _grid.GetScore(Cell.Ace);
            Assert.Null(score);
        }

        [Fact]
        public void New_grid_should_be_able_to_score_for_an_empty_cell_and_roll_12345()
        {
            int[] roll = { 1, 2, 3, 4, 5 };
            _grid.Score(Combination.Ace, roll);
            int? score = _grid.GetScore(Cell.Ace);

            Assert.Equal(1, score);
        }

        [Fact]
        public void New_grid_should_be_able_to_score_for_an_empty_cell_and_roll_11345()
        {
            int[] roll = { 1, 1, 3, 4, 5 };
            _grid.Score(Combination.Ace, roll);
            int? score = _grid.GetScore(Cell.Ace);

            Assert.Equal(2, score);
        }

        [Fact]
        public void New_grid_should_write_in_the_right_cell()
        {
            int[] roll = { 1, 2, 2, 4, 5 };
            _grid.Score(Combination.Two, roll);
            int? score = _grid.GetScore(Cell.Ace);

            Assert.Null(score);
        }

        [Fact]
        public void New_grid_should_not_be_able_to_score_twice_in_the_same_cell()
        {
            int[] roll = { 1, 1, 3, 4, 5 };
            _grid.Score(Combination.Ace, roll);
            
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _grid.Score(Combination.Ace, roll));
            var actualScore = _grid.GetScore(Cell.Ace);
            Assert.Equal("Impossible to score twice in the same cell", exception.Message);
            Assert.Equal(2, actualScore);
        }

        [Fact]
        public void New_grid_should_get_total_of_3_with_two_cell_score()
        {
            int[] roll = { 1, 2, 3, 4, 5 };
            _grid.Score(Combination.Ace, roll);
            _grid.Score(Combination.Two, roll);

            var total = _grid.GetTotal();

            Assert.Equal(3, total);
        }

        [Fact]
        public void New_grid_should_get_total_of_0_with_no_cell_score()
        {
            Assert.Equal(0, _grid.GetTotal());
        }

        [Fact]
        public void New_grid_should_score_50_with_yahtzee_combination_and_roll_11111()
        {
            int[] roll = { 1, 1, 1, 1, 1 };
            _grid.Score(Combination.Yahtzee, roll);
            int? score = _grid.GetScore(Cell.Yahtzee);

            Assert.Equal(50, score);
        }

        [Fact]
        public void New_grid_should_score_bonus_of_100_with_one_additional_yahtzee()
        {
            int[] roll = { 1, 1, 1, 1, 1 };
            _grid.Score(Combination.Yahtzee, roll);
            _grid.Score(Combination.Yahtzee, roll);

            int? score = _grid.GetScore(Cell.BonusYahtzee);

            Assert.Equal(100, score);
        }

        [Fact]
        public void New_grid_should_score_bonus_of_200_with_two_additional_yahtzee()
        {
            int[] roll = { 1, 1, 1, 1, 1 };
            _grid.Score(Combination.Yahtzee, roll);
            _grid.Score(Combination.Yahtzee, roll);
            _grid.Score(Combination.Yahtzee, roll);

            int? score = _grid.GetScore(Cell.BonusYahtzee);

            Assert.Equal(200, score);
        }

        [Fact]
        public void New_grid_should_have_no_yahtzee_bonus_if_yahtzee_cell_score_is_already_0()
        {
            int[] roll = { 1, 2, 1, 1, 1 };
            _grid.Score(Combination.Yahtzee, roll);

            int[] newRoll = { 1, 1, 1, 1, 1 };
            var exception = Assert.Throws<InvalidOperationException>(() =>
                           _grid.Score(Combination.Yahtzee, newRoll));

            var actualScore = _grid.GetScore(Cell.BonusYahtzee);

            Assert.Equal("Impossible to score twice in the same cell", exception.Message);
            Assert.Null(actualScore);
        }
    }
}
