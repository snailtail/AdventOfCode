using System;
using System.IO;

namespace AoC2017_04
{
    class Program
    {
        static void Main(string[] args)
        {
            AoC201704 myProcessor = new AoC201704();
            string[] passPhrases = File.ReadAllLines("input.txt");

            int Step1 = myProcessor.countValidPassPhrases(passPhrases,false);
            Console.WriteLine($"Step 1: {Step1}");
            int Step2 = myProcessor.countValidPassPhrases(passPhrases,true);
            Console.WriteLine($"Step 2: {Step2}");
        }
    }
}
