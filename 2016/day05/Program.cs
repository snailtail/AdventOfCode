using System.Security.Cryptography;
using System.Text;

string input="ugkcyxxp";
//input="abc";


//Step 1
string password = string.Empty;
int index = 0;
while(password.Length < 8)
{
    string hash = GetHash($"{input}{index}");
    if(hash.Substring(0,5)=="00000")
    {
        password+=hash.Substring(5,1);
    }
    index++;
}


//Step 2
char[] password2 = new char[8];
bool[] found = new bool[8]{false,false,false,false,false,false,false,false};
int foundchars = 0;
index=0;
while(foundchars < 8)
{
        string hash = GetHash($"{input}{index}");
        if(hash.Substring(0,5)=="00000")
        { 
            int pw2idx;
            bool parsed = int.TryParse(hash.Substring(5,1),out pw2idx);
            if(parsed && pw2idx < 8 && pw2idx >=0 && !found[pw2idx])
            {
                password2[pw2idx]=hash[6];
                found[pw2idx]=true;
                foundchars++;
            }
        }
        index++;
}

Console.WriteLine(password);
Console.WriteLine(new string(password2));

string GetHash(string input)
{
    using (MD5 md5 = MD5.Create())
    {
        // Convert the input string to a byte array
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        // Compute the MD5 hash
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to a hexadecimal string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2")); // "x2" formats the byte as a two-digit hexadecimal number
        }

        return sb.ToString();
    }
}



