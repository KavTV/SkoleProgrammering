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
        public bool Turn { get => turn;}

        public void PlaceBTN(object sender, int selectedPlayer, string direction) // place a part of the ship
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
                allShipsMoved = player1.PlaceShip(btn, CurrentShip.Tag.ToString(), row, column, direction);
            }
            else
            {
                allShipsMoved = player2.PlaceShip(btn, CurrentShip.Tag.ToString(), row, column, direction);
            }
            if (allShipsMoved == true)
            {

                CurrentShip.IsEnabled = false;
                //Player1Grid.IsEnabled = false;
                CurrentShip = null;
            }
            clickedButtonList.Add(btn);
        }

        public string ShootPlayer(int row,int column)
        {
            
            if (Turn == false)
            {
               
                return player2.ShootPlayer(row,column);
            }
            else
            {
                
                return player1.ShootPlayer(row,column);
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
            foreach (var item in clickedButtonList)
            {
                item.IsEnabled = true;
            }
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
