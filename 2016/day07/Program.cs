// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

var Lines = File.ReadAllLines("input.txt").Where(l=> !string.IsNullOrEmpty(l)).Select(l=> l.TrimEnd()).ToList<string>();

string expression;

int step1Count = 0;
int step2Count = 0;
foreach(var line in Lines)
{
    Match match;
    
    // ABA - BAB match for Step 2:
    //expression = @"\[[a-z]*([a-z])(?!\1)([a-z])\1[a-z]*\][a-z]*\2\1\2|[a-z]*([a-z])(?!\3)([a-z])\3[a-z]*\[[a-z]*\4\3\4[a-z]*\]";
    expression = @"(^|\])[a-z]*(.)(.)\2.*\[[a-z]*\3\2\3|\[[a-z]*(.)(.)\4.*\][a-z]*\5\4\5";
    match = Regex.Match(line, expression);
    if(match.Success)
    {
        step2Count++;
    }

    // Match ABBA sequence within [] = 
    expression = @"\[[a-z]*(([a-z])([a-z])(?!\2)\3\2)[a-z]*\]";
    match = Regex.Match(line,expression);
    if(match.Success)
    {
        // not good - don't count this one
        continue;
    }
    // Match ABBA sequence no matter where it is =
    expression = @"[a-z]*(([a-z])([a-z])(?!\2)\3\2)[a-z]*";
    match = Regex.Match(line, expression);
    if(match.Success)
    {
        step1Count++;
    }


}

Console.WriteLine($"Step 1, Count: {step1Count}");
Console.WriteLine($"Step 2, Count: {step2Count}"); //181 och 183 är för lågt
