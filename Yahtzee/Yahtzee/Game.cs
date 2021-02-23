using System;

namespace Yahtzee
{
    public class Game
    {
        private IInput input;
        private IOutput output;

        public Game(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }

        public void Start()
        {
            output.ShowMessage("Player 1 : go !");
        }
    }
}