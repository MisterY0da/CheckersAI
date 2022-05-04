using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class QLearning
    {
        public int[][] qTable = new int[64][];
        public const double alpha = 0.1;
        public const double gamma = 0.8;

        public QLearning()
        {
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    qTable[i][j] = 0;
                }
            }
        }

        public static int ConvertCoordsToState(int row, int col)
        {
            return row * 8 + col;
        }

        public static int[] ConvertStateToCoords(int state)
        {
            int[] rowCol = new int[2];
            rowCol[0] = state / 8;
            rowCol[1] = state % 8;

            return rowCol;
        }

        public int GetReward(bool eaten, bool becameKing, bool gameEnded)
        {
            int rewardPoints = 0;

            if(eaten)
            {
                rewardPoints += 1;
            }

            if(becameKing)
            {
                rewardPoints += 3;
            }

            if(gameEnded)
            {
                rewardPoints += 10;
            }

            return rewardPoints;
        }

        public void Train(int numberOfGames)
        {
            for (int gameIndex = 0; gameIndex < numberOfGames; gameIndex++)
            {
                //while game is not ended
            }
        }
    }
}
