using AdventOfCode.Helpers;

namespace AdventOfCode.Y2021
{
    public class Day03
    {
        public static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrEmpty(l))
                .ToArray();

            Step1(lines);
            Step2(lines);

        }

        private static void Step1(string[] input)
        {

            string gammaRate = "";
            string epsilonRate = "";

            int numBits = input[0].Length;

            for (int x = 0; x < numBits; x++)
            {
                //outer loop for each position in the string

                (char mcbit, char lcbit) = getCommonBits(input, x);

                gammaRate += mcbit.ToString();
                epsilonRate += lcbit.ToString();
            }

            Console.WriteLine(gammaRate);
            Console.WriteLine(epsilonRate);
            var bh = new BinaryHelper();
            var gammaLong = bh.ConvertBinaryStringToLong(gammaRate);
            var epsilonLong = bh.ConvertBinaryStringToLong(epsilonRate);
            System.Console.WriteLine(gammaLong * epsilonLong);

        }


        private static (char, char) getCommonBits(string[] input, int position)
        {
            int arrSize = input.Count();
            int numHigh = 0;
            int numLow = 0;

            for (int y = 0; y < arrSize; y++)
            {
                if (input[y][position] == '1')
                {
                    numHigh++;

                }
                else
                {
                    numLow++;
                }
            }
            if (numHigh > numLow)
            {
                return ('1', '0');
            }
            else if (numHigh < numLow)
            {
                return ('0', '1');
            }
            else
            {
                return ('0', '0');
            }
        }
        private static void Step2(string[] input)
        {
            int bitCount = input[0].Length;
            int numberCount = input.Count();
            List<string> o2BitList = input.Where(i=> !string.IsNullOrEmpty(i)).ToList();
            List<string> co2BitList = input.Where(i=> !string.IsNullOrEmpty(i)).ToList();
            
            int n=0;
            while(n<bitCount && numberCount>1)
            {
                (var mCommonBit, var lCommonBit)  = getCommonBits(o2BitList.ToArray(),n);
                if(mCommonBit==lCommonBit)
                {
                    mCommonBit='1';
                }
                o2BitList = o2BitList.Where(bl=> bl.Substring(n,1)==mCommonBit.ToString()).ToList();
                numberCount=o2BitList.Count();
                n++;
            }

            n=0;
            numberCount = co2BitList.Count();
            while(n<bitCount && numberCount>1)
            {
                (var mCommonBit, var lCommonBit)  = getCommonBits(co2BitList.ToArray(),n);
                if(mCommonBit==lCommonBit)
                {
                    lCommonBit='0';
                }
                co2BitList = co2BitList.Where(cbl=> cbl.Substring(n,1)==lCommonBit.ToString()).ToList();
                numberCount=co2BitList.Count();
                n++;
            }
            Console.WriteLine("Step 2");

            var bh = new BinaryHelper();

            var lOxygen = bh.ConvertBinaryStringToLong(o2BitList[0]);
            var lCo2 = bh.ConvertBinaryStringToLong(co2BitList[0]);
            Console.WriteLine(lOxygen * lCo2);

        }

    }

}
