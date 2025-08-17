using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2015_11
{
    public class Solver
    {

        public Solver() 
        { 

        }

        public string Solve(string password, bool step1 = true)
        {
            if (step1 == true)
            {
                bool valid = CheckIfValidPassword(password);
                while(!valid)
                {
                    password = IncrementPassword(password);
                    valid = CheckIfValidPassword(password);
                }
                return password;
            }
            else
            {
                return "";
            }
        }

        public string IncrementPassword(string password, bool rollOver=false, int pos=-1)
        {
            char[] chars = password.ToCharArray();
            bool skip = false;
            for (int i = 0; i < chars.Length; i++)
            {
                if (skip)
                {
                    chars[i] = 'a';
                }
                else
                {
                    if (chars[i] == 'i' || chars[i] == 'o' || chars[i] == 'l')
                    {
                        skip = true;
                        chars[i]++;
                        continue;
                    }
                }
            }
            for (int i = rollOver==false ? chars.Length-1 : pos; i >=0; i--)
            {
                if (chars[i] == 122)
                {
                    chars[i] = (char)97;
                    return IncrementPassword(new string(chars), true, i - 1);
                }
                else
                {
                    chars[i]++;
                    return new string(chars);

                }
            }
            
            
            return new string(chars);
        }

        public bool CheckIfValidPassword(string password)
        {
            if (password.Length != 8) return false;
            if (!HasIncreasingThree(password)) return false;
            if (password.Contains('i') || password.Contains('o') || password.Contains('l')) return false;
            if (!HasNonOverlappingPairs(password)) return false;
            return true;
        }


        public bool HasNonOverlappingPairs(string password)
        {
            var charCounts = FindConsecutiveCharCounts(password);
            HashSet<char> nonOverlappingPairs = charCounts.Where(c => c.Count==2).Select(c=> c.Character).ToHashSet();
            if(nonOverlappingPairs.Count>=2)
            {
                return true;
            }
            else 
            { 
                return false; 
            }

        }

        private List<CharCount> FindConsecutiveCharCounts(string input)
        {
            List<CharCount> charCounts = new List<CharCount>();
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    charCounts.Add(new CharCount { Character = input[i - 1], Count = count });
                    count = 1;
                }
            }

            // Add the last character and its count
            if (input.Length > 0)
            {
                charCounts.Add(new CharCount { Character = input[input.Length - 1], Count = count });
            }

            return charCounts;
        }


        public char[]? findCharNeighbors(char c)
        {
            string validChars = "abcdefghjkmnpqrstuvwxyz";
            int position = validChars.IndexOf(c);
            if(position == -1)
            {
                return null;
            }
            if(position == validChars.Length-1)
            {
                return null;
            }
            else if (position == 0)
            {
                return null;
            }
            else
            {
                return new char[] { validChars[position - 1], validChars[position], validChars[position + 1] };
            }

        }
        public bool HasIncreasingThree(string password)
        {
            

            for(int n = 1; n < password.Length-1; n++)
            {
                char c = password[n];

                char[]? neighbors = findCharNeighbors(c);
                if (neighbors==null)
                {
                    continue;
                }
                else
                {
                    if (password[n - 1] == neighbors[0] && password[n] == neighbors[1] && password[n + 1] == neighbors[2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    internal class CharCount
    {
        public char Character { get; set; }
        public int Count { get; set; }
    }
}
