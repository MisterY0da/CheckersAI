using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class QLearning
    {
        public int[,] qTable = new int[64, 64];

        public QLearning()
        {
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    qTable[i, j] = 0;
                }
            }
        }

        public static int ConvertCoordsToState(int row, int col)
        {
            return row * 8 + col;
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

        public void Train()
        {

        }
    }
}
