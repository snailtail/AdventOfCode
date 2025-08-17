using System.Linq;

namespace AdventOfCode.Y2021
{
    public class Measurementizer
    {
        private int[] measurements;
        public Measurementizer(string[] measurementStrings)
        {
            measurements = measurementStrings.Select(l => int.Parse(l)).ToArray();
        }

        public int SinglesIncreases
        {
            get
            {
                int counter = 0;
                for (int n = 0; n < measurements.Length; n++)
                {
                    if (n + 1 < measurements.Length && measurements[n + 1] > measurements[n])
                    {
                            counter++;
                    }
                }
                return counter;
            }
        }

        public int GroupIncreases
        {
            get
            {
                int counter = 0;
                int lastsum = 0;
                for (int n = 0; n < measurements.Length - 2; n++)
                {
                    int sum=(measurements[n] + measurements[n + 1] + measurements[n + 2]);
                    if (n > 0 && sum > lastsum)
                    {
                            counter++;
                    }
                    lastsum = sum;
                }
                return counter;
            }
        }

    }
}

