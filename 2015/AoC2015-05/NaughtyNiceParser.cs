using System.Text.RegularExpressions;
using System;
using System.IO;
namespace AdventOfCode.TwentyFifteen.Day05
{
    public class NaughtyNiceParser
    {
        // regex heaven..!
        // vokalerna: /[aeiou]/g
        // dubbla bokstäver i nån form: /([a-z])\1/

        //Naughty: /ab|cd|pq|xy/
        public int MinVowels = 3;
        #region Step1
        public int CountNiceStringsInFile(string Path)
        {
            var fileData = File.ReadAllLines(Path);
            int counter=0;
            foreach(string line in fileData)
            {
                if(IsNice(line)){
                    counter++;
                }
            }
            return counter;
        }
        public bool IsNice(string TestData)
        {
            if (CheckForVowels(TestData, MinVowels) == true && CheckForDoubleLetters(TestData)==true && ContainsIllegalStrings(TestData)==false)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        

        public bool CheckForVowels(string inputString, int minMatches)
        {
            string vowelpattern = @"[aeiou]";
            Regex vowels = new Regex(vowelpattern);
            MatchCollection vowelMatches = vowels.Matches(inputString);
            if (vowelMatches.Count >= minMatches)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForDoubleLetters(string inputString)
        {
            string doublePattern = @"([a-z])\1";
            Regex doubles = new Regex(doublePattern);
            MatchCollection doubleMatches = doubles.Matches(inputString);
            if(doubleMatches.Count>0){
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsIllegalStrings(string inputString)
        {
            string illegalPattern = @"ab|cd|pq|xy";
            Regex illegals = new Regex(illegalPattern);
            MatchCollection illegalMatches = illegals.Matches(inputString);
            if(illegalMatches.Count>0){
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Step2
        public bool IsNice2(string TestData)
        {
            if(TestPair2(TestData)==true && TestXyX(TestData)==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TestPair2(string TestData)
        {
            //([a-z][a-z])[a-z]*\1
            string pairPattern = @"([a-z][a-z])[a-z]*\1";
            Regex pairs = new Regex(pairPattern);
            MatchCollection pairMatches = pairs.Matches(TestData);
            if(pairMatches.Count>0){
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool TestXyX(string TestData)
        {
            //([a-z])[a-z]\1
            string xyxPattern = @"([a-z])[a-z]\1";
            Regex xyxs = new Regex(xyxPattern);
            MatchCollection xyxMatches = xyxs.Matches(TestData);
            if(xyxMatches.Count>0){
                return true;
            }
            else
            {
                return false;
            }

        }
        public int CountNiceStringsInFile2(string Path)
        {
            var fileData = File.ReadAllLines(Path);
            int counter=0;
            foreach(string line in fileData)
            {
                if(IsNice2(line)){
                    counter++;
                }
            }
            return counter;
        }

        #endregion

    }
}