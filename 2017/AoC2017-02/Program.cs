using System;
using System.IO;
using System.Linq;

namespace AoC2017_02
{
    public static class AoC201702
    {
        public static Tuple<int, int> Process(string[] spreadSheet)
        {
            int checksum1 = 0;
            int checksum2 = 0;
            
            foreach (string line in spreadSheet.Where(l => (!string.IsNullOrWhiteSpace(l) && !string.IsNullOrEmpty(l))).ToArray())
            {
                int lineMinVal = int.MaxValue;
                int lineMaxVal = int.MinValue;
                int[] intArray = Array.ConvertAll(line.Split(), s => int.Parse(s));
                int numberCount = intArray.Length;
                
                #region step1 / outer loop
                for (int n = 0; n < numberCount; n++)
                {
                    lineMaxVal = intArray[n] > lineMaxVal ? intArray[n] : lineMaxVal;
                    lineMinVal = intArray[n] < lineMinVal ? intArray[n] : lineMinVal;
                    
                    #region step2 / inner loop
                    if (n < numberCount - 1)
                    {
                        for (int k = n + 1; k < numberCount; k++)
                        {
                            double divresult = 0.0;
                            int modresult = 0;
                            if (intArray[n] > intArray[k])
                            {
                                divresult = (double)intArray[n] / (double)intArray[k];
                                modresult = intArray[n] % intArray[k];
                            }
                            else
                            {
                                divresult = (double)intArray[k] / (double)intArray[n];
                                modresult = intArray[k] % intArray[n];
                            }
                            if (modresult == 0)
                            {
                                checksum2 += (int)divresult;
                            }
                        }
                    }
                    #endregion
                }
                #endregion
                checksum1 += (lineMaxVal - lineMinVal);
            }
            return Tuple.Create(checksum1, checksum2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] spreadSheet = File.ReadAllLines("input.txt").Where(l => string.IsNullOrEmpty(l) == false).ToArray<string>();
            var result = AoC201702.Process(spreadSheet);
            Console.WriteLine(result.Item1);
            Console.WriteLine(result.Item2);
        }
    }
}

