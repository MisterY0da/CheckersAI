using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Checkers
{
    public partial class MainWindow : Window
    {
        static QLearning qLearning = new QLearning();
        static ComputerPlayer p1 = new ComputerPlayer("white", qLearning);
        static HumanPlayer p2 = new HumanPlayer("black");
        GameState gs = new GameState(p1, p2);
        public MainWindow()
        {
            
            //qLearning.Train(100);
            
            
            InitializeComponent();

            ShowBoardState(gs);
        }

        private void ShowBoardState(GameState gs)
        {
            var collection = this.BoardUniformGrid.Children;
            collection.Clear();
            TextBox tb;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tb = new TextBox();
                    if ((i + j) % 2 == 0)
                    {
                        tb.Background = Brushes.Moccasin;
                    }
                    else
                    {

                        if (gs.GetBoard()[i][j] == 'b')
                        {
                            ImageBrush textImageBrush = new ImageBrush();
                            textImageBrush.ImageSource =
                            new BitmapImage(
                                new Uri(@"black.png", UriKind.Relative)
                            );
                            textImageBrush.AlignmentX = AlignmentX.Center;
                            tb.Background = textImageBrush;
                        }
                        else if (gs.GetBoard()[i][j] == 'w')
                        {
                            ImageBrush textImageBrush = new ImageBrush();
                            textImageBrush.ImageSource =
                            new BitmapImage(
                                new Uri(@"white.png", UriKind.Relative)
                            );
                            textImageBrush.AlignmentX = AlignmentX.Center;
                            tb.Background = textImageBrush;
                        }

                        else if (gs.GetBoard()[i][j] == 'B')
                        {
                            ImageBrush textImageBrush = new ImageBrush();
                            textImageBrush.ImageSource =
                            new BitmapImage(
                                new Uri(@"blackKing.png", UriKind.Relative)
                            );
                            textImageBrush.AlignmentX = AlignmentX.Center;
                            tb.Background = textImageBrush;
                        }
                        else if (gs.GetBoard()[i][j] == 'W')
                        {
                            ImageBrush textImageBrush = new ImageBrush();
                            textImageBrush.ImageSource =
                            new BitmapImage(
                                new Uri(@"whiteKing.png", UriKind.Relative)
                            );
                            textImageBrush.AlignmentX = AlignmentX.Center;
                            tb.Background = textImageBrush;
                        }

                        else
                        {
                            tb.Background = Brushes.Brown;
                        }
                    }
                    collection.Add(tb);
                }
            }

            var moves = gs.GetCurrentPlayer().GetAllAvailableMoves(gs.GetBoard());

            MovesCmbBox.Items.Clear();

            foreach (var move in moves)
            {
                string moveString = "стр." + move.RowStart + ",кол." + move.ColStart + "->стр." + move.RowEnd + ",кол." + move.ColEnd;
                MovesCmbBox.Items.Add(moveString);
            }
        }

        private void MovesCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MakeMoveBtn_Click(object sender, RoutedEventArgs e)
        {
            string moveString = MovesCmbBox.SelectedItem.ToString();
            p2.currentMove = GetMoveFromCmbBox();
            p2.GenerateNewMove(gs);
            p1.GenerateNewMove(gs);
            ShowBoardState(gs);
        }

        public Move GetMoveFromCmbBox()
        {
            string moveString = MovesCmbBox.SelectedItem.ToString();
            return new Move(int.Parse(moveString[4].ToString()), int.Parse(moveString[10].ToString()), int.Parse(moveString[17].ToString()), int.Parse(moveString[23].ToString()));
        }
    }

}
