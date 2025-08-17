namespace AdventOfCode.Helpers
{
    public class ManhattanHelper
    {
        /// <summary>
        /// Takes a coordinate (x:y) and parses it, returns the manhattan distance to 0:0
        /// </summary>
        /// <param name="coord">A string formatted as x:y</param>
        /// <returns>Manhattan distance from coordinate to 0:0</returns>
        public int CalculateManhattanDistance(string coord)
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