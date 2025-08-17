using System.Collections;
using System.Text.RegularExpressions;

string[] Lines = File.ReadAllLines("input.txt").Where(l=>!string.IsNullOrEmpty(l)).Select(l=> l.Trim()).ToArray();
string rgx=@"^([0-9]+)-([0-9]+)$";


//ett sånt hashset som bara håller unika värden - använd Enumerable.Range för att lägga till värden i ranges till den.
//kolla sen lägsta värdet i den

HashSet<int> BlockedIPs = new HashSet<int>();

foreach (var line in Lines)
{
    Match match = Regex.Match(line, rgx);
    int start = int.Parse(match.Groups[1].Value);
    int end = int.Parse(match.Groups[2].Value);
    foreach(var r in Enumerable.Range(start,end))
    {
        BlockedIPs.Add(r);
    }
}


int[] sortedBlockList = BlockedIPs.ToArray();
Array.Sort(sortedBlockList);
for(int n = 0; n < sortedBlockList.Length; n++)
{
    if(!sortedBlockList.Contains(n))
    {
        Console.WriteLine($"Step 1 {n}");
        break;
    }
}
Console.ReadLine();