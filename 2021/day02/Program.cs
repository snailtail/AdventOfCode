using System.Linq;
using System.IO;

namespace AdventOfCode.Y2021
{
    public static class Day02
    {
        private static int horizontal = 0;
        private static int depth_step1 = 0;
        private static int depth_step2 = 0;
        private static int aim = 0;
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt")
            .Where(l => !string.IsNullOrEmpty(l))
            .ToArray();

            foreach (string command in lines)
            {
                string[] cmd = command.ToLower().Split();
                move(cmd[0], int.Parse(cmd[1]));
            }
            System.Console.WriteLine($"Step 1: {horizontal * depth_step1}");
            System.Console.WriteLine($"Step 2: {horizontal * depth_step2}");
        }

        public static void move(string direction, int amount)
        {
            switch (direction)
            {
                case "forward":
                    horizontal += amount;
                    depth_step2 += aim * amount;
                    break;
                case "down":
                    depth_step1 += amount;
                    aim += amount;
                    break;
                case "up":
                    depth_step1 -= amount;
                    aim -= amount;
                    break;
                default:
                    break;
            }
        }
    }
}
