namespace AdventOfCode.TwentyTwenty.Day15
{
    public class Step2
    {

        public int Compute(string[] startingNumbers, int GoalIndex)
        {
            var spokenNumbers = new int[GoalIndex];

            for (int i = 0; i < startingNumbers.Length - 1; i++)
            {
                spokenNumbers[int.Parse(startingNumbers[i])] = i + 1;
            }

            int lastNumber = int.Parse(startingNumbers[^1]);

            for (int i = startingNumbers.Length - 1; i < GoalIndex - 1; i++)
            {
                var spokenNumber = spokenNumbers[lastNumber];
                spokenNumbers[lastNumber] = i + 1;
                lastNumber = spokenNumber == 0 ? 0 : i + 1 - spokenNumber;
            }

            return lastNumber;
        }
    }
}