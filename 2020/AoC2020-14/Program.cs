using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day14
{
    
    class Program
    {
        private const string inputPath="input.txt";
        //private const string inputPath="smallinput.txt";
        static void Main(string[] args)
        {
            var arrInput1 = File.ReadAllLines(inputPath);
            var arrInput2 = File.ReadAllLines(inputPath);
            var FirstStep = new Step1();
            Console.WriteLine($"Day 14 Step 1: {FirstStep.Compute(arrInput1)}");
            var SecondStep = new Step2();
            Console.WriteLine($"Day 14 Step 2: {SecondStep.Compute(arrInput2)}");
        }
    }
}
