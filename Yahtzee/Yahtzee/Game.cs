using System;
using System.Collections.Generic;
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

        private readonly Dictionary<Combination, int> _scores = new();
        private bool _yahtzeeAlreadyScored = false;
        private int _yahtzeeCounter = 0;

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
            if (IsFilled(combination))
            {
                throw new InvalidOperationException();
            }
            
            if (_yahtzeeAlreadyScored && diceRoll.IsYahtzee())
            {
                Enum.TryParse<Combination>(diceRoll.GetRoll().First().ToString(),out var target);
                if (diceRoll.GetRoll().First() != (int)combination && !IsFilled(target))
                    throw new InvalidOperationException();
                _yahtzeeCounter += 1;
            }
            _yahtzeeAlreadyScored = _yahtzeeAlreadyScored || combination == Combination.Yahtzee && diceRoll.IsYahtzee();
            
            if (IsUpperSectionCombination(combination))
            {
                _upperSectionScore += _scoreCalculator.GetScore(diceRoll, combination);
            }
            _scores.Add(combination, _scoreCalculator.GetScore(diceRoll, combination));
        }

        private bool IsFilled(Combination target)
        {
            return _scores.ContainsKey(target);
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

        public int GetScore()
        {
            return _scores.Values.Sum() + GetYahtzeeBonus() + GetUpperSectionBonus();
        }

        public int GetYahtzeeBonus()
        {
            return _yahtzeeCounter * 100;
        }
    }
}