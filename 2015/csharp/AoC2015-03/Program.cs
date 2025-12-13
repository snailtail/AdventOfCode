using System;
using System.IO;

namespace AdventOfCode.TwentyFifteen.Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Advent Of Code 2015 ***");
            Console.WriteLine("--- Day 3: Perfectly Spherical Houses in a Vacuum ---");
            Console.WriteLine();

            var myInput = File.ReadAllText("input.txt");
            var myParser = new DirectionParser();
            foreach (char x in myInput)
            {
                var debug = myParser.Move(x);
            }
            Console.WriteLine($"Step 1 result: {myParser.CoordinateVisits.Count}");

            bool Robo = false;
            var NextYearParser = new DirectionParserNextYear();
            foreach (char x in myInput)
            {
                var debug = NextYearParser.Move(x, Robo);
                if (Robo == false)
                {
                    Robo = true;
                }
                else
                {
                    Robo = false;
                }
            }
            Console.WriteLine($"Step 2 result: {NextYearParser.CoordinateVisits.Count}");
        }
    }
}
