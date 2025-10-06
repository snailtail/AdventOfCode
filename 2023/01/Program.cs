using System.Text.RegularExpressions;

int process(string[] lines, bool stepTwo = false)
{
    int sum = 0;
    string pattern = stepTwo ? "[1-9]|one|two|three|four|five|six|seven|eight|nine" : "[1-9]";
    foreach (var line in lines)
    {
        var matchesFirst = Regex.Matches(line, pattern);
        var matchesLast = Regex.Matches(line, pattern, RegexOptions.RightToLeft);
        var firstNumber = parse(matchesFirst.First().Value);
        var lastNumber = parse(matchesLast.First().Value);
        sum += int.Parse($"{firstNumber}{lastNumber}");
    }
    return sum;
}

string parse(string input)
{
    if (input.Length > 1)
    {
        input = input switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => "?"
        };
    }
    return input;
}

var inputLines = File.ReadAllLines(@"../data/01.dat").Where(l=> !string.IsNullOrEmpty(l)).Select(l=> l.Trim()).ToArray();
Console.WriteLine($"Step 1: {process(inputLines,false)}");
Console.WriteLine($"Step 2: {process(inputLines,true)}");