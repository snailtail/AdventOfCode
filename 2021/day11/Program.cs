namespace AdventOfCode
{
    public static class Day11
    {
        private static List<dumboOctopus> dumboOctopi;
        private static string[] lines;
        private static int flashesStep1 = 0;
        public static void Main(string[] args)
        {
            Init();
            Part1();
            Init();
            Part2();
        }

        private static void Part1()
        {

            for (int n = 0; n < 100; n++)
            {

                doStep();

            }
            Console.WriteLine($"Step 1: {flashesStep1}");
        }

        private static void Part2()
        {
            long stepCounter = 0;
            var count = dumboOctopi.Where(d => d.EnergyLevel == 0).Count();
            while (count != 100)
            {
                doStep();
                stepCounter++;
                count = dumboOctopi.Where(d => d.EnergyLevel == 0).Count();
            }
            Console.WriteLine($"Step 2: {stepCounter}");
        }

        private static void doStep()
        {
            // first increase energy levels for all octopi
            foreach (dumboOctopus o in dumboOctopi)
            {
                o.EnergyLevel++;
            }

            Flash();

            foreach (var o in dumboOctopi)
            {
                if (o.Flashed)
                {
                    o.EnergyLevel = 0;
                    o.Flashed = false;
                }
            }
        }

        private static void Flash()
        {
            IEnumerable<dumboOctopus> flashingOctopi = dumboOctopi.Where(d => d.EnergyLevel > 9 && d.Flashed == false);
            while (flashingOctopi.Count() > 0)
            {
                foreach (dumboOctopus o in flashingOctopi)
                {
                    increaseNeighbors(o);
                    o.Flashed = true;
                    flashesStep1++;
                }
                flashingOctopi = dumboOctopi.Where(d => d.EnergyLevel > 9 && d.Flashed == false);
            }
        }

        private static void increaseNeighbors(dumboOctopus o)
        {
            IEnumerable<dumboOctopus> neighbors = dumboOctopi.Where(
                n =>
                (n.X == o.X - 1 && n.Y == o.Y - 1) // northwest
                ||
                (n.X == o.X - 1 && n.Y == o.Y) // nort
                ||
                (n.X == o.X - 1 && n.Y == o.Y + 1) // norteast
                ||
                (n.X == o.X && n.Y == o.Y - 1) // west
                ||
                (n.X == o.X && n.Y == o.Y + 1) // east
                ||
                (n.X == o.X + 1 && n.Y == o.Y - 1) // southwest
                ||
                (n.X == o.X + 1 && n.Y == o.Y) // south
                ||
                (n.X == o.X + 1 && n.Y == o.Y + 1) // southeast
            ).ToList();

            foreach (dumboOctopus oc in neighbors)
            {
                oc.EnergyLevel++;
            }
        }

        private static void Init()
        {
            dumboOctopi = new();
            lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    int energyLevel = int.Parse($"{lines[x][y]}");
                    dumboOctopi.Add(new dumboOctopus(x, y, energyLevel, false));
                }
            }
        }

        private static void printOctopi()
        {
            Console.WriteLine("***** Octopi states *****");
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var octopus = dumboOctopi.Where(d => d.X == x && d.Y == y).FirstOrDefault();
                    Console.Write(octopus.EnergyLevel);
                }
                Console.WriteLine();
            }
            Console.WriteLine("********** End **********");

        }
    }

    public class dumboOctopus
    {
        public int EnergyLevel { get; set; }
        public bool Flashed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public dumboOctopus(int iX, int iY, int iEnergyLevel, bool bFlashed)
        {
            X = iX;
            Y = iY;
            EnergyLevel = iEnergyLevel;
            Flashed = bFlashed;
        }
    }


}