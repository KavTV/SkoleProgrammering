using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SinkTheShip
{
    class Player
    {

        Board board = new Board();

        public Player() { }


        public bool PlaceShip(Button btn, string CurrentShip, int row, int column, string direction, Grid PlayerGrid)
        {
            return board.PlaceShip(btn, CurrentShip, row, column, direction, PlayerGrid);
        }

        public string ShootPlayer( int row, int column)
        {
            return board.Attack( row, column);
        }
        public void EnableAllBtns()
        {
            board.EnableAllBtns();
        }
        

        public bool HasPlayerWon()
        {
            return board.HasPlayerWon();
        }
    }
}
