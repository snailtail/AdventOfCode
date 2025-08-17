using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Helpers;

namespace AoC2019_03
{
    class Program
    {
        private static FourWayMap fwMap1 = new FourWayMap();
        private static FourWayMap fwMap2 = new FourWayMap();

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            string[] wirePath1 = lines[0].Split(",");
            string[] wirePath2 = lines[1].Split(",");
            foreach (var p in wirePath1)
            {
                fwMap1.Move(p);
            }

            foreach (var p in wirePath2)
            {
                fwMap2.Move(p);
            }

            var coordMatches = fwMap1.visitedCoordinates.Where(i => fwMap2.visitedCoordinates.Contains(i)).ToList();
              
            
            int leastDistance = int.MaxValue;
            var manhattanCalculator = new ManhattanHelper();
            foreach (var crossing in coordMatches)
            {
                int distance = manhattanCalculator.CalculateManhattanDistance(crossing);
                if(distance<leastDistance)
                {
                    leastDistance = distance;
                }
            }
            Console.WriteLine($"Step 1: {leastDistance}");
        }
    }
}
