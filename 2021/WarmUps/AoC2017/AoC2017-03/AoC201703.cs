using System;
using System.Collections.Generic;
namespace AoC2017_03
{

    public class AoC201703
    {
        private int cols = 1;
        private int rows = 1;
        private Dictionary<string, int> spiralGrid;
        private Dictionary<string, int> neighborSumGrid;
        public int neighborSum = 0;

        public int Process(int squareID)
        {
            int currentX = 0;
            int currentY = 0;
            spiralGrid = new Dictionary<string, int>();
            neighborSumGrid = new Dictionary<string, int>();
            string newCoord;
            bool positiveDirection = true;
            // init the first square (center piece at 0,0)
            newCoord = $"{currentX}:{currentY}";
            spiralGrid.Add(newCoord, 1);
            neighborSumGrid.Add(newCoord, 1);
            bool step2Found = false;
            for (int n = 2; n <= squareID; n++)
            {
                if (positiveDirection == true)
                {
                    if (currentX < cols && currentY < rows)
                    {
                        currentX++;
                    }
                    else if (currentY < rows)
                    {
                        currentY++;
                    }
                    else
                    {
                        positiveDirection = false;
                        currentX--;
                    }
                }
                else // negative direction (left until corner is hit ( currentX = -cols and then go down)
                {
                    if (currentX > (cols * -1) && currentY > (rows * -1))
                    {
                        currentX--;
                    }
                    else if (currentY > (rows * -1))
                    {
                        currentY--;
                    }
                    else
                    {
                        cols++;
                        rows++;
                        positiveDirection = true;
                        currentX++;
                    }
                }

                newCoord = $"{currentX}:{currentY}";
                spiralGrid.Add(newCoord, n);
                //step 2 should check for all populated neighbors (n, s, e, w, ne, nw, se, sw)
                int thisNeighborsum=getNeighborSum(newCoord);
                neighborSumGrid.Add(newCoord, thisNeighborsum);
                //Console.WriteLine($"n:{n}, Coord: {newCoord}, Distance: {ManhattanDistance(newCoord)}, neighborSum: {thisNeighborsum}");
                if (step2Found==false)
                {
                    if(thisNeighborsum  >   squareID)
                    {
                        step2Found = true;
                        neighborSum = thisNeighborsum;
                    }
                }
            }

            return ManhattanDistance(newCoord);
        }

        private int getNeighborSum(string newCoord)
        {
            int sum = 0;
            var coordData = newCoord.Split(":");
            int x = int.Parse(coordData[0]);
            int y = int.Parse(coordData[1]);

            string[] testKeys = { $"{x + 1}:{y}", $"{x + 1}:{y + 1}", $"{x + 1}:{y - 1}", $"{x}:{y + 1}", $"{x}:{y-1}", $"{x - 1}:{y}", $"{x - 1}:{y + 1}", $"{x - 1}:{y-1}"};
            foreach(string testKey in testKeys)
            {
                sum += getGridValue(testKey);
            }            
            
            return sum;

        }

        private int getGridValue(string coord)
        {
            int returnValue;

            if (neighborSumGrid.ContainsKey(coord))
            {
                int gridValue;
                bool success = neighborSumGrid.TryGetValue(coord, out gridValue);
                if(success)
                {
                    //Console.WriteLine($"Found value {gridValue} at coord: {coord}");
                    returnValue = gridValue;
                }
                else
                {
                    returnValue = 0;
                }
            }
            else
            {
                returnValue = 0;
            }
            return returnValue;
        }
        private int ManhattanDistance(string coord)
        {
            var coordData = coord.Split(":");
            int x = int.Parse(coordData[0]);
            int y = int.Parse(coordData[1]);
            int retX = x >= 0 ? x : (x * -1);
            int retY = y >= 0 ? y : (y * -1);
            return retX + retY;
        }
    }
}