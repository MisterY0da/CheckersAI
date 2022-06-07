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
        private double alpha = 1;
        private double gamma = 0.9;
        public int epsilonInPercents = 10;

        public QLearning()
        {
            qTable = new List<AgentState>();
        }        

        public void Train(int numberOfGames)
        {
            ComputerPlayer environmentPlayer = new ComputerPlayer("black");
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
                        if(qTable.Contains(agentState) == false)
                        {
                            qTable.Add(agentState);
                        }
                        agentStatesThisGame.Add(agentState);
                        learningPlayer.GenerateNewMoveLearning(gs, true, agentState, actionsThisGame);                       
                    }
                    else
                    {
                        environmentPlayer.GenerateNewMoveLearning(gs);
                    }
                }

                int reward;
                // если у противника не осталось ходов
                if (environmentPlayer.GetAllAvailableMoves(gs.GetBoard()).Count == 0)
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
            CalculateGameActionsPrices(agentStatesThisGame, actionsThisGame, reward);
            
            foreach (var state in qTable)
            {
                foreach (var stateThisGame in agentStatesThisGame)
                {
                    if(stateThisGame.Equals(state))
                    {
                        UpdateQTablePrices(state, stateThisGame);
                    }
                }
            }
        }

        public void CalculateGameActionsPrices(List<AgentState> agentStatesThisGame, List<Move> actionsThisGame, int reward)
        {
            // идем с конца, учитывая результат партии
            int actionIndex = GetActionIndex(agentStatesThisGame[actionsThisGame.Count-1], actionsThisGame[actionsThisGame.Count-1]);
            agentStatesThisGame[actionsThisGame.Count-1].actionsPrices[actionIndex] = reward;

            for (int i = actionsThisGame.Count - 2; i >= 0; i--)
            {
                actionIndex = GetActionIndex(agentStatesThisGame[i], actionsThisGame[i]);
                agentStatesThisGame[i].actionsPrices[actionIndex] +=
                    alpha * (reward + gamma * GetMaxActionValue(agentStatesThisGame[i]) - agentStatesThisGame[i].actionsPrices[actionIndex]);
            }
        }

        public void UpdateQTablePrices(AgentState qTableState, AgentState ThisGameState)
        {
            for(int i = 0; i < ThisGameState.actions.Count; i++)
            {
                if(qTableState.actions.Contains(ThisGameState.actions[i]))
                {
                    int actionIndex = GetActionIndex(qTableState, ThisGameState.actions[i]);
                    qTableState.actionsPrices[actionIndex] += ThisGameState.actionsPrices[i];
                }
                else
                {
                    qTableState.actions.Add(ThisGameState.actions[i]);
                    qTableState.actionsPrices.Add(ThisGameState.actionsPrices[i]);
                }
            }
        }

        public double GetMaxActionValue(AgentState state)
        {
            double maxValue = state.actionsPrices[0];

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
            for(int i = 0; i < state.actions.Count; i++)
            {
                if(state.actions[i].Equals(action))
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
