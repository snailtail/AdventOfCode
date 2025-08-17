using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Helpers;

namespace AdventOfCode.TwentySixteen.Day01
{
    class Program
    {
        private static Position CurrentPosition = new Position { x = 0, y = 0 };
        private static Compass myCompass = new Compass{Heading=0};
        private static int FirstDoubleVisit=-1;
        private static Dictionary<string, int> Visits = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            System.Console.WriteLine("*** Advent Of Code 2016 ***");
            System.Console.WriteLine("--- Day 1: No Time for a Taxicab ---");
            System.Console.WriteLine();
            Step1();
            Step2();
        }

        private static void Step1()
        {
            var fileContents = File.ReadAllText("input.txt");
            var arrSplit = fileContents.Split(", ", StringSplitOptions.None);
            for (int n = 0; n < arrSplit.Length; n++)
            {
                var TurnCode = arrSplit[n].Substring(0, 1).ToCharArray();
                var WalkSteps = int.Parse(arrSplit[n].Substring(1, arrSplit[n].Length - 1));
                TurnAndWalk(TurnCode[0], WalkSteps);
            }
            System.Console.WriteLine($"Step 1 Result: {ComputePositionValue()}");
        }

        private static void Step2()
        {
            System.Console.WriteLine($"Step 2 Result: {FirstDoubleVisit}");
        }

        private static int ComputePositionValue()
        {
            var posx = 0;
            var posy = 0;
            if (CurrentPosition.x < 0)
            {
                posx = -1 * CurrentPosition.x;
            }
            else
            {
                posx = CurrentPosition.x;
            }

            if (CurrentPosition.y < 0)
            {
                posy = -1 * CurrentPosition.y;
            }
            else
            {
                posy = CurrentPosition.y;
            }
            return posx + posy;
        }

        private static void TurnAndWalk(char Code, int NumberOfSteps)
        {

            // first turn - we modify heading (as in a compass heading)
            switch (Code)
            {
                case 'L':
                    myCompass.Turn90Degrees(Compass.TurnDirection.Left);
                    break;
                case 'R':
                    myCompass.Turn90Degrees(Compass.TurnDirection.Right);
                    break;

                default:
                    break;
            }

            // now walk
            for(int z =1; z<=NumberOfSteps; z++)
            {
                switch (myCompass.Heading)
                {
                    // due north, increase y
                    case 0:
                        CurrentPosition.y += 1;
                        break;

                    // due south, decrease y
                    case 180:
                        CurrentPosition.y -= 1;
                        break;

                    // due east, increase x
                    case 90:
                        CurrentPosition.x += 1;
                        break;

                    // due west, decrease x
                    case 270:
                        CurrentPosition.x -= 1;
                        break;
                    default:
                        break;
                }

                if(Visits.ContainsKey(CurrentPosition.Getstring()) && FirstDoubleVisit== -1)
                {
                    Visits[CurrentPosition.Getstring()]+=1;
                    FirstDoubleVisit=ComputePositionValue();
                }
                else if(Visits.ContainsKey(CurrentPosition.Getstring()))
                {
                    Visits[CurrentPosition.Getstring()]+=1;
                }
                else
                {
                    Visits.Add(CurrentPosition.Getstring(), 1);
                }
            }
            
        }


    }

    class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public string Getstring()
        {
            string retval = new string("");
            retval = $"{x},{y}";
            return retval;
        }
    }
}
