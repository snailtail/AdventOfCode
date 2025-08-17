using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.TwentyTwenty.Day14
{
    public class Mask
    {
        public char[] Data { get; set;}

        public Mask()
        {
            char[] Data = new char[36];
        }

        public Mask(string MaskString)
        {
            Data = MaskString.ToCharArray();
        }

        public long ConvertBinaryStringToLong(char[] memoryaddressdata)
        {
            long returnValue = 0;
            for(long n=0; n<=35; n++)
            {
                var thisBit = int.Parse(memoryaddressdata[n].ToString());
                if(thisBit==1)
                {
                    var bitValue=(long)Math.Pow((2),(35 - n));
                    returnValue += bitValue;
                }
            }
            return returnValue;
        }

        public string ConvertLongToBinaryString(long number, int length)
        {
            const int mask = 1;
            var binary = string.Empty;
            while(number > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (number & mask) + binary;
                number = number >> 1;
            }
            while(binary.Length<36)
            {
                binary = "0" + binary;
            }
            return binary;
        }
        public char[] ApplyMask(char[] memoryaddressdata, char[] maskdata)
        {
            // take data from a memory address (or any char[] provided) and apply the maskdata to it.
            for(int n = 0; n< maskdata.Length; n++)
            {
                if(maskdata[n]=='X'){
                    // do nothing
                }
                else
                {
                    memoryaddressdata[n]=maskdata[n];
                }
            }
            return memoryaddressdata;
        }

    }
}
