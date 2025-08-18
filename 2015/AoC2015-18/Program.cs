using System.Runtime.InteropServices;
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
var n = lights.GetNeighbourCountByStatus(4, 1,true);
var amount = n.Count;
Console.WriteLine($"4,1 has {amount} neighbours w. status true");


public class Light(int x, int y, bool status)
{
    public int X = x;
    public int Y = y;
    public bool Status = status;
    public bool NextStatus = false;
}

public static class Methods
{
    public static void Cycle(this Light[,] LightGrid)
    {
        // First let's cycle through all the lights, check their neigbors and set their NextStatus accordingly.
        // When that is done we swap .Status for .NextStatus
    }

    public static List<Light> GetNeighbourCountByStatus(this Light[,] LightGrid, int X, int Y, bool status)
    {
        var neighbours = LightGrid.GetNeighbours(X, Y);
        return neighbours.Where(n => n.Status == status).ToList();
    }

    public static List<Light> GetNeighbours(this Light[,] LightGrid, int X, int Y)
    {
        int length = LightGrid.GetLength(0);
        List<Light> neighbours = new List<Light>();
        (int, int)[] coord_offsets = [(0, -1), (0, 1), (-1, 0), (1, 0), (-1, -1), (-1, 1), (1, -1), (1, 1)];
        foreach ((int xo, int yo) in coord_offsets)
        {
            int x = X + xo;
            int y = Y + yo;
            if (x < length && x >= 0 && y < length && y >= 0)
            {
                neighbours.Add(LightGrid[y, x]);
            }
        }

        return neighbours;
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