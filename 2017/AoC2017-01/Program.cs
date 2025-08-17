using System;
using System.IO;

namespace AoC2017
{
    public static class AoC201701
    {
        public static int Step1(string input)
        {
            int length = input.Length;
            int comparer = 0;
            int sum = 0;
            for (int n = 0; n < length;n++)
            {
                if(n+1==length)
                {
                    comparer = 0;
                }
                else
                {
                    comparer = n + 1;
                }

                if(input.Substring(n,1)==input.Substring(comparer,1))
                {
                    sum +=int.Parse(input.Substring(n,1));
                }
            }
            return sum;
        }

        public static int Step2(string input)
        {
            int length = input.Length;
            int comparer = 0;
            int step = length / 2;
            int sum = 0;
            for (int n = 0; n < length;n++)
            {
                if(n+step>=length)
                {
                    comparer = n+step-length;
                }
                else
                {
                    comparer = n + step;
                }
                if(input.Substring(n,1)==input.Substring(comparer,1))
                {
                    sum +=int.Parse(input.Substring(n,1));
                }
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = File.ReadAllText("input.txt");
            int result1 = AoC201701.Step1(input1);
            Console.WriteLine($"Step 1 Result: {result1}");
            int result2 = AoC201701.Step2(input1);
            Console.WriteLine($"Step 2 Result: {result2}");
        }
    }
}
