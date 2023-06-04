using RockPaperScissorsGame;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.WriteLine("Incorrect arguments.");
            Console.WriteLine("How to run Game: dotnet run rock paper scissors lizard Spock");
            return;
        }

        var game = new Game(args);
        game.Start();
    }
}

class Game
{
    private readonly string[] moves;
    private readonly KeyGenerator keyGenerator;
    private readonly HCalculator hmacCalculator;
    private readonly GameRules gameRules;

    public Game(string[] moves)
    {
        this.moves = moves;
        keyGenerator = new KeyGenerator();
        hmacCalculator = new HCalculator();
        gameRules = new GameRules(moves);
    }

    public void Start()
    {
        while (true)
        {
            string key = keyGenerator.GenerateKey();
            Console.WriteLine($"HMAC: {hmacCalculator.CalculateHMAC(key, moves)}");

            DisplayMoves();

            int userMove = GetUserMove();

            if (userMove == 0)
            {
                Console.WriteLine("Nice Game");
                break;
            }

            string userMoveName = moves[userMove - 1];
            string computerMove = GenerateComputerMove();

            Console.WriteLine($"Your move: {userMoveName}");
            Console.WriteLine($"Computer move: {computerMove}");

            int result = gameRules.CheckWinner(userMove, computerMove.Length);

            if (result == -1)
            {
                Console.WriteLine("draw!");
            }
            else if (result == 1)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }

            Console.WriteLine($"HMAC key: {key}");
            Console.WriteLine();

            Console.Write("Do you want to play again? (Y/N): ");
            string playAgain = Console.ReadLine();

            if (playAgain?.ToUpper() != "Y")
            {
                Console.WriteLine("Exit the game.");
                break;
            }

            Console.Clear();
        }
    }

    private void DisplayMoves()
    {
        Console.WriteLine("Play moves:");
        for (int i = 0; i < moves.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {moves[i]}");
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    private int GetUserMove()
    {
        int userMove;
        while (true)
        {
            Console.Write("Enter your move: ");
            string input = Console.ReadLine();

            if (input == "?")
            {
                var playTable = new Table(moves);
                playTable.DisplayTable();
                DisplayMoves();
            }
            else if (int.TryParse(input, out userMove))
            {
                if (userMove >= 0 && userMove <= moves.Length)
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Wrong Move! enter correct move number or '?' for help.");
            }
        }
        return userMove;
    }

    private string GenerateComputerMove()
    {
        var random = new Random();
        int randomIndex = random.Next(moves.Length);
        return moves[randomIndex];
    }
}