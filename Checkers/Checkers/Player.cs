using System;
using System.Collections.Generic;

namespace Checkers
{
    public class Player
    {
        protected string _color;
        public Player(string someColor)
        {
            _color = someColor;
        }       

        public string GetColor()
        {
            return _color;
        }

        public virtual void TakeFullMove(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {

        }

        public virtual void GenerateNewMove(GameState gs)
        {

        }

        public void MovePieceOnce(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {


            if (MoveIsInsideBoard(rowStart, colStart, rowEnd, colEnd))
            {
                // черная шашка
                if (gs.GetBoard()[rowStart][colStart] == 'b' && (gs.GetBoard()[rowEnd][colEnd] == '_') && gs.GetCurrentPlayer().GetColor() == "black")
                {
                    if ((rowEnd - rowStart == -1) && (Math.Abs(colEnd - colStart) == 1))
                    {
                        gs.ChangeBoardCell(rowStart, colStart, '_');
                        gs.ChangeBoardCell(rowEnd, colEnd, 'b');

                        // становится дамкой
                        if (rowEnd == 0)
                        {
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                        }
                    }

                    // едим противника
                    else if (rowEnd - rowStart == -2 && Math.Abs(colEnd - colStart) == 2)
                    {
                        // вверх-влево
                        if ((colEnd - colStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart - 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart - 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'b');
                            gs.ChangeBoardCell(rowStart - 1, colStart - 1, '_');
                            
                        }

                        // вверх-вправо
                        else if ((colEnd - colStart == 2) && 
                            (gs.GetBoard()[rowStart - 1][colStart + 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart + 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'b');
                            gs.ChangeBoardCell(rowStart - 1, colStart + 1, '_');
                            
                        }

                        // становится дамкой
                        if (rowEnd == 0)
                        {
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                        }
                    }
                }

                // дамка черных
                else if (gs.GetBoard()[rowStart][colStart] == 'B' && (gs.GetBoard()[rowEnd][colEnd] == '_') && gs.GetCurrentPlayer().GetColor() == "black")
                {
                    if (Math.Abs(rowEnd - rowStart) == 1 && Math.Abs(colEnd - colStart) == 1)
                    {
                        gs.ChangeBoardCell(rowStart, colStart, '_');
                        gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                    }

                    // едим противника
                    else if (Math.Abs(rowEnd - rowStart) == 2 && Math.Abs(colEnd - colStart) == 2)
                    {
                        // вниз-влево
                        if ((colEnd - colStart == -2 && rowEnd - rowStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart - 1] == 'w' || gs.GetBoard()[rowStart + 1][colStart - 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart + 1, colStart - 1, '_');
                            
                        }

                        // вниз-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart + 1] == 'w' || gs.GetBoard()[rowStart + 1][colStart + 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart + 1, colStart + 1, '_');
                           
                        }

                        // вверх-влево
                        else if ((colEnd - colStart == -2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart - 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart - 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart - 1, colStart - 1, '_');
                            
                        }

                        // вверх-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart + 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart + 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart - 1, colStart + 1, '_');
                            
                        }
                    }
                }

                // шашка белая
                else if (gs.GetBoard()[rowStart][colStart] == 'w' && (gs.GetBoard()[rowEnd][colEnd] == '_') && gs.GetCurrentPlayer().GetColor() == "white")
                {
                    if ((rowEnd - rowStart == 1) && (Math.Abs(colEnd - colStart) == 1))
                    {
                        gs.ChangeBoardCell(rowStart, colStart, '_');
                        gs.ChangeBoardCell(rowEnd, colEnd, 'w');

                        // становится дамкой
                        if (rowEnd == 7)
                        {
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                        }
                    }

                    // едим противника
                    else if (rowEnd - rowStart == 2 && Math.Abs(colEnd - colStart) == 2)
                    {
                        // вниз-влево
                        if ((colEnd - colStart == -2) && 
                            (gs.GetBoard()[rowStart + 1][colStart - 1] == 'b' || gs.GetBoard()[rowStart + 1][colStart - 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'w');
                            gs.ChangeBoardCell(rowStart + 1, colStart - 1, '_');
                            
                        }

                        // вниз-вправо
                        else if ((colEnd - colStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart + 1] == 'b' || gs.GetBoard()[rowStart + 1][colStart + 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'w');
                            gs.ChangeBoardCell(rowStart + 1, colStart + 1, '_');
                            
                        }

                        // становится дамкой
                        if (rowEnd == 7)
                        {
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                        }
                    }
                }

                // дамка белых
                else if (gs.GetBoard()[rowStart][colStart] == 'W' && (gs.GetBoard()[rowEnd][colEnd] == '_') && gs.GetCurrentPlayer().GetColor() == "white")
                {
                    if (Math.Abs(rowEnd - rowStart) == 1 && Math.Abs(colEnd - colStart) == 1)
                    {
                        gs.ChangeBoardCell(rowStart, colStart, '_');
                        gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                    }

                    // едим противника
                    else if (Math.Abs(rowEnd - rowStart) == 2 && Math.Abs(colEnd - colStart) == 2)
                    {
                        // вниз-влево
                        if ((colEnd - colStart == -2 && rowEnd - rowStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart - 1] == 'b' || gs.GetBoard()[rowStart + 1][colStart - 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart + 1, colStart - 1, '_');
                            
                        }

                        // вниз-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart + 1] == 'b' || gs.GetBoard()[rowStart + 1][colStart + 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart + 1, colStart + 1, '_');
                            
                        }

                        // вверх-влево
                        else if ((colEnd - colStart == -2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart - 1] == 'b' || gs.GetBoard()[rowStart - 1][colStart - 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart - 1, colStart - 1, '_');
                            
                        }

                        // вверх-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart + 1] == 'b' || gs.GetBoard()[rowStart - 1][colStart + 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart - 1, colStart + 1, '_');
                            
                        }
                    }
                }
            }

           
        }

        public List<Move> GetAllAvailableMoves(char[][] board)
        {
            List<Move> allAvailableMoves = new List<Move>();
            List<Move> allEdibleMoves = new List<Move>();

            for(int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    allAvailableMoves.AddRange(CurrentPieceAvailableMoves(board, row, col));
                    allEdibleMoves.AddRange(CurrentPieceEdibleMoves(board, row, col));
                }
            }

            if(allEdibleMoves.Count > 0)
            {
                return allEdibleMoves;
            }

            return allAvailableMoves;
        }

        public List<Move> CurrentPieceAvailableMoves(char[][] board, int rowCurrent, int colCurrent)
        {
            List<Move> availableMoves = new List<Move>();

            // черная шашка
            if (board[rowCurrent][colCurrent] == 'b' && _color == "black")
            {
                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 1, colCurrent + 1) && board[rowCurrent - 1][colCurrent + 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 1, colCurrent + 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 1, colCurrent - 1) && board[rowCurrent - 1][colCurrent - 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 1, colCurrent - 1));
                }

                if(MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && board[rowCurrent - 2][colCurrent + 2] == '_' &&
                    (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 1][colCurrent + 1] == 'W'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && board[rowCurrent - 2][colCurrent - 2] == '_' &&
                    (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }
            }

            // шашка белая
            else if (board[rowCurrent][colCurrent] == 'w' && _color == "white")
            {
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 1, colCurrent + 1) && board[rowCurrent + 1][colCurrent + 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 1, colCurrent + 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 1, colCurrent - 1) && board[rowCurrent + 1][colCurrent - 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 1, colCurrent - 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && board[rowCurrent + 2][colCurrent + 2] == '_' &&
                    (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && board[rowCurrent + 2][colCurrent - 2] == '_' &&
                    (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }
            }

            // дамка черных
            else if (board[rowCurrent][colCurrent] == 'B' && _color == "black")
            {
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 1, colCurrent + 1) && board[rowCurrent - 1][colCurrent + 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 1, colCurrent + 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 1, colCurrent - 1) && board[rowCurrent - 1][colCurrent - 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 1, colCurrent - 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && board[rowCurrent - 2][colCurrent + 2] == '_' &&
                    (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 1][colCurrent + 1] == 'W'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && board[rowCurrent - 2][colCurrent - 2] == '_' &&
                    (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }



                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 1, colCurrent + 1) && board[rowCurrent + 1][colCurrent + 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 1, colCurrent + 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 1, colCurrent - 1) && board[rowCurrent + 1][colCurrent - 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 1, colCurrent - 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && board[rowCurrent + 2][colCurrent + 2] == '_' &&
                    (board[rowCurrent + 1][colCurrent + 1] == 'w' || board[rowCurrent + 1][colCurrent + 1] == 'W'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && board[rowCurrent + 2][colCurrent - 2] == '_' &&
                    (board[rowCurrent + 1][colCurrent - 1] == 'w' || board[rowCurrent + 1][colCurrent - 1] == 'W'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }
            }         

            // дамка белых
            else if (board[rowCurrent][colCurrent] == 'W' && _color == "white")
            {
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 1, colCurrent + 1) && board[rowCurrent - 1][colCurrent + 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 1, colCurrent + 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 1, colCurrent - 1) && board[rowCurrent - 1][colCurrent - 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 1, colCurrent - 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && board[rowCurrent - 2][colCurrent + 2] == '_' &&
                    (board[rowCurrent - 1][colCurrent + 1] == 'b' || board[rowCurrent - 1][colCurrent + 1] == 'B'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && board[rowCurrent - 2][colCurrent - 2] == '_' &&
                    (board[rowCurrent - 1][colCurrent - 1] == 'b' || board[rowCurrent - 1][colCurrent - 1] == 'B'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }



                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 1, colCurrent + 1) && board[rowCurrent + 1][colCurrent + 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 1, colCurrent + 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 1, colCurrent - 1) && board[rowCurrent + 1][colCurrent - 1] == '_')
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 1, colCurrent - 1));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && board[rowCurrent + 2][colCurrent + 2] == '_' &&
                    (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && board[rowCurrent + 2][colCurrent - 2] == '_' &&
                    (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    availableMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }
            }

            return availableMoves;

        }

        protected bool MoveIsInsideBoard(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            return (rowStart >= 0 && rowStart < 8 && colStart >= 0 && colStart < 8 &&
                rowEnd >= 0 && rowEnd < 8 && colEnd >= 0 && colEnd < 8);
        }

        public bool MustEatThisMove(char[][] board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (CurrentPieceEdibleMoves(board, row, col).Count > 0)
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
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && (board[rowCurrent + 2][colCurrent - 2] == '_') &&
                    (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }

                // вниз-вправо
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && (board[rowCurrent + 2][colCurrent + 2] == '_') &&
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
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && (board[rowCurrent - 2][colCurrent + 2] == '_') &&
                    (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 1][colCurrent + 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }
            }

            // дамка белая
            else if (board[rowCurrent][colCurrent] == 'W' && _color == "white")
            {
                // вниз-влево
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2) && (board[rowCurrent + 2][colCurrent - 2] == '_') &&
                    (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2));
                }

                // вниз-вправо
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && (board[rowCurrent + 2][colCurrent + 2] == '_') &&
                    (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                // вверх-влево
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && (board[rowCurrent - 2][colCurrent - 2] == '_') &&
                    (board[rowCurrent - 1][colCurrent - 1] == 'b' || board[rowCurrent - 1][colCurrent - 1] == 'B'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }

                // вверх-вправо
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && (board[rowCurrent - 2][colCurrent + 2] == '_') &&
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
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2) && (board[rowCurrent + 2][colCurrent + 2] == '_') &&
                    (board[rowCurrent + 1][colCurrent + 1] == 'w' || board[rowCurrent + 1][colCurrent + 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2));
                }

                // вверх-влево
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2) && (board[rowCurrent - 2][colCurrent - 2] == '_') &&
                    (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2));
                }

                // вверх-вправо
                if (MoveIsInsideBoard(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2) && (board[rowCurrent - 2][colCurrent + 2] == '_') &&
                    (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 1][colCurrent + 1] == 'W'))
                {
                    edibleMoves.Add(new Move(rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2));
                }
            }

            return edibleMoves;
        }

        public bool BecameKing(GameState gs, int row, int col)
        {
            return gs.GetBoard()[row][col] == 'B' && row == 0 ||
                gs.GetBoard()[row][col] == 'W' && row == 7;
        }
    }
}
