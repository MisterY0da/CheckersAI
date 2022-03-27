using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new HumanPlayer("black");
            Player p2 = new ComputerPlayer("white");
            GameState gs = new GameState(p1, p2);
            gs.ShowBoard();
            Console.WriteLine();

            while(gs.GameIsOver() == false)
            {
                string colorBeforeMove = gs.GetCurrentPlayer().GetColor();
                gs.GetCurrentPlayer().CreateMove(gs);
                string colorAfterMove = gs.GetCurrentPlayer().GetColor();

                if (colorBeforeMove != colorAfterMove)
                {
                    Console.WriteLine();
                    Console.WriteLine("Board state:");
                    gs.ShowBoard();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
