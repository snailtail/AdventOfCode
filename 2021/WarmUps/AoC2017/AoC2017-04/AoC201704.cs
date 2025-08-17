using System;
using System.Collections.Generic;

namespace AoC2017_04
{
    public class AoC201704
    {
        public int countValidPassPhrases(string[] passPhrases, bool Step2=false)
        {
            int counter = 0;
            foreach(string phrase in passPhrases)
            {
                if(isPassPhraseValid(phrase, Step2))
                {
                    counter++;
                }
            }
            return counter;
        }
        public bool isPassPhraseValid(string passPhrase, bool Step2 = false)
        {
            bool isvalid = false;
            Dictionary<string, int> wordCheck = new Dictionary<string, int>();
            string[] words = passPhrase.Split();
            foreach (string word in words)
            {
                try
                {
                    if(Step2==false)
                    {
                        wordCheck.Add(word, 0);                        
                    }
                    else
                    {
                        wordCheck.Add(sortedString(word), 0);
                    }
                    isvalid=true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
            return isvalid;
        }

        public string sortedString(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Sort<char>(charArray);
            return new string(charArray);
        }
    }
}