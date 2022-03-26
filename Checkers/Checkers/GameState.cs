using System;
using System.Text;

namespace Checkers
{
    public class GameState
    {
        private Player _player1 { get; set; }
        private Player _player2 { get; set; }
        private Player _currentPlayer { get; set; }
        private char[][] _board = new char[8][]
        {
            new char[8]{'_', 'w', '_', 'w', '_', 'w', '_', 'w'},
            new char[8]{'w', '_', 'w', '_', 'w', '_', 'w', '_'},
            new char[8]{'_', 'w', '_', 'w', '_', 'w', '_', 'w'},
            new char[8]{'_', '_', '_', '_', '_', '_', '_', '_'},
            new char[8]{'_', '_', '_', '_', '_', '_', '_', '_'},
            new char[8]{'b', '_', 'b', '_', 'b', '_', 'b', '_'},
            new char[8]{'_', 'b', '_', 'b', '_', 'b', '_', 'b'},
            new char[8]{'b', '_', 'b', '_', 'b', '_', 'b', '_'},
        };

        public GameState(Player p1, Player p2)
        {
            _player1 = p1;
            _player2 = p2;

            // черные ходят первыми
            _currentPlayer = _player1.GetColor() == "black" ? _player1 : _player2;
        }

        public void ChangeBoardCell(int row, int col, char value)
        {
            _board[row][col] = value;
        }

        public bool GameIsOver()
        {
            if(_currentPlayer.GetAllAvailableMoves(_board).Count == 0)
            {
                return true;
            }
            
            return false;
        }

        public void ShowBoard()
        {
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 8; i++) { Console.Write(" " + i); }
            Console.ResetColor();

            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(i + " ");
                Console.ResetColor();

                for (int j = 0; j < 8; j++)
                {
                    Console.Write(_board[i][j] + " ");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(i);
                Console.ResetColor();

                Console.WriteLine();
            }

            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 8; i++) { Console.Write(" " + i); }
            Console.ResetColor();

            Console.WriteLine("\nwho moves: " + _currentPlayer.GetColor());
        }

        public char[][] GetBoard()
        {
            return _board;
        }

        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void SwitchPlayer()
        {
            if(_currentPlayer.GetColor() == _player1.GetColor())
            {
                _currentPlayer = _player2;
            }
            
            else
            {
                _currentPlayer = _player1;
            }
        }

        public string GetBoardString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sb.Append(_board[i][j]);
                }
            }

            return sb.ToString();
        }
    }
}
