using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 2 Step 1 result: {0}", Step1());
            Console.WriteLine("Day 2 Step 2 result: {0}", Step2());
        }

        private static int CountChar(char Character, string Data)
        {
            int count = Data.Split(Character).Length - 1;
            return count;
        }

        private static PasswordWithPolicy ParsePasswordPolicy(string policyString)
        {
            var thePolicy = new PasswordWithPolicy();
            thePolicy.MinCount = int.Parse(policyString.Split(' ')[0].Split('-')[0]);
            thePolicy.MaxCount = int.Parse(policyString.Split(' ')[0].Split('-')[1]);
            thePolicy.RequiredChar = policyString.Split(' ')[1].ToCharArray()[0];
            thePolicy.Password = policyString.Split(' ')[2];
            return thePolicy;
        }

        public static bool PasswordMeetsPolicy(PasswordWithPolicy PolicyObject)
        {
            bool result;

            // check how many occurences of the required character are in the password.
            // and if that is in the range of min-max
            var numRequiredChars = CountChar(PolicyObject.RequiredChar, PolicyObject.Password);
            if (numRequiredChars >= PolicyObject.MinCount && numRequiredChars <= PolicyObject.MaxCount)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        public static int Step1()
        {
            var arrStringData = File.ReadAllLines("input.txt");
            int numValidPasswords = 0;
            PasswordWithPolicy myPolicy;
            foreach (var line in arrStringData)
            {
                myPolicy = ParsePasswordPolicy(line);
                if (PasswordMeetsPolicy(myPolicy))
                {
                    numValidPasswords++;
                }

            }
            return numValidPasswords;

        }

        private static bool PasswordMeetsPolicy2(PasswordWithPolicy objPolicy)
        {


            /** 
            * Ugly code to complete Step 2 for Day 2 och Advent Of Code 2020. 
            * Use MinCount and MaxCount as indexes (1-based) for the chars in the password. 
            * Use XOR to determine that one, and only one of the two positions matches the required character in the password.
            **/

            bool result;
            if ((objPolicy.Password[objPolicy.MinCount - 1] == objPolicy.RequiredChar) ^ (objPolicy.Password[objPolicy.MaxCount - 1] == objPolicy.RequiredChar))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public static int Step2()
        {
            var arrStringData = File.ReadAllLines("input.txt");
            int numValidPasswords = 0;
            PasswordWithPolicy myPolicy;
            foreach (var line in arrStringData)
            {
                myPolicy = ParsePasswordPolicy(line);
                if (PasswordMeetsPolicy2(myPolicy))
                {
                    numValidPasswords++;
                }

            }
            return numValidPasswords;
        }
    }

    class PasswordPolicy
    {
        public int MinCount;
        public int MaxCount;
        public char RequiredChar;
    }

    class PasswordWithPolicy : PasswordPolicy
    {
        public string Password;
    }
}
