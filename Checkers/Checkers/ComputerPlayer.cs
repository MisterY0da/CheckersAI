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
            Move move = GetOptimalMove(gs.GetBoard());            

            TakeFullMove(gs, move.RowStart, move.ColStart, move.RowEnd, move.ColEnd);
        }

        public void GenerateNewRandomMove(GameState gs, bool isLearning = false, AgentState agentState = null, 
            List<Move> actionsThisGame = null)
        {
            List<Move> moves = GetAllAvailableMoves(gs.GetBoard());

            Random rnd = new Random();

            int moveIndex = rnd.Next(0, moves.Count);

            Move move = moves[moveIndex];

            if(isLearning == true && agentState != null && actionsThisGame != null 
                && agentState.actions.Contains(move) == false )
            {
                agentState.actions.Add(move);
                agentState.actionsPrices.Add(0);
                actionsThisGame.Add(move);
            }

            TakeFullMove(gs, move.RowStart, move.ColStart, move.RowEnd, move.ColEnd);
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
                        List<Move> edibleMoves = CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent);

                        Random rnd = new Random();

                        int moveIndex = rnd.Next(0, edibleMoves.Count);

                        Move move = edibleMoves[moveIndex];

                        MovePieceOnce(gs, move.RowStart, move.ColStart,move.RowEnd, move.ColEnd);
                        rowCurrent = move.RowEnd;
                        colCurrent = move.ColEnd;
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

        public Move GetOptimalMove(char[][] board)
        {
            foreach (var state in qLearning.qTable)
            {
                AgentState agentState = new AgentState(board);
                if (state.Equals(agentState))
                {
                    int indexMaxMove = 0;
                    double maxValue = state.actionsPrices[0];

                    for (int i = 0; i < state.actionsPrices.Count; i++)
                    {
                        if (state.actionsPrices[i] > maxValue)
                        {
                            maxValue = state.actionsPrices[i];
                            indexMaxMove = i;
                        }
                    }

                    return state.actions[indexMaxMove];
                }
            }

            List<Move> moves = GetAllAvailableMoves(board);

            Random rnd = new Random();

            int moveIndex = rnd.Next(0, moves.Count);

            return moves[moveIndex];
        }
    }
}
