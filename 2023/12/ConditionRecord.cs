using System.Text.RegularExpressions;

public class ConditionRecord
{
    private char[] _springConditions;
    private int[] _groupSizes;
    private string _regexPattern
    {
        get
        {

            string p = @"^\.*";
            for (int i = 0; i < _groupSizes.Length; i++)
            {

                p += @"#{";
                p += _groupSizes[i].ToString();
                p += i == _groupSizes.Length - 1 ? @"}" : @"}\.+";
            }
            return p;
        }
    }
    public int[] GroupSizes => _groupSizes;
    public string RegexPattern => _regexPattern;

    private List<string> _validSpringConditions;

    public List<string> ValidSpringConditions => _validSpringConditions;
    public long ValidSpringConditionCount => _validSpringConditions.Count;
    public string SpringConditions => new string(_springConditions);

    public ConditionRecord(string RecordData)
    {
        var parts = RecordData.Split(" ");

        _springConditions = parts[0].ToCharArray();
        _groupSizes = parts[1].Split(",").Select(c => int.Parse(c)).ToArray();
        _validSpringConditions = GenerateCombinations(_springConditions, 0).Where(c => CombinationIsValid(c)).ToList();
    }



    private bool CombinationIsValid(string Combination)
    {
        if (Combination.Where(c => c == '#').Count() != _groupSizes.Sum())
        {
            return false;
        }
        Match match = Regex.Match(Combination, _regexPattern);
        return match.Success;
    }

    private List<string> GenerateCombinations(char[] array, int index)
    {
        List<string> result = new List<string>();

        if (index == array.Length)
        {
            var cbo = new string(array);
            result.Add(cbo);
            return result;
        }

        if (array[index] == '?')
        {
            array[index] = '.';
            result.AddRange(GenerateCombinations(array, index + 1));

            array[index] = '#';
            result.AddRange(GenerateCombinations(array, index + 1));

            // Backtrack to restore the original state
            array[index] = '?';
        }
        else
        {
            result.AddRange(GenerateCombinations(array, index + 1));
        }

        return result;
    }
}