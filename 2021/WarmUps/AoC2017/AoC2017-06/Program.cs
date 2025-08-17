using System;
using System.IO;

namespace AoC2017_06
{
    class Program
    {
        static void Main(string[] args)
        {
            AoC201706 myProcessor = new AoC201706();
            string memoryBanks = File.ReadAllText("input.txt");
            int step1 = myProcessor.balanceBlocks(memoryBanks);
            Console.WriteLine($"Step 1: {step1}");
            int step2 = myProcessor.balanceBlocks(memoryBanks, true);
            Console.WriteLine($"Step 2: {step2}");
        }
    }
}
