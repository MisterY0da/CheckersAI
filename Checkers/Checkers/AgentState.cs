using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class AgentState : IEquatable<AgentState>
    {
        public char[][] stateValue;
        public List<Move> actions;
        public List<double> actionsPrices;

        public AgentState(char[][] board)
        {
            stateValue = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                stateValue[i] = new char[8];
                for (int j = 0; j < 8; j++)
                {
                    stateValue[i][j] = board[i][j];
                }
            }

            actions = new List<Move>();
            actionsPrices = new List<double>();
        }

        public bool Equals(AgentState otherState)
        {
            return GetStateString().Equals(otherState.GetStateString());
        }

        public string GetStateString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sb.Append(stateValue[i][j]);
                }
            }

            return sb.ToString();
        }
    }
}
