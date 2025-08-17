using System;

namespace AdventOfCode.Helpers
{
    public class StringHelper
    {
        /// <summary>
        /// Takes a string, sorts the chars within the string as chars, returns them as a string.
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <returns>A string containing the characters from the input, sorted in order as characters.</returns>
        public string sortedString(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            Array.Sort<char>(charArray);
            return new string(charArray);
        }
        public int parseNegativeString(string numberString)
        {
            int returnValue = 0;
            if (numberString[0] == '-')
            {
                returnValue = int.Parse(numberString.Substring(1)); // numberString.Length-1));
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