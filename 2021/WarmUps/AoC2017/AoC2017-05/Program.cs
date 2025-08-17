using System;
using System.IO;

namespace AoC2017_05
{
    class Program
    {
        static void Main(string[] args)
        {
            AoC201705 myProcessor = new AoC201705();
            string[] jumps = File.ReadAllLines("input.txt");
            int step1 = myProcessor.ProcessList(jumps, false);
            Console.WriteLine($"Step 1: {step1}");
            int step2 = myProcessor.ProcessList(jumps, true);
            Console.WriteLine($"Step 2: {step2}");
        }
    }
}
