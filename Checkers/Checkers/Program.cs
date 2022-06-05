using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            QLearning qLearning = new QLearning();
            qLearning.Train(500);
            Console.WriteLine("Trained");
            Console.WriteLine("States obtained: " + qLearning.qTable.Count);
            /*for(int i = 0; i < qLearning.qTable.Count; i++)
            {
                Console.WriteLine("Table #" + i + " actions count: " + qLearning.qTable[i].actions.Count + ", prices count: " + qLearning.qTable[i].actionsPrices.Count);
                foreach(var price in qLearning.qTable[i].actionsPrices)
                {
                    Console.WriteLine("price " + price);
                }
            }*/
            /*for (int q = 0; q < qLearning.qTable.Count; q++)
            {
                Console.WriteLine("State # " + q);

                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 8; i++) { Console.Write(" " + i); }
                Console.ResetColor();

                Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(i + " ");
                    Console.ResetColor();

                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(qLearning.qTable[q].stateValue[i][j] + " ");
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(i);
                    Console.ResetColor();

                    Console.WriteLine();
                }

                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 8; i++) { Console.Write(" " + i); }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("action move: r" + qLearning.qTable[q].actions[0].RowStart + ", c" + qLearning.qTable[q].actions[0].ColStart +
                    " -> " + " r" + qLearning.qTable[q].actions[0].RowEnd + ", c" + qLearning.qTable[q].actions[0].ColEnd +
                    "; price:" + qLearning.qTable[q].actionsPrices[0]);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            ComputerPlayer p1 = new ComputerPlayer("white", qLearning);
            ComputerPlayer p2 = new ComputerPlayer("black", qLearning);*/
            Player p1 = new ComputerPlayer("white", qLearning);
            Player p2 = new HumanPlayer("black");
            GameState gs = new GameState(p1, p2);
            gs.ShowBoard();
            Console.WriteLine();

            gs = new GameState(p1, p2);
            while (gs.GameIsOver() == false)
            {

                gs.GetCurrentPlayer().GenerateNewMove(gs);

                /*if (gs.GetCurrentPlayer().GetColor() == p1.GetColor())
                {
                    p1.GenerateNewRandomMove(gs);
                }
                else
                {
                    p2.GenerateNewRandomMove(gs);
                }*/
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
