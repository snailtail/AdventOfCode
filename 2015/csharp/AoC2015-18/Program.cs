string path = "input.dat";
var input = File.ReadAllLines(path);

Solve(false); // part 1
Solve(true);  // part 2


void Solve(bool Part2)
{

    Light[,] lights = new Light[input.Length,input.Length];
    for (int y = 0; y < input.Length; y++)
    {
        for (int x = 0; x < input.Length; x++)
        {
            lights[y, x] = new Light(x, y, input[y][x] == '#');
        }
    }

    Console.WriteLine($"Imported light grid... Length is at: {lights.GetLength(0)}");

    foreach (var i in Enumerable.Range(0, 100))
    {
        lights.Cycle(Part2);
    }

    int count = 0;
    foreach (Light light in lights)
    {
        count += light.Status == true ? 1 : 0;
    }
    string partPart = Part2 == true ? "2" : "1";
    Console.WriteLine($"Part {partPart}: {count}");
}


public class Light(int x, int y, bool status)
{
    public int X = x;
    public int Y = y;
    public bool Status = status;
    public bool NextStatus = false;
}

public static class Methods
{
    public static void Cycle(this Light[,] LightGrid, bool Part2 = false)
    {
        LightGrid.UpdateNextStatus();
        LightGrid.ApplyNextStatus(Part2);
    }

    public static void ApplyNextStatus(this Light[,] LightGrid, bool Part2 = false)
    {
        int length = LightGrid.GetLength(0);
        foreach(Light light in LightGrid)
        {
            if (Part2 == true && ((light.X == 0 && light.Y == 0) || (light.X == length - 1 && light.Y == length - 1) || (light.X == 0 && light.Y == length - 1) || (light.X == length - 1 && light.Y == 0)))
            {
                light.Status = true;
                continue;
            }
            else
            {
                light.Status = light.NextStatus;                
            }
        }
    }
    

    public static void UpdateNextStatus(this Light[,] LightGrid)
    {
        int length = LightGrid.GetLength(0);
        // First let's cycle through all the lights, check their neigbors and set their NextStatus accordingly.
        /*
            The state a light should have next is based on its current state (on or off) plus the number of neighbors that are on:

            A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
            A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.

        */
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < length; x++)
            {
                var neighbourCount = LightGrid.GetNeighbourCountByStatus(x, y, true);
                if (LightGrid[y, x].Status == true)
                {
                    if (neighbourCount.Count == 2 || neighbourCount.Count == 3)
                    {
                        LightGrid[y, x].NextStatus = true;
                    }
                    else
                    {
                        LightGrid[y, x].NextStatus = false;
                    }
                }
                else
                {
                    if (neighbourCount.Count == 3)
                    {
                        LightGrid[y, x].NextStatus = true;
                    }
                    else
                    {
                        LightGrid[y, x].NextStatus = false;
                    }
                }

            }
        }
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
        Console.WriteLine();
        Console.WriteLine();
    }
}