using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    public class ComputerPlayer : Player
    {
        public QLearning qLearning;
        public ComputerPlayer(string someColor) : base(someColor) { }

        public ComputerPlayer(string someColor, QLearning qLearning) : base(someColor) 
        { 
            this.qLearning = qLearning;
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
                    MovePieceOnce(gs, rowStart, colStart, rowEnd, colEnd);
                }

                // если не стали дамкой и съели предыдущим ходом, то продолжаем есть по возможности
                if (!BecameKing(gs, rowEnd, colEnd))
                {
                    int rowCurrent = rowEnd;
                    int colCurrent = colEnd;

                    while (CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent).Count > 0 && 
                        !BecameKing(gs, rowCurrent, colCurrent))
                    {
                        List<Move> moves = CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent);

                        Random rnd = new Random();

                        int moveIndex = rnd.Next(0, moves.Count);

                        MovePieceOnce(gs, moves[moveIndex].RowStart, moves[moveIndex].ColStart,
                                                moves[moveIndex].RowEnd, moves[moveIndex].ColEnd);
                        rowCurrent = moves[moveIndex].RowEnd;
                        colCurrent = moves[moveIndex].ColEnd;
                    }
                }
            }

            else
            {
                MovePieceOnce(gs, rowStart, colStart, rowEnd, colEnd);
            }

            string boardAfterMove = gs.GetBoardString();

            if (!boardAfterMove.Equals(boardBeforeMove))
            {
                gs.SwitchPlayer();
            }
        }

        public void TakeFullMoveLearning(GameState gs, int rowStart, int colStart, int rowEnd, int colEnd)
        {
            string boardBeforeMove = gs.GetBoardString();
            int currentState = qLearning.GetStateFromCoords(rowStart, colStart);
            int currentAction = qLearning.GetStateFromCoords(rowEnd, colEnd);

            if (MustEatThisMove(gs.GetBoard()) == true)
            {
                Move thisMove = new Move(rowStart, colStart, rowEnd, colEnd);

                if (CurrentPieceEdibleMoves(gs.GetBoard(), rowStart, colStart).Contains(thisMove))
                {
                    MovePieceOnce(gs, rowStart, colStart, rowEnd, colEnd);

                    bool becameKing = BecameKing(gs, rowEnd, colEnd);
                    bool gameEnded = isWinner;
                    int reward = qLearning.GetReward(true, becameKing, gameEnded);

                    qLearning.UpdateQTable(currentState, currentAction, reward);             
                }

                // если не стали дамкой и съели предыдущим ходом, то продолжаем есть по возможности
                if (!BecameKing(gs, rowEnd, colEnd))
                {
                    int rowCurrent = rowEnd;
                    int colCurrent = colEnd;
                    
                    while (CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent).Count > 0 &&
                        !BecameKing(gs, rowCurrent, colCurrent))
                    {
                        currentState = qLearning.GetStateFromCoords(rowCurrent, colCurrent);

                        List<Move> moves = CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent);

                        Random rnd = new Random();

                        int moveIndex = rnd.Next(0, moves.Count);

                        MovePieceOnce(gs, moves[moveIndex].RowStart, moves[moveIndex].ColStart,
                                                moves[moveIndex].RowEnd, moves[moveIndex].ColEnd);

                        bool becameKing = BecameKing(gs, moves[moveIndex].RowEnd, moves[moveIndex].ColEnd);
                        bool gameEnded = isWinner;
                        int reward = qLearning.GetReward(true, becameKing, gameEnded);
                        currentAction = qLearning.GetStateFromCoords(moves[moveIndex].RowEnd, moves[moveIndex].ColEnd);

                        qLearning.UpdateQTable(currentState, currentAction, reward);

                        rowCurrent = moves[moveIndex].RowEnd;
                        colCurrent = moves[moveIndex].ColEnd;
                    }
                }
            }

            // не едим
            else
            {
                MovePieceOnce(gs, rowStart, colStart, rowEnd, colEnd);
                bool becameKing = BecameKing(gs, rowEnd, colEnd);
                bool gameEnded = isWinner;
                int reward = qLearning.GetReward(false, becameKing, gameEnded);
                qLearning.UpdateQTable(currentState, currentAction, reward);
            }

            string boardAfterMove = gs.GetBoardString();

            if (!boardAfterMove.Equals(boardBeforeMove))
            {
                gs.SwitchPlayer();
            }
        }
    }
}
