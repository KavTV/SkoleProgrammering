using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SinkTheShip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Game game = new Game();

        int selectedPlayer; // 1 = player 1, 2 = player 2
        string direction;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.IsGameBegun == false)
            {
                game.PlaceShip(sender, selectedPlayer, direction, Player1Grid, Player2Grid);
            }
            else
            {
                Button btn = sender as Button;
                //Set row and column of Button
                int row;
                int column;
                row = Grid.GetRow(btn);
                column = Grid.GetColumn(btn);

                string isHit = game.ShootPlayer(row, column);
                if (isHit == "Hit")
                {
                    btn.Background = Brushes.Red;
                }
                else if (isHit == "Miss")
                {
                    btn.Background = Brushes.Black;
                }
                else
                {
                    return;
                }

                //Thread.Sleep(1000);
                game.changeTurn();
                switch (game.Turn)
                {
                    case false: Player2Grid.IsEnabled = true; Player1Grid.IsEnabled = false; break;
                    case true: Player2Grid.IsEnabled = false; Player1Grid.IsEnabled = true; break;
                }

                string playerWon = game.HasPlayerWon();
                if (playerWon != null)
                {
                    PlayerWinLabel.Content = playerWon;
                }

            }
        }



        private void SelectShipClk(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            game.CurrentShip = btn;
        }
        private void SelectPlayer(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag)
            {
                case "Player1":
                    game.CurrentShip = null;
                    selectedPlayer = 1;
                    Player1Grid.IsEnabled = true;
                    Player1Panel.IsEnabled = true;
                    Player2Grid.IsEnabled = false;
                    Player2Panel.IsEnabled = false;
                    break;
                case "Player2":
                    game.CurrentShip = null;
                    selectedPlayer = 2;
                    Player2Grid.IsEnabled = true;
                    Player2Panel.IsEnabled = true;
                    Player1Grid.IsEnabled = false;
                    Player1Panel.IsEnabled = false;
                    break;
                default:
                    break;
            }

        }

        private void StartGame(object sender, RoutedEventArgs e) // Enable all buttons and set isgamebegun to true
        {
            // if all ship Buttons are disabled, start game
            if (ScoutBoatBTN.IsEnabled == false && SubmarineBTN.IsEnabled == false && DestroyerBTN.IsEnabled == false && BattleShipBTN.IsEnabled == false && CarrierBTN.IsEnabled == false && ScoutBoatBTN2.IsEnabled == false && SubmarineBTN2.IsEnabled == false && DestroyerBTN2.IsEnabled == false && BattleShipBTN2.IsEnabled == false && CarrierBTN2.IsEnabled == false)
            {
                game.EnableAllBTNS();
                Player2Grid.IsEnabled = true;
                Player1Grid.IsEnabled = false;
                SelectPlayer1.IsEnabled = false;
                SelectPlayer2.IsEnabled = false;
                game.IsGameBegun = true;

            }

        }

        private void ResetGameClk(object sender, RoutedEventArgs e)
        {

        }



        private void DirectionClk(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            direction = btn.Tag.ToString();
        }
    }
}
