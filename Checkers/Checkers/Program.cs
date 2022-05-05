﻿using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            QLearning qLearning = new QLearning();
            qLearning.Train(1000);
            Console.WriteLine("Trained");
            Console.WriteLine();
            Player p1 = new HumanPlayer("white");
            Player p2 = new ComputerPlayer("black", qLearning);
            GameState gs = new GameState(p1, p2);
            gs.ShowBoard();
            Console.WriteLine();

            while (gs.GameIsOver() == false)
            {
                //string colorBeforeMove = gs.GetCurrentPlayer().GetColor();
                gs.GetCurrentPlayer().GenerateNewMove(gs);
                //string colorAfterMove = gs.GetCurrentPlayer().GetColor();

                //if (colorBeforeMove != colorAfterMove)
                //{
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
