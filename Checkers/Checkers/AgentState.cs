using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class AgentState : IEquatable<AgentState>
    {
        public char[][] stateValue = new char[8][];
        public List<Move> actions;
        public List<double> actionsPrices;

        public AgentState(char[][] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    stateValue[i][j] = board[i][j];
                }
            }
        }

        public bool Equals(AgentState otherState)
        {
            bool areEqual = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    areEqual = this.stateValue[i][j] == otherState.stateValue[i][j];
                    if(areEqual == false)
                    {
                        break;
                    }
                }
            }

            return areEqual;
        }
    }
}
