using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.TwentyFifteen.Day04
{

    public class MD5HashFinder
    {
        public long FindNumberForKey(string Key)
        {
            long testNum = 0;
            string firstFive = string.Empty;
            while (true)
            {
                var hash = CreateMD5($"{Key}{testNum}");
                firstFive = hash.Substring(0, 5);
                if (firstFive == "00000")
                {
                    break;
                }
                else
                {
                    testNum += 1;
                }

            };

            return testNum;
        }

        public long FindNumberForKeyStep2(string Key)
        {
            long testNum = 0;
            string firstSix = string.Empty;
            while (true)
            {
                var hash = CreateMD5($"{Key}{testNum}");
                firstSix = hash.Substring(0, 6);
                if (firstSix == "000000")
                {
                    break;
                }
                else
                {
                    testNum += 1;
                }

            };

            return testNum;
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}