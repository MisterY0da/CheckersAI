using System;
using System.Collections.Generic;

namespace Checkers
{
    public class ComputerPlayer : Player
    {
        public QLearning qLearning;
        public ComputerMode currentMode;
        public ComputerPlayer(string someColor, QLearning qLearning, ComputerMode mode) : base(someColor) 
        { 
            this.qLearning = qLearning;
            currentMode = mode;
        }

        public override void GenerateNewMove(GameState gs)
        {
            List<Move> moves = GetAllAvailableMoves(gs.GetBoard());

            Random rnd = new Random();

            int moveIndex = rnd.Next(0, moves.Count);

            TakeFullMove(gs, moves[moveIndex].RowStart, moves[moveIndex].ColStart, 
                         moves[moveIndex].RowEnd, moves[moveIndex].ColEnd);
        }

        public override void TakeFullMove(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
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
                if (!(gs.GetBoard()[rowEnd][colEnd] == 'B' && rowEnd == 0 || gs.GetBoard()[rowEnd][colEnd] == 'W' && rowEnd == 7))
                {
                    int rowCurrent = rowEnd;
                    int colCurrent = colEnd;

                    while (CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent).Count > 0)
                    {
                        List<Move> moves = CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent);

                        Random rnd = new Random();

                        int moveIndex = rnd.Next(0, moves.Count);

                        MovePieceOnceCheckEaten(gs, moves[moveIndex].RowStart, moves[moveIndex].ColStart,
                                                moves[moveIndex].RowEnd, moves[moveIndex].ColEnd);
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
