using System;
using System.IO;

namespace AdventOfCode.TwentySixteen.Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Advent Of Code 2016 ***");
            Console.WriteLine("--- Day 2: Bathroom Security ---");
            Console.WriteLine();
            var map = new Map(3,3);
            map.GoToPos(1,1); // start at the middle button (the "5")
            // populate the button rows with values
            map.MapPoints[0,0]='7';
            map.MapPoints[1,0]='8';
            map.MapPoints[2,0]='9';

            map.MapPoints[0,1]='4';
            map.MapPoints[1,1]='5';
            map.MapPoints[2,1]='6';

            map.MapPoints[0,2]='1';
            map.MapPoints[1,2]='2';
            map.MapPoints[2,2]='3';
            string BathroomCode = string.Empty;


            var arrKeyLines=File.ReadAllLines("input.txt");
            for(int n = 0; n< arrKeyLines.Length; n++)
            {
                for(int z=0; z< arrKeyLines[n].Length; z++)
                {
                    map.Move(arrKeyLines[n][z]);
                }
                // we're at the end of the line now, let's get the key we're at and store it.
                BathroomCode += map.GetMapPointData(map.AtX,map.AtY).ToString();
            }
            System.Console.WriteLine($"Step 1 Result: {BathroomCode}");

            // Go on with step 2
            var map2 = new Map(5,5);
            map2.GoToPos(0,2); // Start at the '5'
            // Populate the keys with their respective values, and the other places with '!'
            map2.MapPoints[0,0]='!';
            map2.MapPoints[1,0]='!';
            map2.MapPoints[2,0]='D';
            map2.MapPoints[3,0]='!';
            map2.MapPoints[4,0]='!';
            
            map2.MapPoints[0,1]='!';
            map2.MapPoints[1,1]='A';
            map2.MapPoints[2,1]='B';
            map2.MapPoints[3,1]='C';
            map2.MapPoints[4,1]='!';

            map2.MapPoints[0,2]='5';
            map2.MapPoints[1,2]='6';
            map2.MapPoints[2,2]='7';
            map2.MapPoints[3,2]='8';
            map2.MapPoints[4,2]='9';

            map2.MapPoints[0,3]='!';
            map2.MapPoints[1,3]='2';
            map2.MapPoints[2,3]='3';
            map2.MapPoints[3,3]='4';
            map2.MapPoints[4,3]='!';

            map2.MapPoints[0,4]='!';
            map2.MapPoints[1,4]='!';
            map2.MapPoints[2,4]='1';
            map2.MapPoints[3,4]='!';
            map2.MapPoints[4,4]='!';

            BathroomCode = string.Empty;
            for(int n = 0; n< arrKeyLines.Length; n++)
            {
                for(int z=0; z< arrKeyLines[n].Length; z++)
                {
                    map2.Move(arrKeyLines[n][z]);
                }
                // we're at the end of the line now, let's get the key we're at and store it.
                BathroomCode += map2.GetMapPointData(map2.AtX,map2.AtY).ToString();
            }
            System.Console.WriteLine($"Step 2 Result: {BathroomCode}");
        }
    }
}
