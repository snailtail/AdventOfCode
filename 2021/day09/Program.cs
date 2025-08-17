namespace AdventOfCode
{
    public static class Day09
    {
        private static List<HeightPoint> Map = new();
        private static int rows=0;
        private static int cols=0;
        public static void Main(string[] args)
        {
            Init();
            Step1();
            Step2();

        }

        private static void Init()
        {
            var lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToList();
            int lineCounter = 0;
            rows = lines.Count();
            cols = lines[0].Length;
            foreach (string line in lines)
            {
                int rowCounter = 0;
                foreach (char c in line)
                {
                    int val = int.Parse($"{c}");
                    Map.Add(new HeightPoint(lineCounter, rowCounter, val));
                    rowCounter++;
                }
                lineCounter++;
            }
        }

        private static void Step1()
        {
            int riskLevelSum = 0;
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    var entity = Map.Where(hp => hp.X == x && hp.Y == y).FirstOrDefault();
                    var neighbors = getAdjacentPoints(entity);
                    var numHigher = neighbors.Where(hp => hp.Intensity > entity.Intensity).Count();
                    if (numHigher == neighbors.Count)
                    {
                        riskLevelSum += (1 + entity.Intensity);
                    }
                }
            }
            Console.WriteLine($"Step 1: {riskLevelSum}");
        }

        private static void Step2()
        {
            // Step 2
            // For each coordinate, keep finding the lowest neighbour until there are no more and then give this final coordinate a +1 value.
            // This should result in some coordinates gathering as the lowest points, and with a sum of from how many other coordinates there is a "slope".
            int[,] basinMap = new int[rows, cols];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    int atX = x;
                    int atY = y;
                    int atIntensity = getIntensity(atX, atY);
                    if (atIntensity != 9)
                    {
                        var lowerNeighbor = lowestNeighbor(x, y);

                        // Keep finding the lowest neighbor as long as there is one.
                        while (getIntensity(lowerNeighbor.X, lowerNeighbor.Y) < atIntensity)
                        {
                            atX = lowerNeighbor.X;
                            atY = lowerNeighbor.Y;
                            atIntensity = getIntensity(atX, atY);
                            lowerNeighbor = lowestNeighbor(atX, atY);
                        }
                        // We hit the lowest possible neighbor. 
                        // increase it's value, to indicate that we got here from the starting point x,y
                        basinMap[atX, atY]++;
                    }
                }
            }
            int[] topThreeBasins = basinMap.Cast<int>().OrderByDescending(v => v).Take(3).ToArray();
            Console.WriteLine($"Step 2: {topThreeBasins[0] * topThreeBasins[1] * topThreeBasins[2]}");
        }

        private static int getIntensity(int x, int y)
        {
            return Map.Where(hp => hp.X == x && hp.Y == y).Select(hpint => hpint.Intensity).FirstOrDefault();
        }

        private static HeightPoint lowestNeighbor(int x, int y)
        {
            var neighbors = getAdjacentPoints(new HeightPoint(x, y, 0));
            var lowest = neighbors[0];
            for (int n = 0; n < neighbors.Count; n++)
            {
                if (neighbors[n].Intensity < lowest.Intensity)
                {
                    lowest = neighbors[n];
                }
            }
            return lowest;
        }

        private static List<HeightPoint> getAdjacentPoints(HeightPoint Point)
        {
            // up: x-1,y
            // left:  x,y-1
            // right: x,y+1
            // down: x+1,y
            var result = Map.Where(hp => (hp.X == Point.X - 1 && hp.Y == Point.Y) || (hp.X == Point.X && hp.Y == Point.Y - 1) || (hp.X == Point.X && hp.Y == Point.Y + 1) || (hp.X == Point.X + 1 && hp.Y == Point.Y)).ToList();
            return result;
        }
    }
    public class HeightPoint
    {
        public int X;
        public int Y;
        public int Intensity;
        public HeightPoint(int iX, int iY, int iIntensity)
        {
            X = iX;
            Y = iY;
            Intensity = iIntensity;
        }
    }
}