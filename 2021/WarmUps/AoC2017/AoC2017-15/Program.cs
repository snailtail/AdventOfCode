using System;
using System.Collections.Generic;
using AdventOfCode.Helpers;

namespace AoC2017_15
{
    class Generator
    {
        private BinaryHelper binHelper;
        public long factor { get; private set; }
        public long divisor { get; private set; }
        public string lastResultBinary => binHelper.ConvertLongToBinaryString(lastResult, 32);
        public long lastResult { get; private set; }
        public int? modFactor;
        public Generator(long StartValue, long Factor, long Divisor, int? ModFactor)
        {
            binHelper = new BinaryHelper();
            lastResult = StartValue;
            factor = Factor;
            divisor = Divisor;
            modFactor = ModFactor;
        }
        public string Process()
        {
            long nextValue = (lastResult * factor) % divisor;
            if (modFactor != null)
            {
                if (nextValue % modFactor == 0)
                {
                    lastResult = nextValue;
                    return lastResultBinary;
                }
                else
                {
                    lastResult = nextValue;
                    return null;
                }
            }
            else
            {
                lastResult = nextValue;
                return lastResultBinary;
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryHelper myBinHelper = new BinaryHelper();
            //step 1
            int hitCount = 0;
            Generator genA = new Generator(699, 16807, 2147483647, null);
            Generator genB = new Generator(124, 48271, 2147483647, null);
            int step1Runs = 40_000_000;
            for (int n = 0; n < step1Runs; n++)
            {
                genA.Process();
                genB.Process();
                string binA = genA.lastResultBinary.Substring(genA.lastResultBinary.Length - 16, 16);
                string binB = genB.lastResultBinary.Substring(genB.lastResultBinary.Length - 16, 16);
                if (binA == binB)
                {
                    hitCount++;
                }
            }
            Console.WriteLine($"Step 1: {hitCount}");
            
            //Step 2
            int step2Runs = 5_000_000;
            hitCount = 0;
            List<string> resultsA = new List<string>();
            List<string> resultsB = new List<string>();
            genA = new Generator(699, 16807, 2147483647, 4);
            genB = new Generator(124, 48271, 2147483647, 8);
            do
            {
                string resultA = genA.Process();
                if (resultA != null)
                {
                    resultsA.Add(resultA);
                }
            } while (resultsA.Count < step2Runs);

            do
            {
                string resultB = genB.Process();
                if (resultB != null)
                {
                    resultsB.Add(resultB);
                }
            } while (resultsB.Count < step2Runs);

            for (int n = 0; n < step2Runs; n++)
            {
                string binA = resultsA[n].Substring(resultsA[n].Length - 16, 16);
                string binB = resultsB[n].Substring(resultsB[n].Length - 16, 16);
                if (binA == binB)
                {
                    hitCount++;
                }

            }
            Console.WriteLine($"Step 2: {hitCount}");

            //Generator A starts with 699
            //Generator B starts with 124
            //(generator A uses 16807; 

            //generator B uses 48271), and then keep the remainder of dividing that resulting product by 2147483647. That final remainder is the value it produces next.


        }
    }
}
