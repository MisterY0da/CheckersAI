using System;

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

        public virtual void TakeMove(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {

        }

        public bool MovePieceOnceCheckEaten(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {
            bool enemyPieceEaten = false;

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
                            enemyPieceEaten = true;
                        }

                        // вверх-вправо
                        else if ((colEnd - colStart == 2) && 
                            (gs.GetBoard()[rowStart - 1][colStart + 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart + 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'b');
                            gs.ChangeBoardCell(rowStart - 1, colStart + 1, '_');
                            enemyPieceEaten = true;
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
                            enemyPieceEaten = true;
                        }

                        // вниз-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart + 1] == 'w' || gs.GetBoard()[rowStart + 1][colStart + 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart + 1, colStart + 1, '_');
                            enemyPieceEaten = true;
                        }

                        // вверх-влево
                        else if ((colEnd - colStart == -2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart - 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart - 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart - 1, colStart - 1, '_');
                            enemyPieceEaten = true;
                        }

                        // вверх-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart + 1] == 'w' || gs.GetBoard()[rowStart - 1][colStart + 1] == 'W'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'B');
                            gs.ChangeBoardCell(rowStart - 1, colStart + 1, '_');
                            enemyPieceEaten = true;
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
                            enemyPieceEaten = true;
                        }

                        // вниз-вправо
                        else if ((colEnd - colStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart + 1] == 'b' || gs.GetBoard()[rowStart + 1][colStart + 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'w');
                            gs.ChangeBoardCell(rowStart + 1, colStart + 1, '_');
                            enemyPieceEaten = true;
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
                            enemyPieceEaten = true;
                        }

                        // вниз-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == 2) && 
                            (gs.GetBoard()[rowStart + 1][colStart + 1] == 'b' || gs.GetBoard()[rowStart + 1][colStart + 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart + 1, colStart + 1, '_');
                            enemyPieceEaten = true;
                        }

                        // вверх-влево
                        else if ((colEnd - colStart == -2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart - 1] == 'b' || gs.GetBoard()[rowStart - 1][colStart - 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart - 1, colStart - 1, '_');
                            enemyPieceEaten = true;
                        }

                        // вверх-вправо
                        else if ((colEnd - colStart == 2 && rowEnd - rowStart == -2) && 
                            (gs.GetBoard()[rowStart - 1][colStart + 1] == 'b' || gs.GetBoard()[rowStart - 1][colStart + 1] == 'B'))
                        {
                            gs.ChangeBoardCell(rowStart, colStart, '_');
                            gs.ChangeBoardCell(rowEnd, colEnd, 'W');
                            gs.ChangeBoardCell(rowStart - 1, colStart + 1, '_');
                            enemyPieceEaten = true;
                        }
                    }
                }
            }

            return enemyPieceEaten;
        }

        protected bool MoveIsInsideBoard(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            return (rowStart >= 0 && rowStart < 8 && colStart >= 0 && colStart < 8 &&
                rowEnd >= 0 && rowEnd < 8 && colEnd >= 0 && colEnd < 8);
        }
    }
}
