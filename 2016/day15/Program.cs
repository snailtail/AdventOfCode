using System.Text.RegularExpressions;

string[] Lines = File.ReadAllLines("testinput.txt");
int discCount = Lines.Length;

Spindle sp = new();

string regExpr = @"Disc #([0-9]+) has ([0-9]+) positions;.*it is at position ([0-9]+)";
foreach(var line in Lines)
{

    Match check = Regex.Match(line,regExpr);
    int discNo = int.Parse(check.Groups[1].Value);
    int discSize = int.Parse(check.Groups[2].Value);
    int discPos = int.Parse(check.Groups[3].Value);
    sp.AddDisc(discNo,discSize,discPos);
    
}

//Hur långt till nästa öppna position (när första discen är mottaglig)



Console.ReadLine();