namespace AdventOfCode
{
    public static class Day07
    {
        public static void Main(string[] args)
        {
            int[] crabPositions = File.ReadAllText("input.txt").Split(",").Select(p => int.Parse(p)).ToArray();
            crabGroup myCrabs = new crabGroup(crabPositions);
            //Console.WriteLine(myCrabs);
            (int position1, long fuelcost1) = myCrabs.getBestPosition(false);
            (int position2, long fuelcost2) = myCrabs.getBestPosition((true));
            Console.WriteLine($"Best position: {position1}, fuelcost: {fuelcost1}");
            Console.WriteLine($"Best position: {position2}, fuelcost: {fuelcost2}");
        }
    }

    public class crabGroup
    {
        public int[] Crabs { get; set; }

        public crabGroup(int[] crabPositions)
        {
            Crabs = crabPositions;
        }
        private int fuelConsumption(int distance, bool step2FuelConsumption)
        {
            int fuelConsumption = 0;
            for (int y = 1; y <= distance; y++)
            {
                fuelConsumption += y;
            }
            if (step2FuelConsumption)
            {
                return fuelConsumption;
            }
            else
            {
                return distance;
            }
        }
        public (int, long) getBestPosition(bool step2FuelConsumption)
        {
            int thisPosition = 0;
            long fuelCost = long.MaxValue;
            int bestPosition = 0;
            int maxPosition = Crabs.Max();
            int minPosition = Crabs.Min();

            for (int x = minPosition; x <= maxPosition; x++)
            {
                long loopFuelCost = 0;
                thisPosition = x;
                foreach (var crab in Crabs)
                {
                    loopFuelCost += fuelConsumption(Math.Abs(x - crab), step2FuelConsumption);
                }
                if (loopFuelCost < fuelCost)
                {
                    bestPosition = thisPosition;
                    fuelCost = loopFuelCost;
                }
            }
            return (bestPosition, fuelCost);
        }

        public override string ToString()
        {
            string crabData = string.Empty;
            foreach (var crab in Crabs)
            {
                crabData += $"{crab}, ";
            }
            return crabData;
        }
    }
}