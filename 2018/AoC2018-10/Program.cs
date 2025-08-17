using System.Text;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input.txt");


Screen sc = new(lines);
//sc.Print();
while (true)
{
    sc.Refresh();
    // I found out by checking over and over again that the smallest screensize was 61 pixels wide. 
    // I took a chance that this would be when the message was displayed. and it was.
    if(sc.width==61)
        sc.Print();

    if (sc.width < 100)
    {
        Console.WriteLine($"Seconds passed: {sc.refreshes}. Width: {sc.width}   Press ENTER to refresh.");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine($"Seconds passed: {sc.refreshes}. Width: {sc.width}");
    }
}

internal class Pixel
{
    public int X;
    public int Y;
    public int velocityX;
    public int velocityY;

    public Pixel(int x, int y, int velx, int vely)
    {
        X = x;
        Y = y;
        velocityX = velx;
        velocityY = vely;
    }
}

internal class Screen
{
    public List<Pixel> Pixels = new();

    int minY = int.MaxValue;
    int minX = int.MaxValue;
    int maxY = int.MinValue;
    int maxX = int.MinValue;
    public int refreshes = 0;
    public int width;
    public int height;
    public Screen(string[] lines)
    {
        string pattern = @"^position=<\s*(-*)(\d+),\s*(-*)(\d+)>\s*velocity=<\s*(-*)(\d+),\s*(-*)(\d+)>$";

        foreach (var line in lines)
        {
            var match = Regex.Match(line, pattern);
            if (match.Success)
            {
                //Console.WriteLine(match.Groups[1].Value);
                int posx = getNumber(match.Groups[1].Value == "-", match.Groups[2].Value);
                int posy = getNumber(match.Groups[3].Value == "-", match.Groups[4].Value);
                int velx = getNumber(match.Groups[5].Value == "-", match.Groups[6].Value);
                int vely = getNumber(match.Groups[7].Value == "-", match.Groups[8].Value);
                minY = Math.Min(posy, minY);
                minX = Math.Min(posx, minX);
                maxY = Math.Max(posy, maxY);
                maxX = Math.Max(posx, maxX);

                Console.WriteLine($"PosX: {posx}, PosY: {posy}, VelX: {velx}, VelY: {vely}");
                Pixels.Add(new Pixel(posx, posy, velx, vely));
            }

        }
    }

    public void Refresh()
    {
        refreshes++;
        Console.WriteLine($"-----REFRESH {refreshes}-----");
        minY = int.MaxValue;
        minX = int.MaxValue;
        maxY = int.MinValue;
        maxX = int.MinValue;
        foreach (var px in Pixels)
        {
            px.X += px.velocityX;
            px.Y += px.velocityY;
            minY = Math.Min(px.Y, minY);
            minX = Math.Min(px.X, minX);
            maxY = Math.Max(px.Y, maxY);
            maxX = Math.Max(px.X, maxX);
        }

        width = maxX - minX;
        height = maxY - minY;
    }

    public void Print()
    {
        // kan vi printa till en bild - bmp eller nåt enkelt svartvitt? som man kan undersöka?
        StringBuilder sb = new();
        for (int y = minY; y <= maxY; y++)
        {
            sb.Clear();
            for (int x = minX; x <= maxX; x++)
            {
                if (Pixels.Any(p => p.X == x && p.Y == y))
                {
                    sb.Append("#");
                    //Console.Write("#");
                }
                else
                {
                    sb.Append(".");
                    //Console.Write(".");
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }

    int getNumber(bool negative, string number)
    {
        int num = int.Parse(number);
        int multiplier = negative ? -1 : 1;
        return num * multiplier;
    }

}