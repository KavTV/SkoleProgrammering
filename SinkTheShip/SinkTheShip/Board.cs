using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace SinkTheShip
{
    class Board
    {
        string[,] shipPositions = new string[10, 10];
        //Ship carrierShip = new Ship(5);
        //Ship battleShip = new Ship(4);
        //Ship destroyer = new Ship(3);
        //Ship submarine = new Ship(3);
        //Ship scoutBoat = new Ship(2);
        List<Ship> allShips = new List<Ship>();

        public Board()
        {
            allShips.Add(new Ship(5, "Carrier"));
            allShips.Add(new Ship(4, "Battleship"));
            allShips.Add(new Ship(3, "Destroyer"));
            allShips.Add(new Ship(3, "Submarine"));
            allShips.Add(new Ship(2, "ScoutBoat"));
        }



        public bool PlaceShip(Button clickedBTN, string shipName, int row, int column)
        {
            if (shipName == null)
            {
                return false;
            }
            if (shipPositions[row, column] != null)
            {
                return false;
            }


            shipPositions[row, column] = shipName;
            clickedBTN.IsEnabled = false;

            foreach (var item in allShips)
            {
                if (item.Name == shipName)
                {
                    item.Size -= 1;
                }
                if (item.Name == shipName && item.Size <= 0)
                {
                    return true;
                }
            }
            return false;

        }


        //public bool Attack()
        //{
        //    return;
        //}

    }

}


