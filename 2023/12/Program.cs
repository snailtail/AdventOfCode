var lines = File.ReadAllLines("../data/12.dat");
ConditionRecord cr;
long sum = 0;
foreach(var line in lines)
{
    cr = new ConditionRecord(line);
    sum+=cr.ValidSpringConditionCount;
    
}
Console.WriteLine($"Part 1: {sum}");