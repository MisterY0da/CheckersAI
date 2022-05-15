using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            QLearning qLearning = new QLearning();
            //qLearning.Train(1000);
            Console.WriteLine("Trained");
            Console.WriteLine();
            ComputerPlayer p1 = new ComputerPlayer("white", qLearning);
            ComputerPlayer p2 = new ComputerPlayer("black", qLearning);
            GameState gs = new GameState(p1, p2);
            gs.ShowBoard();
            Console.WriteLine();

            while (gs.GameIsOver() == false)
            {
                //string colorBeforeMove = gs.GetCurrentPlayer().GetColor();
                //gs.GetCurrentPlayer().GenerateNewMove(gs);
                //string colorAfterMove = gs.GetCurrentPlayer().GetColor();

                //if (colorBeforeMove != colorAfterMove)
                //{

                if (gs.GetCurrentPlayer().GetColor() == p1.GetColor())
                {
                    p1.GenerateNewRandomMove(gs);
                }
                else
                {
                    p2.GenerateNewRandomMove(gs);
                }

                Console.WriteLine();
                Console.WriteLine("Board state:");
                gs.ShowBoard();
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadLine();
                //}
            }
        }
    }
}
