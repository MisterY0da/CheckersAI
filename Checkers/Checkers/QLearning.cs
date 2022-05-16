using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class QLearning
    {
        public List<AgentState> qTable;
        public double alpha = 0.1;
        public double gamma = 0.8;

        public QLearning()
        {
            qTable = new List<AgentState>();
        }        

        public void Train(int numberOfGames)
        {
            ComputerPlayer environmentPlayer = new ComputerPlayer("black", this);
            ComputerPlayer learningPlayer = new ComputerPlayer("white", this);
            for (int gameIndex = 0; gameIndex < numberOfGames; gameIndex++)
            {                
                GameState gs = new GameState(learningPlayer, environmentPlayer);
                List<AgentState> agentStatesThisGame = new List<AgentState>();
                List<Move> actionsThisGame = new List<Move>();

                while (gs.GameIsOver() == false)
                {                   
                    if (gs.GetCurrentPlayer().GetColor() == learningPlayer.GetColor())
                    {
                        AgentState agentState = new AgentState(gs.GetBoard());
                        if(this.qTable.Contains(agentState) == false)
                        {
                            qTable.Add(agentState);
                        }
                        agentStatesThisGame.Add(agentState);
                        learningPlayer.GenerateNewRandomMove(gs, true, agentState, actionsThisGame);
                    }
                    else
                    {
                        environmentPlayer.GenerateNewRandomMove(gs);
                    }
                }


            }
        }

        public void UpdateQTable(List<AgentState> agentStatesThisGame, List<Move> actionsThisGame, int reward)
        {
            /*int newState = currentAction;
            qTable[currentState][currentAction] += alpha * (reward + gamma * qTable[newState].Max() - qTable[currentState][currentAction]);*/

            // идем с конца, учитывая результат партии
            for(int i = agentStatesThisGame.Count - 1; i >= 0; i--)
            {
                foreach(var agentState in qTable)
                {
                    if(agentStatesThisGame[i].Equals(agentState))
                    {
                        //actionIndex = GetActionIndex(agentState, actionsThisGame[i]);
                        //agentState.actionsPrices[i] += 
                    }
                }
            }
        }

        public int GetActionIndex(AgentState state, Move action)
        {
            int index = 0;
            for(int i = 0; i < state.actions.Count; i++)
            {
                if(state.actions[i].Equals(action))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
