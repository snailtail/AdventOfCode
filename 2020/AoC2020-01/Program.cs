using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Helpers;
namespace AdventOfCode.TwentyTwenty.Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log($"Day 1 Step 1 result: {Step1()}");
            Logger.Log($"Day 1 Step 2 result: {Step2()}");
            Console.WriteLine();
        }
        private static int Step1()
        {
            //List<int> inputData = new List<int>();
            List<int> inputData = File.ReadAllLines("input.txt").Select(v => int.Parse(v)).ToList();
            
            var retVal = 0;
            for (int n = 0; n < inputData.Count - 1; n++)
            {
                for (int m = n + 1; m < inputData.Count - 1; m++)
                {
                    if ((inputData[n] + inputData[m]) == 2020)
                    {
                        retVal = inputData[n] * inputData[m];
                        break;
                    }
                }
            }
            return retVal;
        }

        private static int Step2()
        {
            List<int> inputData = File.ReadAllLines("input.txt").Select(v => int.Parse(v)).ToList();
            
            var retVal = 0;
            var bFound = false;
            for (int n = 0; n < inputData.Count - 1; n++)
            {
                for (int m = n + 1; m < inputData.Count - 1; m++)
                {
                    for (int x = n + 1; x < inputData.Count - 1; x++)
                    {
                        if ((inputData[n] + inputData[m] + inputData[x]) == 2020)
                        {
                            retVal = inputData[n] * inputData[m] * inputData[x];
                            bFound = true;
                            break;
                        }
                    }
                    if (bFound)
                        break;
                }
                if (bFound)
                    break;
            }
            return retVal;
        }
    }
}

    