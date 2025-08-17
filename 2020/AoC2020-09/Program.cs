using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day09
{
    class Program
    {
        private static List<string> xmasData = new List<string>();
        private static List<long> sequence = new List<long>();
        private static int preamble = 25;
        static void Main(string[] args)
        {

            xmasData = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToList();
            // For Step 1 
            var firstWeakness = FindFirstWeakness(preamble);

            System.Console.WriteLine($"First step, weakness is: {firstWeakness}");

            System.Console.WriteLine($"Second step, weakness is: {FindSecondWeakness(firstWeakness)}");
        }

        private static long FindFirstWeakness(int Preamble)
        {

            // start at preamble (-1) and check the next numbers value.
            bool keepGoing = true;
            var testPosition = Preamble; //the first time we check at Preamble value which is the first number after the Preamble-amount of numbers in the list (0-pos indexing you know)
            while (keepGoing && testPosition < xmasData.Count)
            {
                var valid = false;
                // Outer loop
                for (int x = testPosition - Preamble; x < testPosition - 1; x++)
                {
                    //Inner loop
                    for (int y = testPosition - Preamble + 1; y < testPosition; y++)
                    {
                        //System.Console.WriteLine($"DEBUG: Testing {xmasData[x]} + {xmasData[y]}");
                        if (xmasData[x] != xmasData[y] && (long.Parse(xmasData[x]) + long.Parse(xmasData[y]) == long.Parse(xmasData[testPosition])))
                        {
                            valid = true;
                        }
                    }
                }
                if (valid)
                {
                    keepGoing = true;
                    testPosition++;
                }
                else
                {
                    keepGoing = false;
                }

            }
            return long.Parse(xmasData[testPosition]);
        }

        private static long FindSecondWeakness(long FirstNumber)
        {
            // find any contigous sequence of at least two numbers that add up to exactly the FirstNumber
            // add together the smallest and largest of these contigous numbers, and return that sum.
            long testSum = 0;
            bool keepCrunching = true;
            int x = 0;

            while (keepCrunching && x < xmasData.Count)
            {
                testSum += long.Parse(xmasData[x]);
                sequence.Add(long.Parse(xmasData[x]));
                for (int y = x + 1; y < xmasData.Count; y++)
                {
                    testSum += long.Parse(xmasData[y]);
                    sequence.Add(long.Parse(xmasData[y]));
                    //System.Console.WriteLine($"DEBUG: testSum={testSum} (FirstNumber={FirstNumber}) ");
                    if (testSum == FirstNumber)
                    {
                        // we found a match!
                        keepCrunching = false;
                        break;

                    }

                    if (testSum > FirstNumber)
                    {
                        sequence.Clear();
                        testSum = 0;
                        x++;
                        break;
                    }
                }
            }
            sequence.Sort();
            return (sequence.Min() + sequence.Max());
        }
    }
}
