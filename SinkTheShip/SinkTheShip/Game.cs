using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SinkTheShip
{
    class Game
    {


        Player player1 = new Player();
        Player player2 = new Player();
        Button currentShip;
        List<Button> clickedButtonList = new List<Button>();
        bool turn;
        bool isGameBegun = false;

        public Game()
        {
        }

        public Button CurrentShip { get => currentShip; set => currentShip = value; }
        public bool IsGameBegun { get => isGameBegun; set => isGameBegun = value; }

        public void PlaceBTN(object sender, int selectedPlayer) // place a part of the ship
        {
            if (CurrentShip == null)
            {
                return;
            }
            int row;
            int column;
            Button btn = sender as Button;


            row = Grid.GetRow(btn);
            column = Grid.GetColumn(btn);
            bool allShipsMoved = false;
            if (selectedPlayer == 1)
            {
                allShipsMoved = player1.PlaceShip(btn, CurrentShip.Tag.ToString(), row, column);
            }
            else
            {
                allShipsMoved = player2.PlaceShip(btn, CurrentShip.Tag.ToString(), row, column);
            }
            if (allShipsMoved == true)
            {

                CurrentShip.IsEnabled = false;
                //Player1Grid.IsEnabled = false;
                CurrentShip = null;
            }
            clickedButtonList.Add(btn);
        }

        public bool ShootPlayer()
        {
            
            return true;
        }

        public void EnableAllBTNS()
        {
            foreach (var item in clickedButtonList)
            {
                item.IsEnabled = true;
            }
        }

    }
}
