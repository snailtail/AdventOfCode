var steps = File.ReadAllText("../data/15.dat").Replace("\n","").Split(",").ToArray();
int step1Value = 0;
foreach(var s in steps)
{
    step1Value+=GetHashValue(s);
}
Console.WriteLine($"Part 1: {step1Value}");

int GetHashValue(string instruction)
{
    int curValue=0;
    foreach(char c in instruction)
    {
        int charvalue = (int)c;
        curValue+=charvalue;
        curValue *=17;
        curValue = curValue % 256;

    }
    return curValue;
}