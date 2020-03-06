using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SinkTheShip
{
    class Board
    {
        string[,] shipPositions = new string[10, 10];

        List<Ship> allShips = new List<Ship>();



        public Board()
        {
            allShips.Add(new Ship(5, "Carrier"));
            allShips.Add(new Ship(4, "Battleship"));
            allShips.Add(new Ship(3, "Destroyer"));
            allShips.Add(new Ship(3, "Submarine"));
            allShips.Add(new Ship(2, "ScoutBoat"));
        }



        public bool PlaceShip(Button clickedBTN, string shipName, int row, int column, string direction)
        {
            if (shipName == null)
            {
                return false;
            }
            if (shipPositions[row, column] != null)
            {
                return false;
            }


            //clickedBTN.IsEnabled = false;
            foreach (var item in allShips)
            {
                if (item.Name == shipName)
                {
                    switch (direction)
                    {
                        case "Up":
                            for (int i = 0; i < item.Size; i++)
                            {
                                if (shipPositions[row - i, column] != null)
                                {
                                    return false;
                                }
                            }
                            for (int j = 0; j < item.Size; j++)
                            {
                                shipPositions[row - j, column] = shipName;
                            }
                            return true;
                        case "Down":
                            for (int i = 0; i < item.Size; i++)
                            {
                                if (shipPositions[row + i, column] != null)
                                {
                                    return false;
                                }
                            }
                            for (int j = 0; j < item.Size; j++)
                            {
                                shipPositions[row + j, column] = shipName;
                            }
                            return true;
                        case "Right":
                            for (int i = 0; i < item.Size; i++)
                            {
                                if (shipPositions[row, column + i] != null)
                                {
                                    return false;
                                }
                            }
                            for (int j = 0; j < item.Size; j++)
                            {
                                shipPositions[row, column + j] = shipName;
                            }
                            return true;
                        case "Left":
                            for (int i = 0; i < item.Size; i++)
                            {
                                if (shipPositions[row, column - i] != null)
                                {
                                    return false;
                                }
                            }
                            for (int j = 0; j < item.Size; j++)
                            {
                                shipPositions[row, column - j] = shipName;
                            }
                            return true;
                    }
                }
            }
            //foreach (var item in allShips)
            //{
            //    if (item.Name == shipName)
            //    {
            //        item.Size -= 1;
            //    }
            //    if (item.Name == shipName && item.Size <= 0)
            //    {
            //        switch (item.Name)
            //        {
            //            case "Carrier":
            //                item.Size = 5;
            //                break;
            //            case "Battleship":
            //                item.Size = 4;
            //                break;
            //            case "Destroyer":
            //                item.Size = 3;
            //                break;
            //            case "Submarine":
            //                item.Size = 3;
            //                break;
            //            case "ScoutBoat":
            //                item.Size = 2;
            //                break;
            //        }
            //        return true;
            //    }
            //}
            return false;

        }


        public string Attack(int row, int column)
        {

            if (shipPositions[row, column] != null && shipPositions[row, column] != "Destroyed")
            {
                foreach (var item in allShips)
                {
                    if (item.Name == shipPositions[row, column])
                    {
                        item.Size -= 1;
                        if (item.Size < 1)
                        {
                            MessageBox.Show($"Du har ødelagt din modstanders {item.Name}", item.Name);
                        }
                    }
                }
                shipPositions[row, column] = "Destroyed";
                return "Hit";
            }
            if (shipPositions[row, column] == "Destroyed")
            {
                return "";
            }
            return "Miss";
        }

        public bool HasPlayerWon()
        {
            int destroyedShips = 0;
            foreach (var item in allShips)
            {
                if (item.Size < 1)
                {
                    destroyedShips++;
                }
            }
            if (destroyedShips == 5)
            {
                return true;
            }
            return false;
        }

        public void ShipDestroyed()
        {

        }

        public void ResetBoard()
        {
            shipPositions = new string[10, 10];
        }

    }

}


