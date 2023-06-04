using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class Table
    {
        private readonly string[] moves;

        public Table(string[] moves)
        {
            this.moves = moves;
        }

        public void DisplayTable()
        {
            int size = moves.Length;
            var table = new string[size + 1, size + 1];

            for (int i = 0; i <= size; i++)
            {
                table[0, i] = i == 0 ? "Moves" : moves[i - 1];
            }

            for (int i = 0; i < size; i++)
            {
                table[i + 1, 0] = moves[i];
                for (int j = 0; j < size; j++)
                {
                    int result = (i - j + size) % size;

                    if (result == 0)
                    {
                        table[i + 1, j + 1] = "Draw";
                    }
                    else if (result <= size / 2)
                    {
                        table[i + 1, j + 1] = "Win";
                    }
                    else
                    {
                        table[i + 1, j + 1] = "Lose";
                    }
                }
            }

            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    Console.Write($"{table[i, j],-8}");
                }
                Console.WriteLine();
            }
        }
    }

}
