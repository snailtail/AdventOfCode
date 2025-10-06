



char[][] mapData = File.ReadAllLines("../data/10.dat").Select(l => l.ToCharArray()).ToArray();
int Sx = 0, Sy = 0;
for (int y = 0; y < mapData.Length; y++)
{
    for (int x = 0; x < mapData[0].Length; x++)
    {
        if (mapData[y][x] == 'S')
        {
            Sx = x;
            Sy = y;
        }
    }
}


Console.WriteLine($"Part 1: {Solve(mapData, Sx, Sy)}");
var part2 = new PartTwo();
part2.Solve();

int Solve(char[][] m, int startX, int startY)
{

    HashSet<char> Possible_S = new() { '|', '-', 'J', 'L', 'F', '7' };
    Queue<(int, int)> q = new();
    HashSet<(int, int)> Visited = new();
    char[] north = { 'S', '|', 'L', 'J' };
    char[] south = { 'S', '|', '7', 'F' };
    char[] east = { 'S', '-', 'L', 'F' };
    char[] west = { 'S', '-', 'J', '7' };

    q.Enqueue((startY, startX));
    Visited.Add((startY, startX));
    while (q.Count > 0)
    {
        (int y, int x) = q.Dequeue();
        // go north
        if (y > 0 && !Visited.Contains((y - 1, x)) && north.Any(c => c == m[y][x]) && south.Any(c => c == m[y - 1][x]))
        {
            Visited.Add((y - 1, x));
            q.Enqueue((y - 1, x));
           

        }

        // go south
        if (y < m.Length - 1 && !Visited.Contains((y + 1, x)) && south.Any(c => c == m[y][x]) && north.Any(c => c == m[y + 1][x]))
        {
            Visited.Add((y + 1, x));
            q.Enqueue((y + 1, x));
           
        }

        // go west
        if (x > 0 && !Visited.Contains((y, x - 1)) && west.Any(c => c == m[y][x]) && east.Any(c => c == m[y][x - 1]))
        {
            Visited.Add((y, x - 1));
            q.Enqueue((y, x - 1));
           
        }

        // go east
        if (x < m[0].Length - 1 && !Visited.Contains((y, x + 1)) && east.Any(c => c == m[y][x]) && west.Any(c => c == m[y][x + 1]))
        {
            Visited.Add((y, x + 1));
            q.Enqueue((y, x + 1));
            
        }

    }
        return Visited.Count / 2;
}




