using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class ScoreGrid
    {
        private readonly Dictionary<Cell, int> _scores;
        private const int bonusYahtzeeScore = 100;

        public ScoreGrid()
        {
            _scores = new Dictionary<Cell, int>();
        }

        public int? GetScore(Cell cell)
        {
            return _scores.TryGetValue(cell, out int value) ? value : (int?)null;
        }

        public void Score(Combination combination, int[] roll)
        {
            if (_scores.ContainsKey(GetCell(combination)))
            {
                if (combination == Combination.Yahtzee && _scores[Cell.Yahtzee] != 0)
                {
                    ComputeBonusYahtzee();
                    return;
                }

                throw new InvalidOperationException("Impossible to score twice in the same cell");
            }

            _scores.Add(GetCell(combination), ScoreEngine.GetScore(roll, combination));
        }

        private void ComputeBonusYahtzee()
        {
            if (_scores.ContainsKey(Cell.BonusYahtzee))
            {
                _scores[Cell.BonusYahtzee] += bonusYahtzeeScore;
            }
            else
            {
                _scores.Add(Cell.BonusYahtzee, bonusYahtzeeScore);
            }
        }

        private Cell GetCell(Combination combination)
        {
            return combination switch
            {
                
                //Combination.Chance => Cell.Chance,
                Combination.Ace => Cell.Ace,
                Combination.Two => Cell.Two,
                //Combination.Three => Cell.Three,
                //Combination.Four => Cell.Four,
                //Combination.Five => Cell.Five,
                //Combination.Six => Cell.Six,
                Combination.Yahtzee => Cell.Yahtzee,
                _ => throw new ArgumentOutOfRangeException(nameof(combination), combination, null)};
        }

        public int GetTotal()
        {
            return _scores.Sum(s => s.Value);
        }
    }
}