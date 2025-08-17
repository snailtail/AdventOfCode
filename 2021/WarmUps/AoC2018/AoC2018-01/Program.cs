using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Helpers;

namespace AoC2018_01
{
    class Program
    {
        private static StringHelper sHelper = new StringHelper();
        static void Main(string[] args)
        {
            int Frequency = 0;
            Dictionary<int, int> foundFreqs = new Dictionary<int, int>();
            string[] frequencyJumps = File.ReadAllLines("input.txt");
            //step 1
            foreach (var fq in frequencyJumps)
            {
                Frequency += sHelper.parseNegativeString(fq);
            }

            Console.WriteLine($"Step1: {Frequency}");

            //step 2 -> Find the first frequency that is reached twice (repeat the list of frequencies if needed).
            Frequency=0;
            foundFreqs.Add(0,0); // first freq
            bool loop=true;
            while (loop)
            {
                foreach (var fq in frequencyJumps)
                {
                    try
                    {
                        Frequency += sHelper.parseNegativeString(fq);
                        foundFreqs.Add(Frequency,0);
                    }
                    catch (System.Exception)
                    {
                        // if we try to add the same key twice we'll get an error.
                        Console.WriteLine($"Step 2: {Frequency}");
                        loop=false;
                        break;
                    }
                }
            }
        }
    }
}
