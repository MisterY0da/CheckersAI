using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new HumanPlayer("black");
            Player p2 = new HumanPlayer("white");
            GameState gs = new GameState(p1, p2);
            gs.ShowBoard();
            Console.WriteLine();
            int moves = 0;

            while(moves < 100)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Input rowStart: ");
                int rowStart = int.Parse(Console.ReadLine());
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Input colStart: ");
                int colStart = int.Parse(Console.ReadLine());
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Input rowEnd: ");
                int rowEnd = int.Parse(Console.ReadLine());
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Input colEnd: ");
                int colEnd = int.Parse(Console.ReadLine());
                Console.ResetColor();

                gs.GetCurrentPlayer().TakeMove(gs, rowStart, colStart, rowEnd, colEnd);


                Console.WriteLine();
                Console.WriteLine("Board state:");
                gs.ShowBoard();
                Console.WriteLine();
                Console.WriteLine();

                moves++;
            }
        }
    }
}
