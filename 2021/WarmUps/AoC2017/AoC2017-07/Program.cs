using System;
using System.IO;

namespace AoC2017_07
{
    class Program
    {
        static void Main(string[] args)
        {
            string programString = File.ReadAllText("input.txt");
            string step1 = AoC201707.Step1(programString);
            Console.WriteLine($"Step 1: {step1}");
            string step2 = AoC201707.Step2(programString);
            Console.WriteLine($"Step 2: {step2}");


        }
    }
}
