using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        int selectedPlayer;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (game.IsGameBegun == false)
            {
                game.PlaceBTN(sender, selectedPlayer);
            }
            else
            {
                game.ShootPlayer();
            }
        }



        private void PlaceShipClk(object sender, RoutedEventArgs e)
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
                    Player2Gid.IsEnabled = false;
                    Player2Panel.IsEnabled = false;
                    break;
                case "Player2":
                    game.CurrentShip = null;
                    selectedPlayer = 2;
                    Player2Gid.IsEnabled = true;
                    Player2Panel.IsEnabled = true;
                    Player1Grid.IsEnabled = false;
                    Player1Panel.IsEnabled = false;
                    break;
                default:
                    break;
            }

        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            game.EnableAllBTNS();
            game.IsGameBegun = true;
            game.ShootPlayer();
        }
    }
}
