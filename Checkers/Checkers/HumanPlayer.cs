using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string someColor) : base(someColor) { }

        public override void CreateMove(GameState gs)
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

            TakeMove(gs, rowStart, colStart, rowEnd, colEnd);
        }

        public override void TakeMove(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {
            string boardBeforeMove = gs.GetBoardString();           

            if (MustEatThisMove(gs.GetBoard()) == true)
            {
                Move thisMove = new Move(rowStart, colStart, rowEnd, colEnd);

                if (CurrentPieceEdibleMoves(gs.GetBoard(), rowStart, colStart).Contains(thisMove))
                {
                    MovePieceOnceCheckEaten(gs, rowStart, colStart, rowEnd, colEnd);
                }

                // если не стали дамкой и съели предыдущим ходом, то продолжаем есть по возможности
                if ( !(gs.GetBoard()[rowEnd][colEnd] == 'B' && rowEnd == 0 || gs.GetBoard()[rowEnd][colEnd] == 'W' && rowEnd == 7) )
                {
                    int rowCurrent = rowEnd;
                    int colCurrent = colEnd;

                    while (CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent).Count > 0)
                    {
                        //////////////////////////////////////////////////
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Input rowEnd: ");
                        int newRowEnd = int.Parse(Console.ReadLine());
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Input colEnd: ");
                        int newColEnd = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        //////////////////////////////////////////////////

                        thisMove = new Move(rowCurrent, colCurrent, newRowEnd, newColEnd);

                        if (CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent).Contains(thisMove))
                        {
                            MovePieceOnceCheckEaten(gs, rowCurrent, colCurrent, newRowEnd, newColEnd);
                            rowCurrent = newRowEnd;
                            colCurrent = newColEnd;
                        }                       
                    }
                }
            }
            
            else
            {
                
                MovePieceOnceCheckEaten(gs, rowStart, colStart, rowEnd, colEnd);               
            }

            string boardAfterMove = gs.GetBoardString();

            if (!boardAfterMove.Equals(boardBeforeMove))
            {
                gs.SwitchPlayer();
            }
        }       
    }   
}
