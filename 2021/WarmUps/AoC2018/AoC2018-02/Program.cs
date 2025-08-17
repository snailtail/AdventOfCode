using System;
using System.IO;
using System.Linq;

namespace AoC2018_02
{
    public class Inventoryizer
    {
        string ValidCharacters = "abcdefghijklmnopqrstuvwxyz";

        public bool CheckCharCount(int charCount, string theString)
        {
            char[] Characters = ValidCharacters.ToCharArray();

            foreach (var ch in Characters)
            {
                if (charCount == theString.Where(x => (x == ch)).Count())
                {
                    return true;
                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Inventoryizer myInv = new Inventoryizer();
            var IDs = File.ReadAllLines("input.txt");
            int numTwoOccurences = 0;
            int numThreeOccurences = 0;
            foreach (string id in IDs)
            {
                if (myInv.CheckCharCount(2, id))
                {
                    numTwoOccurences++;
                }
                if (myInv.CheckCharCount(3, id))
                {
                    numThreeOccurences++;
                }
            }
            int checkSum = numTwoOccurences * numThreeOccurences;
            Console.WriteLine($"Step 1: {checkSum}");

            //Step 2.
            bool Found = false;
            string step2 = string.Empty;
            for (int x = 0; x < IDs.Length - 1; x++)
            {
                for (int y = x + 1; y < IDs.Length; y++)
                {
                    int l1 = Levenshtein.LevenshteinDistance(IDs[x], IDs[y]);
                    if (l1 == 1)
                    {
                        step2 = GetMatchingCharacters(IDs[x], IDs[y]);
                        Found = true;
                    }
                    if (Found) break;
                }

                if (Found) break;
            }
            Console.WriteLine($"Step 2: {step2}");
        }

        private static string GetMatchingCharacters(string v1, string v2)
        {
            string matchingChars = string.Empty;
            for (int n = 0; n < v1.Length; n++)
            {
                if (v1[n] == v2[n]) matchingChars += v1[n];
            }
            return matchingChars;
        }
    }
}
