using System.Security.Cryptography.X509Certificates;

string path = "testinput.dat";
var input = File.ReadAllLines(path);
Console.WriteLine(input.Length);
Light[,] lights = new Light[input.Length,input.Length];
for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input.Length; x++)
    {
        lights[y, x] = new Light(x, y, input[y][x] == '#');
    }
}

Console.WriteLine($"Imported light grid... Length is at: {lights.GetLength(0)}");
lights.PrintGrid();


public class Light(int x, int y, bool status)
{
    public int X = x;
    public int Y = y;
    public bool Status = status;
    public bool NextStatus = false;
}

public static class Methods
{

    public static List<Light> GetNeighbors(Light[] Grid, int X, int Y)
    {
        List<Light> neighbors = new List<Light>();
        return neighbors;
    }
    public static void PrintGrid(this Light[,] LightGrid)
    {
        int length = LightGrid.GetLength(0);
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < length; x++)
            {
                Console.Write(LightGrid[y, x].Status == true ? "#" : ".");
            }
            Console.WriteLine();
        }
    }
}