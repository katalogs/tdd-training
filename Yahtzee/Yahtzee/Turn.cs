using System;

namespace Yahtzee
{
    public class Turn
    {
        private const int MaximumRollNumber = 3;
        private readonly IDiceRoller _diceRoller;
        private int[] _lastRoll;
        private int _rollCounter;

        public Turn(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
            _rollCounter = 0;
        }

        public void RollDices()
        {
            if (_rollCounter >= MaximumRollNumber)
            {
                throw new InvalidOperationException("Only three rolls allowed");
            }

            _rollCounter++;
            _lastRoll = _diceRoller.Roll();
        }

        public int[] GetLastRoll()
        {
            return _lastRoll;
        }

        public void RegisterScore(ScoreGrid grid, Combination combination)
        {
            grid.Score(combination, GetLastRoll());
        }
    }
}