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
        public Move currentMove;
        public override void GenerateNewMove(GameState gs)
        {
            TakeFullMove(gs, currentMove.RowStart, currentMove.ColStart, currentMove.RowEnd, currentMove.ColEnd);
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
                        //////////////////////////////////////////////////
                        int newRowEnd = currentMove.RowEnd;

                        int newColEnd = currentMove.ColEnd;
                        //////////////////////////////////////////////////

                        thisMove = new Move(rowCurrent, colCurrent, newRowEnd, newColEnd);

                        if (CurrentPieceEdibleMoves(gs.GetBoard(), rowCurrent, colCurrent).Contains(thisMove))
                        {
                            MovePieceOnce(gs, rowCurrent, colCurrent, newRowEnd, newColEnd);
                            rowCurrent = newRowEnd;
                            colCurrent = newColEnd;
                        }                       
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
    }   
}
