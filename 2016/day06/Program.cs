// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;

var lines = File.ReadAllLines("input.txt");
int numCols = lines[0].Length;
int numRows = lines.Count();

Column[] Columns = new Column[numCols];


for(int c = 0; c < numCols; c++)
{
    if(Columns[c]==null)
    {
        Columns[c] = new Column();
    }
    for(int r = 0; r < numRows; r++)
    {
        Columns[c].AddChar(lines[r][c]);
    }
}

char[] step1 = new char[numCols];
char[] step2 = new char[numCols];
for(int c = 0; c < numCols; c++)
{
    step1[c]=Columns[c].MostFrequentChar;
    step2[c]=Columns[c].LeastFrequentChar;
}

Console.WriteLine(new string(step1));
Console.WriteLine(new string(step2));


internal class Column
{
    Dictionary<char,int> CharCounts = new();
    public void AddChar(char c)
    {
        if(CharCounts.ContainsKey(c))
        {
            CharCounts[c]++;
        }
        else
        {
            CharCounts[c]=1;
        }
    }
    public char MostFrequentChar
    {
        get {

            var sorted = CharCounts.OrderByDescending(cc => cc.Value).ToArray();
            return sorted[0].Key;
        }
    }

    public char LeastFrequentChar
    {
        get {

            var sorted = CharCounts.OrderBy(cc => cc.Value).ToArray();
            return sorted[0].Key;
        }
    }

}