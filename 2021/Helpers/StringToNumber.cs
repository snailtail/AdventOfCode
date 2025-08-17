using System;
namespace AdventOfCode.Helpers
{
    /// <summary>
    /// A helper class for Triangles, implements such things as you would expect from Triangles.
    /// 3 sides, the possibility to check if the triangle is possible (from the length of the sides)
    /// And more.
    /// </summary>
    public static class StringToNumber
    {
        public static int parseNegativeString(string numberString)
        {
            int returnValue = 0;
            if(numberString[0]=='-')
            {
                returnValue = int.Parse(numberString.Substring(1));
                returnValue = returnValue * -1;
            }
            else
            {
                returnValue = int.Parse(numberString);
            }
            return returnValue;
        }

    }
}
