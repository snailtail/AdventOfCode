
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

string input="ADVENT"; // should be 6
input = File.ReadAllText("input.txt");
//input = "A(1x5)BC"; // should be 7 (ABBBBBC)
//input ="(3x3)XYZ"; // should be 9 (XYZXYZXYZ)
//input="X(8x2)(3x3)ABCY"; // should be 18 (X(3x3)ABC(3x3)ABCY)

// If parentheses or other characters appear within the data referenced by a marker, 
// that's okay - treat it like normal data, not a marker, and then resume looking
// for markers !!!!after the decompressed section!!!



bool part2 = false;
Console.WriteLine(decompress(input));
part2 = true;
Console.WriteLine(decompress(input));

long decompress(string s)
{
    if(s.IndexOf('(')==-1)
    {
        return s.Length;
    }

    long ret = 0;
    while(s.IndexOf('(')!=-1)
    {
        ret += s.IndexOf('(');
        s = s[s.IndexOf('(')..];
        var marker = s[1..s.IndexOf(')')].Split('x');
        s = s[(s.IndexOf(')') + 1)..];
        if(part2)
        {   
            ret += decompress(s[0..int.Parse(marker[0])]) * long.Parse(marker[1]);
        }
        else
        {

            ret += (s[0..int.Parse(marker[0])]).Length * long.Parse(marker[1]);
        }
        s = s[int.Parse(marker[0])..];
    }
    ret += s.Length;
    return ret;
}



(int, int) ParseMarker(string marker)
{
    marker = marker.Replace("(","").Replace(")","");
    int chars = int.Parse(marker.Split("x")[0]);
    int repeat = int.Parse(marker.Split("x")[1]);
    return (chars,repeat);
}

