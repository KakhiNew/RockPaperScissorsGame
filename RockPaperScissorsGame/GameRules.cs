using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class GameRules
    {
        private readonly string[] moves;

        public GameRules(string[] moves)
        {
            this.moves = moves;
        }

        public int CheckWinner(int userMove, int computerMove)
        {
            int size = moves.Length;
            int half = size / 2;
            int result = (computerMove - userMove + size) % size;

            if (result == 0)
            {
                return -1;
            }
            else if (result <= half)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
