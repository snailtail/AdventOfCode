using System;
namespace AdventOfCode.Helpers
{
    public class BinaryHelper
    {

        /// <summary>
        /// Takes in a character array representing a binary number.
        /// Returns a long representing the number.
        /// </summary>
        public long ConvertBinaryStringToLong(char[] binaryCharArray)
        {
            long returnValue = 0;
            int theLength = binaryCharArray.Length -1;
            for (long n = 0; n <=theLength ; n++)
            {
                var thisBit = int.Parse(binaryCharArray[n].ToString());
                if (thisBit == 1)
                {
                    var bitValue = (long)Math.Pow((2), (theLength - n));
                    returnValue += bitValue;
                }
            }
            return returnValue;
        }

        public long ConvertBinaryStringToLong(string binaryString)
        {
            char[] binaryCharArray = binaryString.ToCharArray();
            long returnValue = ConvertBinaryStringToLong(binaryCharArray);
            return returnValue;
        }

        /// <summary>
        /// Takes a long and converts it to a string representing the number in binary form.
        /// </summary>
        public string ConvertLongToBinaryString(long number, int length)
        {
            const int mask = 1;
            var binary = string.Empty;
            while (number > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (number & mask) + binary;
                number = number >> 1;
            }
            while (binary.Length < length)
            {
                binary = "0" + binary;
            }
            return binary;
        }
    }
}