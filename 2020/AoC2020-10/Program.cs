using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day10
{
    class Program
    {
        static List<int> joltages = new List<int>();


        static void Main(string[] args)
        {

            LoadAdaptersFromList();
            Step1();
            Step2();

        }

        private static void Step1()
        {
            int[] joltDiffCounts = new int[3];
            for (int i = 0; i < joltages.Count - 1; i++)
            {
                int joltageRange = joltages[i + 1] - joltages[i];

                joltDiffCounts[joltageRange - 1]++;
            }

            System.Console.WriteLine($"Step 1 results: { joltDiffCounts[0] * joltDiffCounts[2]}");
        }

        private static void Step2()
        {
            //Get list of length of all continguous 1-jolt adapters gaps.
            //The adapters on the ends are not counted as they are required to be in the sequence to support their 3-jolt gap.
            //Eg: 0    3 4 5 6 7 8    11 -> count is 5 (4-8)
            //    0    3 4 5     8       -> count is 1 (4)
            //    0    3 4 5 6      9    -> count is 2 (4-6)

            List<int> oneJoltRunLengths = new List<int>();
            int contiguousCount = 0;
            for (int i = 0; i < joltages.Count - 1; i++)
            {
                if (joltages[i + 1] - joltages[i] == 1)
                {
                    contiguousCount++;
                }
                else
                {
                    contiguousCount--;
                    if (contiguousCount >= 1)
                    {
                        oneJoltRunLengths.Add(contiguousCount);
                    }
                    contiguousCount = 0;
                }

            }

            //Getting the total number of combinations means finding how many ways in which adapters can be left unused from sequence
            //Adapters can be left out as long as they don't create a three-jolt gap.
            //The list of oneJoltRunLengths has been prepared as counts of
            //  runs of adapters that can be removed in that they're not required to span a 3-jolt gap (see above). So the question is, how many
            //  combinations are there for a run of 1-jolt adapter gaps that don't create a gap of 3 or more.
            //For a single adapter, there are two ways.  (0, 1)
            //For two adapters in a row, there are four. (00, 01, 10, 11)
            //For three, there are seven ways            (001, 010, 011, 100, 101, 110, 111 -> just not 000)
            //Past that point, this approach can be used:
            //    https://math.stackexchange.com/questions/2844818/coin-tossing-problem-where-three-tails-come-in-a-row
            //
            //However, the data set as provided only had gaps of 1, 2, and 3 jolts, so the solutions for those gaps are fixed in the
            //  array runCombinations rather than a generalized solution.
            //To get the total combination, multiply the number of combinations of each run by each other!
            long totalCombinations = 1;
            int[] runCombinations = { 1, 2, 4, 7 };
            foreach (int c in oneJoltRunLengths)
            {
                totalCombinations *= runCombinations[c];
            }

            System.Console.WriteLine($"Total number of adapter combinations: {totalCombinations}");
        }



        private static void LoadAdaptersFromList()
        {
            var intAdapters = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).Select(v => int.Parse(v)).ToArray();

            Array.Sort(intAdapters);
            joltages.Add(0);
            foreach (var thisAdapter in intAdapters)
            {
                joltages.Add(thisAdapter);
            }

            joltages.Sort();
            // add the builtin adapter
            joltages.Add(intAdapters[intAdapters.Length - 1] + 3);

        }
    }
}
