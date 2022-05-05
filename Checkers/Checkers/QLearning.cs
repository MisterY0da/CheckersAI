using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class QLearning
    {
        public double[][] qTable = new double[64][];
        public double alpha = 0.1;
        public double gamma = 0.8;

        public QLearning()
        {
            for (int i = 0; i < 64; i++)
            {
                qTable[i] = new double[64];
                for (int j = 0; j < 64; j++)
                {
                    qTable[i][j] = 0;
                }
            }
        }

        public int GetStateFromCoords(int row, int col)
        {
            return row * 8 + col;
        }

        public int[] GetCoordsFromState(int state)
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

        public void UpdateQTable(int currentState, int currentAction, int reward)
        {
            int newState = currentAction;
            qTable[currentState][currentAction] += alpha * (reward + gamma * qTable[newState].Max() - qTable[currentState][currentAction]);
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
