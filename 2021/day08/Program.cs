namespace AdventOfCode
{
    public static class Day08
    {
        public static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();
            Console.WriteLine($"Step1: {Step1(lines)}");
            Console.WriteLine($"Step2: {Step2(lines)}");
        }

        private static int Step1(string[] lines)
        {
            int countStep1 = 0;
            foreach (var line in lines)
            {
                countStep1 += CountStep1(line.Split(" | ")[1]);
            }
            return countStep1;
        }

        private static int Step2(string[] lines)
        {
            int step2Sum = 0;
            foreach (var line in lines)
            {
                var thisSum=step2OutputValue(line.Split(" | ")[0], line.Split(" | ")[1]);
                step2Sum += thisSum;
            }
            return step2Sum;
        }

        private static int CountStep1(string outputValues)
        {
            string[] parts = outputValues.Split(" ");
            int count = 0;
            foreach (var part in parts)
            {
                switch (part.Length)
                {
                    case 2: // a 1
                    case 3: // a 7
                    case 4: // a 4
                    case 7: // an 8
                        count++;
                        break;
                    default:
                        break;
                }
            }
            return count;
        }

        private static string sortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        private static int step2OutputValue(string signalPatterns, string outputValues)
        {
            string[] signalParts = signalPatterns.Split(" ");
            string[] signals = new string[10];
            string[] outputParts = outputValues.Split(" ");

            // first store the ones we know the unique length for:
            foreach (var signal in signalParts)
            {
                if (signal.Length == 2)
                {
                    signals[1] = signal;
                }
                if (signal.Length == 3)
                {
                    signals[7] = signal;
                }
                if (signal.Length == 4)
                {
                    signals[4] = signal;
                }
                if (signal.Length == 7)
                {
                    signals[8] = signal;
                }
            }
            
            var top = stringDifference(signals[7], signals[1]);
            signals[3] = signalParts.Where(s => (s.Length == 5 && (s.Contains(signals[1][0]) && s.Contains(signals[1][1])))).FirstOrDefault();
            var leftEdgeBoth = stringDifference(signals[8], signals[3]);
            signals[9] = signalParts.Where(s =>
                s.Length == 6
                && (
                        (!s.Contains(leftEdgeBoth[0]) && s.Contains(leftEdgeBoth[1]))
                        ||
                        (!s.Contains(leftEdgeBoth[1]) && s.Contains(leftEdgeBoth[0]))
                    )
                ).FirstOrDefault();
            var leftDown = stringDifference(signals[8], signals[9]);
            signals[2] = signalParts.Where(s => s.Length == 5 && s.Contains(leftDown)).FirstOrDefault();
            var bottomRight = stringDifference(signals[1], signals[2]);
            var topRight = stringDifference(signals[1], bottomRight);
            signals[5] = signalParts.Where(s => (s.Length == 5 && !s.Contains(leftDown) && !s.Contains(topRight))).FirstOrDefault();
            signals[6] = signalParts.Where(s => s.Length == 6 && (s != signals[9] && !s.Contains(topRight))).FirstOrDefault();
            signals[0]= signalParts.Where(s => s.Length == 6 && ( s!=signals[6] && s!= signals[9])).FirstOrDefault();
            var resultString = string.Empty;
            foreach(var part in outputParts)
            {
                for(int n = 0; n<10; n++)
                {
                    if(sortString(part)==sortString(signals[n]))
                    {
                        resultString += $"{n}";
                    }
                }
            }
            return int.Parse(resultString);
        }

        private static string stringDifference(string string1, string string2)
        {
            char[] c1 = string1.ToCharArray();
            char[] c2 = string2.ToCharArray();

            var difference = c1.Except(c2).ToArray();
            return new string(difference);
        }
    }


}