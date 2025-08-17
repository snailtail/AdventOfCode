namespace AdventOfCode
{
    public static class Day10
    {
        private static Stack<char> openers = new();
        private static Stack<char> closers = new();
        private static char[] validopeners = { '{', '(', '[', '<' };
        private static char[] validclosers = { '}', ')', ']', '>' };

        public static void Main(string[] args)
        {
            List<string> lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToList();
            List<string> correctLines = new();
            long sumStep1 = 0;

            foreach (var line in lines)
            {
                char? illegalChar = firstIllegalChar(line);
                if (illegalChar != null)
                {
                    sumStep1 += illegalCharValue(illegalChar);
                }
                else
                {
                    correctLines.Add(line);
                }
            }
            Console.WriteLine($"Step 1: {sumStep1}");

            //Step 2:
            List<long> autoCompletionScores = new();
            foreach (var line in correctLines)
            {
                autoCompletionScores.Add(getAutoCompletionScore(line));
            }
            var sorted = autoCompletionScores.OrderBy(acs => acs).ToArray();
            var median = sorted[(sorted.Length/2)];
            Console.WriteLine($"Step 2: {median}");
        }

        private static char? firstIllegalChar(string input)
        {
            foreach (char c in input.ToCharArray())
            {
                if (validopeners.Contains(c))
                {
                    var expectedCloser = getValidCloser(c);
                    openers.Push(c);
                }

                if (validclosers.Contains(c))
                {
                    var expectedCloser = getValidCloser(openers.Peek());
                    if (expectedCloser == c)
                    {
                        openers.Pop();
                    }
                    else
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        private static long getAutoCompletionScore(string line)
        {
            long completionData = 0;
            openers.Clear();
            closers.Clear();
            foreach (char c in line.ToCharArray())
            {
                if (validopeners.Contains(c))
                {
                    var expectedCloser = getValidCloser(c);
                    openers.Push(c);
                }

                if (validclosers.Contains(c))
                {
                    var expectedCloser = getValidCloser(openers.Peek());
                    if (expectedCloser == c)
                    {
                        openers.Pop();
                    }
                    else
                    {
                        Console.WriteLine($"Error! Expected: {expectedCloser} found: {c}. ");
                        throw new SystemException("This line seems to be invalid, cannot continue!");
                    }
                }
            }
            while (openers.Count > 0)
            {
                long charValue = autoCompleteCharValue(getValidCloser(openers.Pop()));
                completionData = (completionData * 5) + charValue;
            }
            return completionData;
        }

        private static int illegalCharValue(char? c)
        {
            int value = 0;
            switch (c)
            {
                case ']':
                    value = 57;
                    break;
                case '}':
                    value = 1197;
                    break;
                case ')':
                    value = 3;
                    break;
                case '>':
                    value = 25137;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }

        private static int autoCompleteCharValue(char? c)
        {
            int value = 0;
            switch (c)
            {
                case ']':
                    value = 2;
                    break;
                case '}':
                    value = 3;
                    break;
                case ')':
                    value = 1;
                    break;
                case '>':
                    value = 4;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }

        private static char getValidCloser(char c)
        {
            char closer;
            switch (c)
            {
                case '<':
                    closer = '>';
                    break;
                case '{':
                    closer = '}';
                    break;
                case '(':
                    closer = ')';
                    break;
                case '[':
                    closer = ']';
                    break;
                default:
                    closer = '?';
                    break;
            }
            return closer;
        }
    }
}