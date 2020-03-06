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
        List<Button> DisabledBtnList = new List<Button>();


        public Board()
        {
            allShips.Add(new Ship(5, "Carrier"));
            allShips.Add(new Ship(4, "Battleship"));
            allShips.Add(new Ship(3, "Destroyer"));
            allShips.Add(new Ship(3, "Submarine"));
            allShips.Add(new Ship(2, "ScoutBoat"));
        }



        public bool PlaceShip(Button clickedBTN, string shipName, int row, int column, string direction, Grid PlayerGrid)
        {
            //Make sure fields are empty and a ship is selected
            if (shipName == null)
            {
                return false;
            }
            if (shipPositions[row, column] != null)
            {
                return false;
            }


            foreach (var item in allShips)
            {
                if (item.Name == shipName)
                {
                    switch (direction) // Try catch to prevent program from crashing by getting out of the array
                    {
                        case "Up":
                            try
                            {
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
                                    GetButtons(PlayerGrid, row - j, column);
                                }
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        case "Down":
                            try
                            {
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
                                    GetButtons(PlayerGrid, row + j, column);
                                }
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        case "Right":
                            try
                            {
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
                                    GetButtons(PlayerGrid, row, column + j);
                                }
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        case "Left":
                            try
                            {
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
                                    GetButtons(PlayerGrid, row, column - j);

                                }
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
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

        private void GetButtons(Grid PlayerGrid, int row, int column)
        {
            var itemsInFirstRow = PlayerGrid.Children
                                            .Cast<UIElement>()
                                            .Where(i => Grid.GetRow(i) == row && Grid.GetColumn(i) == column).FirstOrDefault();
            Button btn = itemsInFirstRow as Button;
            btn.IsEnabled = false;
            DisabledBtnList.Add(btn);
        }

        public void EnableAllBtns()
        {
            foreach (var item in DisabledBtnList)
            {
                item.IsEnabled = true;
            }
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
                            MessageBox.Show($"Du har sunket din modstanders {item.Name}", item.Name);
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




    }

}


