using System.Text;

namespace AoC_2015
{
    public class Day10
    {
        public static void Main(string[] args)
        {
            string input = "1321131112";
            
            string Step1 = input;
            for(int n = 0; n< 40; n++)
            {
                Step1 = LookAndSay(Step1);
            }
            Console.WriteLine($"Step 1: {Step1.Length}");

            string Step2 = input;
            for(int n = 0; n< 50; n++)
            {
                Step2 = LookAndSay(Step2);
            }
            Console.WriteLine($"Step 2: {Step2.Length}");

        }

        private static string LookAndSay(string input)
        {
            int charCounter = 0;
            string returnValue = string.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int nextPos = i + 1;
                char currentChar = input[i];
                charCounter++;
                while (nextPos < input.Length && input[nextPos] == currentChar)
                {
                        nextPos++;
                        i++;
                        currentChar = input[i];
                        charCounter++;
                }                
                sb.Append(charCounter);
                sb.Append(currentChar);
                charCounter=0;
            }
            return sb.ToString();
        }
    }
}