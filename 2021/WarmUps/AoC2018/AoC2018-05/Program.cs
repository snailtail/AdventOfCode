namespace AoC2018_05
{
    class AoC201805
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            Console.WriteLine($"Step 1: {ReactPolymers(input)}");
            Console.WriteLine($"Step 2: {Step2(input)}");
        }

        private static int ReactPolymers(string Input)
        {
            var stack = new Stack<char>();
            foreach (var c in Input)
            {
                if (stack.Count == 0)
                {
                    stack.Push(c);
                }
                else
                {
                    var inStack = stack.Peek();
                    var same = c != inStack && char.ToUpper(c) == char.ToUpper(inStack);
                    if (same)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
            }
            return stack.Count;
        }

        private static int Step2(string Input)
        {
            int minValue = int.MaxValue;

            string originChars = "abcdefghijklmnopqrstuvwxyz";
            foreach(var ch in originChars)
            {
                var testString = Input.Replace(ch.ToString(),"").Replace(ch.ToString().ToUpper(),"");
                var testValue = ReactPolymers(testString);
                if(testValue < minValue)
                {
                    minValue=testValue;
                }
            }
            return minValue;
        }
    }
}