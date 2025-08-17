



using System.Text;

string FillDisk(string a, int disklength)
{
    if(a.Length >= disklength)
    {
        return a.Substring(0,disklength);
    }
    
    char[] reversedA = a.ToCharArray();

    Array.Reverse(reversedA);
    //replace 1 with 0 and 0 with 1
    for(int n = 0; n< reversedA.Length; n++)
    {
        reversedA[n] = reversedA[n]=='0' ? '1' : '0';
    }

    string b = new string(reversedA);

    string tot = a + "0" + b;
    return FillDisk(tot, disklength);
}



string CalculateChecksum(string input)
{
    StringBuilder sb = new();
    for(int n = 0; n< input.Length; n=n+2)
    {
        if(input[n+1]==input[n])
        {
            sb.Append("1");
        }
        else
        {
            sb.Append("0");
        }
    }
    string checksum = sb.ToString();
    if(checksum.Length % 2 ==0)
    {
        return CalculateChecksum(checksum);
    }
    else
    {
        return checksum;
    }

}


string a ="10001001100000001";
int diskLength = 272;
string data=FillDisk(a,diskLength);
string checksum = CalculateChecksum(data);
Console.WriteLine($"Step1: {checksum}");

diskLength = 35651584;
data=FillDisk(a,diskLength);
checksum = CalculateChecksum(data);
Console.WriteLine($"Step2: {checksum}");
