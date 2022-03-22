using System;
namespace Checkers
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(string someColor) : base(someColor) { }

        public override void TakeMove(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {
            MovePieceOnceCheckEaten(gs, rowStart, colStart, rowEnd, colEnd);

            // если не стали дамкой, то продолжаем есть по возможности
            if(! (gs.GetBoard()[rowEnd][colEnd] == 'B' && rowEnd == 0 || gs.GetBoard()[rowEnd][colEnd] == 'W' && rowEnd == 7) )
            {
                int rowCurrent = rowEnd;
                int colCurrent = colEnd;

                while (GetEdibleDirection(gs.GetBoard(), rowCurrent, colCurrent) != "missing")
                {
                    switch (GetEdibleDirection(gs.GetBoard(), rowCurrent, colCurrent))
                    {
                        case "up-right":
                            MovePieceOnceCheckEaten(gs, rowCurrent, colCurrent, rowCurrent - 2, colCurrent + 2);
                            rowCurrent -= 2;
                            colCurrent += 2;
                            break;

                        case "up-left":
                            MovePieceOnceCheckEaten(gs, rowCurrent, colCurrent, rowCurrent - 2, colCurrent - 2);
                            rowCurrent -= 2;
                            colCurrent -= 2;
                            break;

                        case "down-right":
                            MovePieceOnceCheckEaten(gs, rowCurrent, colCurrent, rowCurrent + 2, colCurrent + 2);
                            rowCurrent += 2;
                            colCurrent += 2;
                            break;

                        case "down-left":
                            MovePieceOnceCheckEaten(gs, rowCurrent, colCurrent, rowCurrent + 2, colCurrent - 2);
                            rowCurrent += 2;
                            colCurrent -= 2;
                            break;

                        default:
                            break;
                    }
                }
            }

            gs.SwitchPlayer();
        }

        public string GetEdibleDirection(char[][] board, int rowCurrent, int colCurrent)
        {
            // шашка белая
            if (board[rowCurrent][colCurrent] == 'w')
            {
                // вниз-влево
                if ((board[rowCurrent + 2][colCurrent - 2] == '_') && (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    return "down-left";
                }

                // вниз-вправо
                else if ((board[rowCurrent + 2][colCurrent + 2] == '_') && (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    return "down-right";
                }
            }

            // шашка черная
            else if (board[rowCurrent][colCurrent] == 'b')
            {
                // вверх-влево
                if ((board[rowCurrent - 2][colCurrent - 2] == '_') && (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    return "up-left";
                }

                // вверх-вправо
                else if ((board[rowCurrent - 2][colCurrent + 2] == '_') && (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 2][colCurrent + 2] == 'W'))
                {
                    return "up-right";
                }
            }

            // дамка белая
            else if (board[rowCurrent][colCurrent] == 'W')
            {
                // вниз-влево
                if ((board[rowCurrent + 2][colCurrent - 2] == '_') && (board[rowCurrent + 1][colCurrent - 1] == 'b' || board[rowCurrent + 1][colCurrent - 1] == 'B'))
                {
                    return "down-left";
                }

                // вниз-вправо
                else if ((board[rowCurrent + 2][colCurrent + 2] == '_') && (board[rowCurrent + 1][colCurrent + 1] == 'b' || board[rowCurrent + 1][colCurrent + 1] == 'B'))
                {
                    return "down-right";
                }

                // вверх-влево
                else if ((board[rowCurrent - 2][colCurrent - 2] == '_') && (board[rowCurrent - 1][colCurrent - 1] == 'b' || board[rowCurrent - 1][colCurrent - 1] == 'B'))
                {
                    return "up-left";
                }

                // вверх-вправо
                else if ((board[rowCurrent - 2][colCurrent + 2] == '_') && (board[rowCurrent - 1][colCurrent + 1] == 'b' || board[rowCurrent - 2][colCurrent + 2] == 'B'))
                {
                    return "up-right";
                }
            }

            // дамка черная
            else if (board[rowCurrent][colCurrent] == 'B')
            {
                // вниз-влево
                if ((board[rowCurrent + 2][colCurrent - 2] == '_') && (board[rowCurrent + 1][colCurrent - 1] == 'w' || board[rowCurrent + 1][colCurrent - 1] == 'W'))
                {
                    return "down-left";
                }

                // вниз-вправо
                else if ((board[rowCurrent + 2][colCurrent + 2] == '_') && (board[rowCurrent + 1][colCurrent + 1] == 'w' || board[rowCurrent + 1][colCurrent + 1] == 'W'))
                {
                    return "down-right";
                }

                // вверх-влево
                else if ((board[rowCurrent - 2][colCurrent - 2] == '_') && (board[rowCurrent - 1][colCurrent - 1] == 'w' || board[rowCurrent - 1][colCurrent - 1] == 'W'))
                {
                    return "up-left";
                }

                // вверх-вправо
                else if ((board[rowCurrent - 2][colCurrent + 2] == '_') && (board[rowCurrent - 1][colCurrent + 1] == 'w' || board[rowCurrent - 2][colCurrent + 2] == 'W'))
                {
                    return "up-right";
                }
            }

            return "missing";
        }
    }
}
