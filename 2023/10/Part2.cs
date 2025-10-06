public class PartTwo
{        
    private void ScaleTiles(int row, int col, char ch, char[,] map)
    {           
        (int, int, char)[] pattern = ch switch 
        {
            '.' => [ (0,0,'.'), (0,1,'.'), (0,2,'.'),
                     (1,0,'.'), (1,1,'.'), (1,2,'.'),
                     (2,0,'.'), (2,1,'.'), (2,2,'.')],
            'S' => [ (0,0,'.'), (0,1,'S'), (0,2,'.'),
                     (1,0,'S'), (1,1,'S'), (1,2,'S'),
                     (2,0,'.'), (2,1,'S'), (2,2,'.')],
            '|' => [ (0,0,'.'), (0,1,'|'), (0,2,'.'),
                     (1,0,'.'), (1,1,'|'), (1,2,'.'),
                     (2,0,'.'), (2,1,'|'), (2,2,'.')],
            '-' => [ (0,0,'.'), (0,1,'.'), (0,2,'.'),
                     (1,0,'-'), (1,1,'-'), (1,2,'-'),
                     (2,0,'.'), (2,1,'.'), (2,2,'.')],
            'L' => [ (0,0,'.'), (0,1,'|'), (0,2,'.'),
                     (1,0,'.'), (1,1,'+'), (1,2,'-'),
                     (2,0,'.'), (2,1,'.'), (2,2,'.')],
            'J' => [ (0,0,'.'), (0,1,'|'), (0,2,'.'),
                     (1,0,'-'), (1,1,'+'), (1,2,'.'),
                     (2,0,'.'), (2,1,'.'), (2,2,'.')],
            '7' => [ (0,0,'.'), (0,1,'.'), (0,2,'.'),
                     (1,0,'-'), (1,1,'+'), (1,2,'.'),
                     (2,0,'.'), (2,1,'|'), (2,2,'.')],
            'F' => [ (0,0,'.'), (0,1,'.'), (0,2,'.'),
                     (1,0,'.'), (1,1,'+'), (1,2,'-'),
                     (2,0,'.'), (2,1,'|'), (2,2,'.')],
            _ => throw new Exception("that was unexpected...!")
        };

        foreach (var p in pattern)             
            map[row + p.Item1, col + p.Item2] = p.Item3;
    }

    private char[,] ReadMapData()
    {
        var lines = File.ReadAllLines(@"../data/10.dat");
        int length = lines.Length;
        int width = lines[0].Length;

        // Put a border of .s around the actual map to make the flood fill easier
        char[,] map = new char[(length + 1) * 3, (width + 1) * 3];
        for (int r = 0; r < map.GetLength(0) - 1; r++) 
        {
            for (int c = 0; c < map.GetLength(1) - 1; c++) 
            {
                map[r, c] = '.';
            }
        }
       
        for (int r = 0; r < length; r++) 
        {
            for (int c = 0; c < width; c++)
            {
                ScaleTiles( r * 3 + 1, c * 3 + 1, lines[r][c], map);                    
            }                
        }

        return map;
    }

    private void FloodFill(char[,] map) 
    {
        var adjacent = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        var length = map.GetLength(0);
        var width = map.GetLength(1);
        var locs = new Queue<(int, int)>();
        locs.Enqueue((0, 0));
        var visited = new HashSet<(int, int)>();
        
        do 
        {
            var loc = locs.Dequeue();
            if (visited.Contains(loc))
                continue;
            map[loc.Item1, loc.Item2] = 'o';
            visited.Add((loc.Item1, loc.Item2));

            foreach (var n in adjacent)
            {                    
                var nr = loc.Item1 + n.Item1;
                var nc = loc.Item2 + n.Item2;
                if (nr < 0 || nr >= length || nc < 0 || nc >= width || visited.Contains((nr, nc)))
                    continue;
                if (map[nr, nc] == '.')
                    locs.Enqueue((nr, nc));
            }
        } 
        while (locs.Count > 0);
    }

    private int GetInnerCount(char[,] map)
    {
        var length = map.GetLength(0) - 1;
        var width = map.GetLength(1) - 1;
        int count = 0;
        var pixels = new (int, int)[] { (0, 0), (0, 1), (0, 2), (1, 0), (1, 1), (1, 2), (2, 0), (2, 1), (2, 2) };

        for (int r = 1; r < length; r += 3) 
        {
            for (int c = 1; c < width; c += 3)
            {
                bool isInner = true;
                foreach (var p in pixels) 
                {
                    if (map[r + p.Item1, c + p.Item2] == 'o')
                    {
                        isInner = false;
                        break;
                    }
                }
                if (isInner) ++count;
            }                    
        }

        return count;
    }

    public void Solve() 
    {
        var mapData = ReadMapData();
        FloodFill(mapData);
        Console.WriteLine($"P2: {GetInnerCount(mapData)}");
    }
}