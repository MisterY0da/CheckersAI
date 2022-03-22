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

        

        public bool MustEatThisMove(char[][] board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if(CurrentPieceEdibleMoves(board, row, col).Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Move> CurrentPieceEdibleMoves(char[][] board, int rowCurrent, int colCurrent)
        {
            List<Move> edibleMoves = new List<Move>();

            // шашка белая
            if (board[rowCurrent][colCurrent] == 'w' && _color == "white")
            {
                // вниз-влево
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && (board[rowCurrent + 2][colCurrent - 2] == '_') && 
                    (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }

                // вниз-вправо
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && (board[rowCurrent + 2][colCurrent + 2] == '_') && 
                    (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }
            }

            // шашка черная
            else if (board[rowCurrent][colCurrent] == 'b' && _color == "black")
            {
                // вверх-влево
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && (board[rowCurrent - 2][colCurrent - 2] == '_') && 
                    (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }

                // вверх-вправо
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && (board[rowCurrent - 2][colCurrent + 2] == '_') && 
                    (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 1][colCurrent + 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }
            }

            // дамка белая
            else if (board[rowCurrent][colCurrent] == 'W' && _color == "white")
            {
                // вниз-влево
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && (board[rowCurrent + 2][colCurrent - 2] == '_') && 
                    (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }

                // вниз-вправо
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && (board[rowCurrent + 2][colCurrent + 2] == '_') && 
                    (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                // вверх-влево
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && (board[rowCurrent - 2][colCurrent - 2] == '_') && 
                    (board[rowCurrent - 1][colCurrent - 1] == 'b' || board[rowCurrent - 1][colCurrent - 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }

                // вверх-вправо
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && (board[rowCurrent - 2][colCurrent + 2] == '_') && 
                    (board[rowCurrent - 1][colCurrent + 1] == 'b' || board[rowCurrent - 1][colCurrent + 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }
            }

            // дамка черная
            else if (board[rowCurrent][colCurrent] == 'B' && _color == "black")
            {
                // вниз-влево
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && (board[rowCurrent + 2][colCurrent - 2] == '_') && 
                    (board[rowCurrent + 1][colCurrent - 1] == 'w' || board[rowCurrent + 1][colCurrent - 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }

                // вниз-вправо
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && (board[rowCurrent + 2][colCurrent + 2] == '_') && 
                    (board[rowCurrent + 1][colCurrent + 1] == 'w' || board[rowCurrent + 1][colCurrent + 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                // вверх-влево
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && (board[rowCurrent - 2][colCurrent - 2] == '_') && 
                    (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }

                // вверх-вправо
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && (board[rowCurrent - 2][colCurrent + 2] == '_') && 
                    (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 1][colCurrent + 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }
            }

            return edibleMoves;
        }       
    }   
}
