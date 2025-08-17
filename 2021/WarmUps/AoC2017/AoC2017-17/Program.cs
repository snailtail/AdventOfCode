using System;
using System.Collections.Generic;

namespace AoC2017_17
{
    public class Spinlock
    {
        public List<int> circularBuffer = new List<int>() { 0 };
        public int currentPosition = 0;

        public int Steps { get; set; }
        public int nextValue => GetNextValue();

        public void MoveForward(int InsertValue)
        {
            for (int n = 1; n <= Steps; n++)
            {
                if (currentPosition + 1 >= circularBuffer.Count)
                {
                    currentPosition = 0;
                }
                else
                {
                    currentPosition++;
                }
                //Console.WriteLine($"Moved to current pos: {currentPosition}");
            }
            // time to insert
            if (currentPosition + 1 <= circularBuffer.Count)
            {
                circularBuffer.Insert(currentPosition + 1, InsertValue);
                currentPosition++;

            }
            else
            {
                circularBuffer.Insert(0, InsertValue);
                currentPosition = 0;
            }
        }

        public void PrintBuffer()
        {
            string output = string.Empty;
            for (int n = 0; n < circularBuffer.Count; n++)
            {
                if (n == currentPosition)
                {
                    output += $"({circularBuffer[n]}) ";
                }
                else
                {
                    output += $"{circularBuffer[n]} ";
                }
            }
            Console.WriteLine(output);
        }

        private int GetNextValue()
        {
            if (currentPosition + 1 == circularBuffer.Count)
            {
                return circularBuffer[0];
            }
            else
            {
                return circularBuffer[currentPosition + 1];
            }
        }
        public void Spin(int Spins)
        {
            for (int n = 1; n <= Spins; n++)
            {
                MoveForward(n);
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var lock1 = new Spinlock();
            lock1.Steps = 349;
            lock1.Spin(2017);
            Console.WriteLine($"Step 1: {lock1.nextValue}");

            //Step 2 - We only need to keep track of the value next to 0
            int zeroPosition = 0;
            int zeroNeighbor = 0;
            int step2Position = 0;
            int step2Steps = 349;
            for (int i = 1; i < 50000000; i++)
            {
                step2Position = (step2Position + step2Steps) % i;
                if (step2Position == zeroPosition)
                    zeroNeighbor = i;
                if (step2Position < zeroPosition)
                    zeroPosition++;
                step2Position++;
            }
            Console.WriteLine($"Step 2: {zeroNeighbor}");            


        }
    }
}
