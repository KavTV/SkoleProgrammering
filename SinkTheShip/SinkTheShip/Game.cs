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

        bool turn;
        bool isGameBegun = false;
        public Button CurrentShip { get { return currentShip; } set { currentShip = value; } }
        public bool IsGameBegun { get => isGameBegun; set => isGameBegun = value; }
        public bool Turn { get => turn; }

        public Game()
        {
        }


        public void PlaceShip(object sender, int selectedPlayer, string direction, Grid Player1Grid, Grid Player2Grid) // Place the whole ship
        {
            if (CurrentShip == null) // if no selected ship, do nothing
            {
                return;
            }
            Button btn = sender as Button;

            int row = Grid.GetRow(btn);
            int column = Grid.GetColumn(btn);
            bool allShipsMoved = false;
            if (selectedPlayer == 1)
            {
                allShipsMoved = player1.PlaceShip(btn, CurrentShip.Tag.ToString(), row, column, direction, Player1Grid);
            }
            else
            {
                allShipsMoved = player2.PlaceShip(btn, CurrentShip.Tag.ToString(), row, column, direction, Player2Grid);
            }
            if (allShipsMoved == true)
            {

                CurrentShip.IsEnabled = false;
                //Player1Grid.IsEnabled = false;
                CurrentShip = null;
            }

        }

        public string ShootPlayer(int row, int column)
        {

            if (Turn == false)
            {

                return player2.ShootPlayer(row, column);
            }
            else
            {

                return player1.ShootPlayer(row, column);
            }

        }

        public void changeTurn()
        {
            
            if (Turn == false)
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
        }

        public void EnableAllBTNS()
        {
            player1.EnableAllBtns();
            player2.EnableAllBtns();
        }

        public string HasPlayerWon()
        {
            bool player1Won = player1.HasPlayerWon();
            bool player2Won = player2.HasPlayerWon();
            if (player1Won == true)
            {
                return "Spiller 2 har vundet!";
            }
            else if (player2Won == true)
            {
                return "Spiller 1 har vundet!";
            }
            return null;
        }




    }
}
