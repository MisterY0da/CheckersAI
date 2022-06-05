using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            QLearning qLearning = new QLearning();
            qLearning.Train(100);
            Console.WriteLine("Trained");
            Console.WriteLine("States obtained: " + qLearning.qTable.Count);

            Player p1 = new ComputerPlayer("white", qLearning);
            Player p2 = new HumanPlayer("black");
            GameState gs = new GameState(p1, p2);
            gs.ShowBoard();
            Console.WriteLine();

            gs = new GameState(p1, p2);
            while (gs.GameIsOver() == false)
            {

                gs.GetCurrentPlayer().GenerateNewMove(gs);

                Console.WriteLine();
                Console.WriteLine("Board state:");
                gs.ShowBoard();
                if (qLearning.qTable.Contains(new AgentState(gs.GetBoard())))
                {
                    Console.WriteLine("this state is obtained");
                }
                else
                {
                    Console.WriteLine("this state is NOT obtained");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadLine();

            }
        }
    }
}
