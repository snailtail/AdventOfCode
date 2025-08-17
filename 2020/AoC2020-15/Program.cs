using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day15
{
    class Program
    {
        private const string thePath = "input.txt";
        //private const string thePath = "smallinput.txt";

        static void Main(string[] args)
        {
            var inputData1=File.ReadAllText(thePath).Split(',').ToArray();
            var inputData2=File.ReadAllText(thePath).Split(',').ToArray();
            var firstStep = new Step2();
            
            System.Console.WriteLine($"Day 15 Step 1: {firstStep.Compute(inputData1, 2020)}");

            var secondStep=new Step2();

            System.Console.WriteLine($"Day 15 Step 2: {secondStep.Compute(inputData2, 30000000)}");

            
        }
    }
}
