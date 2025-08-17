using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.TwentyTwenty.Day14
{
    public class Memoryaddress
    {
        public char[] Data { get; set; }

        public Memoryaddress()
        {
            char[] Data = new char[36];
        }

        public Memoryaddress(string DataString)
        {
            Data = DataString.ToCharArray();
        }

        public Memoryaddress(char[] charArray)
        {
            Data = charArray;
        }
    }
}
