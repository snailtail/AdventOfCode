using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Helpers
{
 
    /// <summary>
    /// A map for keeping track of travel in 4 directions.
    /// Every coordinate on the path taken is saved in visitedCoordinates.
    /// Coordinates are stored as string of format x:y
    /// </summary>
    public class FourWayMap
    {
        public int x = 0;
        public int y = 0;
        public string coordinate => $"{x}:{y}";
        public List<string> visitedCoordinates = new List<string>();
        public string originCoordinate;

        public FourWayMap(int X = 0, int Y = 0)
        {
            x = X;
            y = Y;
            originCoordinate = coordinate;
            //visitedCoordinates.Add(originCoordinate);
        }

        #region move_around

        private void MoveUp(int Steps)
        {
            for (int i = 0; i < Steps; i++)
            {
                y++;
                visitedCoordinates.Add(coordinate);
            }
        }
        private void MoveDown(int Steps)
        {
            for (int i = 0; i < Steps; i++)
            {
                y--;
                visitedCoordinates.Add(coordinate);
            }
        }
        private void MoveRight(int Steps)
        {
            for (int i = 0; i < Steps; i++)
            {
                x++;
                visitedCoordinates.Add(coordinate);
            }
        }

        private void MoveLeft(int Steps)
        {
            for (int i = 0; i < Steps; i++)
            {
                x--;
                visitedCoordinates.Add(coordinate);
            }
        }
        #endregion

        #region parse input
        public void Move(string MoveInstruction)
        {
            //try to parse what is the meaning.
            // kolla om det är en bokstav följt av en integer
            // u och n är upp (up, north)
            // d och s är ner (down, south)
            // r och e är höger (right, east)
            // l och w är vänster (left, west)
            string[] checks = { @"^([undswler]{1})([0-9]{1,})", @"(nw|ne|sw|se)([0-9]{1,})", @"(north|west|south|east|up|down|left|right)([0-9]{1,})" };

            string direction = "?";
            int steps = 0;
            foreach (var check in checks)
            {
                var rg = new Regex(check);
                var match = rg.Match(MoveInstruction.ToLower());
                if (match.Success)
                {
                    direction = match.Groups[1].Value;
                    steps = int.Parse(match.Groups[2].Value);
                    break;
                }
            }

            switch (direction)
            {
                case "n":
                case "u":
                case "up":
                case "north":
                    direction = "n";
                    break;
                case "s":
                case "d":
                case "down":
                case "south":
                    direction = "s";
                    break;
                case "e":
                case "r":
                case "east":
                case "right":
                    direction = "e";
                    break;
                case "w":
                case "l":
                case "west":
                case "left":
                    direction = "w";
                    break;
            }
            Move(direction, steps);
        }
        public void Move(string Direction, int Steps)
        {
            switch (Direction)
            {
                case "?":
                    Console.WriteLine("Unknown Direction...!");
                    break;
                case "n":
                    MoveUp(Steps);
                    break;
                case "s":
                    MoveDown(Steps);
                    break;
                case "e":
                    MoveRight(Steps);
                    break;
                case "w":
                    MoveLeft(Steps);
                    break;
            }
            //n, s, w, e
        }
        #endregion
    }
}