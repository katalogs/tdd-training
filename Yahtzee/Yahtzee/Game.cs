﻿using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Game
    {
        private const int UpperSectionBonusThreshold = 63;
        private const int UpperSectionBonus = 35;
        
        private static readonly IEnumerable<Combination> UpperCombinations = new[] { 
            Combination.Aces, Combination.Twos, Combination.Threes,
            Combination.Fours, Combination.Fives, Combination.Sixes };
        
        private int _upperSectionScore = 0;
        private readonly ScoreCalculator _scoreCalculator;

        public Game(ScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
        }

        public int GetUpperSectionTotal()
        {
            return _upperSectionScore;
        }

        public void Score(Combination combination, DiceRoll diceRoll)
        {
            if (IsUpperSectionCombination(combination))
            {
                _upperSectionScore += _scoreCalculator.GetScore(diceRoll, combination);
            }
        }

        private static bool IsUpperSectionCombination(Combination combination)
        {
            return UpperCombinations.Any(x => x == combination);
        }

        public int GetUpperSectionBonus()
        {
            return SatisfiesUpperSectionBonus() ? UpperSectionBonus : 0;
        }
        private bool SatisfiesUpperSectionBonus()
        {
            return _upperSectionScore >= UpperSectionBonusThreshold;
        }
    }
}