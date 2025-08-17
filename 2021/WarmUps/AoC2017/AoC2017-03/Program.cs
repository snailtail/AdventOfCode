using System;
using System.Collections.Generic;

namespace AoC2017_03
{
    class Program
    {
        static void Main(string[] args)
        {
            AoC201703 processor = new AoC201703();
            var distance = processor.Process(368078);
            Console.WriteLine($"Step 1: {distance}");
            var neighborsum = processor.neighborSum;
            Console.WriteLine($"Step 2: {neighborsum}");
        }
    }
}
