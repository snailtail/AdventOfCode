using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

public class Room
{
    private string? checkSum;
    private Dictionary<char,int> CharCount = new();
    private List<KeyValuePair<char,int>> sortedCharacters;
    private string? name;
    public int sectorID;
    public bool IsValid = true;

    public string? DecryptedName
    {
        get {
            return Caesar(name,sectorID);
        }
    }

    private string Caesar(string input, int key)
    {
        var chars = input.ToCharArray();
        StringBuilder sb = new();
        for(int n = 0; n< chars.Length; n++)
        {
            if(char.IsLetter(chars[n]))
            {
                int newvalue = (chars[n] + (key % 26));
                if (newvalue > 122)
                {
                    newvalue -=26;
                }
                char newChar = (char)newvalue;
                sb.Append(newChar);
            }
            else
            {
                sb.Append(chars[n]);
            }
            
        }
        return sb.ToString();
    }


    public Room(string inputstring)
    {
        var checksum = Regex.Match(inputstring,@"\[([a-z]*)\]");
        checkSum = checksum.Groups[1].Value;


        var sector = Regex.Match(inputstring,@"-([0-9]*)\[");
        sectorID = int.Parse(sector.Groups[1].Value);

        name = Regex.Match(inputstring,@"^[a-z\-]*").Value;
    
        foreach(char n in name.Replace("-",""))
        {
            if(CharCount.ContainsKey(n))
            {
                CharCount[n]++;
            }
            else
            {
                CharCount[n]=1;
            }
        }
        
        sortedCharacters = CharCount.OrderBy(ch => ch.Key).ToList();
        sortedCharacters = sortedCharacters.OrderByDescending(ch => ch.Value).ToList();
        foreach(KeyValuePair<char,int> kvp in sortedCharacters)
        {
            //Console.WriteLine(kvp.Key + " - " + kvp.Value);
        }
        for(int n = 0; n< checkSum.Length; n++)
        {
            if(sortedCharacters[n].Key != checkSum[n])
            {
                IsValid = false;
                break;
            }
        }

        //Console.WriteLine($"Add new Room: name [{name}], status: {IsValid}");

    }
}