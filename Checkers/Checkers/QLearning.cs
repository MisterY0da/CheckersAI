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
            for (int gameIndex = 0; gameIndex < numberOfGames; gameIndex++)
            {
                ComputerPlayer environmentPlayer = new ComputerPlayer("black", this);
                ComputerPlayer learningPlayer = new ComputerPlayer("white", this);
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

                int reward;
                // если у противника не осталось ходов
                if(environmentPlayer.GetAllAvailableMoves(gs.GetBoard()).Count == 0)
                {
                    reward = 100;
                }
                else
                {
                    reward = -100;
                }

                UpdateQTable(agentStatesThisGame, actionsThisGame, reward);
            }
        }

        public void UpdateQTable(List<AgentState> agentStatesThisGame, List<Move> actionsThisGame, int reward)
        {
            // идем с конца, учитывая результат партии
            for(int i = agentStatesThisGame.Count - 1; i >= 0; i--)
            {
                foreach(var agentState in qTable)
                {
                    if(agentStatesThisGame[i].Equals(agentState))
                    {
                        int actionIndex = GetActionIndex(agentState, actionsThisGame[i]);

                        if (i == agentStatesThisGame.Count - 1)
                        {
                            agentState.actionsPrices[actionIndex] += reward;
                        }

                        else
                        {
                            //действие совершенное в этом состоянии                            
                            agentState.actionsPrices[actionIndex] +=
                                alpha * (reward + gamma * GetMaxActionValue(agentState) - agentState.actionsPrices[actionIndex]);
                        }

                        break;
                    }
                }
            }
        }

        public double GetMaxActionValue(AgentState state)
        {
            double maxValue = -999;

            for (int i = 0; i < state.actionsPrices.Count; i++)
            {
                if(state.actionsPrices[i] > maxValue)
                {
                    maxValue = state.actionsPrices[i];
                }
            }

            return maxValue;
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
