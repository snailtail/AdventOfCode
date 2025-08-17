using System;
using System.IO;

namespace AoC2017_16
{
    class Program
    {
        static string[] instructions;
        static void Main(string[] args)
        {
            instructions = File.ReadAllText("input.txt").Split(',');
            PermutationPromenade.programs = "abcdefghijklmnop";
            ExecuteAllInstructions();
            Console.WriteLine($"Step 1: {PermutationPromenade.programs}");

            // Step 2 - Many repetitions, we can't brute our way through this - it would take several months.
            // After checking for patterns I noticed that every 60 executions the string was back to the starting position again.
            // So cut the looping of one billion iterations shorter by just checking the remainder from 1 billon and 60.
            long wantedExecutions = 1000000000; // One Billion repetitions wanted.
            long repeatInterval=60; // at 60 repetitions of the executions we will have made a complete lap around all the permutations and are back at the same string again
            long neededLoops = wantedExecutions % repeatInterval-1; // subtract one since the description of the task for step 2 says that the output from step 1 is the first execution. this took me way too long to realise...
            for (long n = 0; n < neededLoops; n++)
            {
                ExecuteAllInstructions();
            }
            Console.WriteLine($"Step 2: {PermutationPromenade.programs}");
        }
        private static void ExecuteAllInstructions()
        {
            foreach (var instr in instructions)
            {
                PermutationPromenade.ExecuteInstruction(instr);
            }
        }
    }
}
