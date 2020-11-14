using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KataSolutions.BattleshipFieldValidator
{
    public class BattleshipFieldValidatorKata
    {
        enum ShipType
        {
            Battleship,
            Cruiser,
            Destroyer,
            Sub,
            Error
        }


        class Ship
        {
            public Ship(Tuple<int, int> firstCoord)
            {
                ShipCoords.Add(firstCoord);
            }

            public ShipType Type
            {
                get
                {
                    switch (ShipCoords.Count())
                    {
                        case 4:
                            return ShipType.Battleship;

                        case 3:
                            return ShipType.Cruiser;

                        case 2:
                            return ShipType.Destroyer;

                        case 1:
                            return ShipType.Sub;

                        default:
                            return ShipType.Error;
                    }
                }
            }

            public List<Tuple<int, int>> ShipCoords { get; set; } = new List<Tuple<int, int>>();


            public bool AddCoord(Tuple<int, int> newCoord)
            {
                bool output = false;

                if (ShipCoords.Count() < 2)
                {
                    ShipCoords.Add(newCoord);
                    output = true;
                }
                else if (ShipCoords.Count() < 4)
                {
                    // Check direction
                    if (ShipCoords.First().Item1 == ShipCoords.Last().Item1)
                    {
                        // moving in y direction, x should be the same
                        if (newCoord.Item1 == ShipCoords.First().Item1)
                        {
                            ShipCoords.Add(newCoord);
                            output = true;
                        }

                    }
                    else
                    {
                        // moving in x direction, y should be the same
                        if (newCoord.Item2 == ShipCoords.First().Item2)
                        {
                            ShipCoords.Add(newCoord);
                            output = true;
                        }
                    }
                }

                return output;
            }
        }

        // TODO - consider ways to reduce complexity
        // Due to many methods, consider adding xml comments? Even though it is for codewars?
        public static bool ValidateBattlefield(int[,] field)
        {
            List<Tuple<int, int>> illegalCoords = new List<Tuple<int, int>>();
            List<Ship> ships = new List<Ship>();

            // Write your magic here
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    // moving column by column
                    if (field[i, j] != 0)
                    {
                        var currentCoord = new Tuple<int, int>(i, j);

                        if (!CheckIfLegalCoord(illegalCoords, currentCoord))
                        {
                            return false;
                        }

                        AddNotlegalDiags(illegalCoords, currentCoord);

                        Ship existingShip = GetExistingShip(ships, currentCoord);
                        if (existingShip == null)
                        {
                            ships.Add(new Ship(currentCoord));
                        }
                        else
                        {
                            // add to the existing ship
                            if (!existingShip.AddCoord(currentCoord))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return CheckForRequiredShips(ships);
        }

        private static bool CheckForRequiredShips(List<Ship> ships)
        {
            bool oneBattleship = ships.Where(x => x.Type == ShipType.Battleship).Count() == 1;
            bool twoCruisers = ships.Where(x => x.Type == ShipType.Cruiser).Count() == 2;
            bool threeDestroyers = ships.Where(x => x.Type == ShipType.Destroyer).Count() == 3;
            bool fourSubs = ships.Where(x => x.Type == ShipType.Sub).Count() == 4;

            return oneBattleship && twoCruisers && threeDestroyers && fourSubs;
        }

        private static Ship GetExistingShip(List<Ship> ships, Tuple<int, int> currentCoord)
        {
            var validParentCoords = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(currentCoord.Item1 - 1, currentCoord.Item2),
                new Tuple<int, int>(currentCoord.Item1 + 1, currentCoord.Item2),

                new Tuple<int, int>(currentCoord.Item1, currentCoord.Item2 - 1),
                new Tuple<int, int>(currentCoord.Item1, currentCoord.Item2 + 1)
            };

            Ship parentShip = null;
            foreach (Tuple<int, int> parentCoord in validParentCoords)
            {
                Ship ship = ships.FirstOrDefault(x => x.ShipCoords.Contains(parentCoord));
                if (ship != null)
                {
                    parentShip = ship;
                }
            }

            return parentShip;
        }

        private static void AddNotlegalDiags(List<Tuple<int, int>> illegalCoords, Tuple<int, int> currentCoord)
        {
            // Create diag Coords
            illegalCoords.Add(new Tuple<int, int>(currentCoord.Item1 - 1, currentCoord.Item2 + 1));
            illegalCoords.Add(new Tuple<int, int>(currentCoord.Item1 - 1, currentCoord.Item2 - 1));

            illegalCoords.Add(new Tuple<int, int>(currentCoord.Item1 + 1, currentCoord.Item2 + 1));
            illegalCoords.Add(new Tuple<int, int>(currentCoord.Item1 + 1, currentCoord.Item2 - 1));
        }

        private static bool CheckIfLegalCoord(List<Tuple<int, int>> illegalCoords, Tuple<int, int> coord)
        {
            bool output = true;
            if (illegalCoords.Contains(coord))
            {
                output = false;
            }
            return output;
        }


    }
}
