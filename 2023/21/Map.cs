// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

public class Map
{
    private string[] _mapData;
    private char[,] _coordinates;
    private Coordinate _sPosition;
    public int Width
    {
        get
        {
            return _mapData[0].Length;
        }
    }

    public int Height
    {
        get
        {
            return _mapData.Length;
        }
    }

    public char[,] Coordinates => _coordinates;
    public string[] MapData => _mapData;
    public Coordinate sPosition => _sPosition;
    private HashSet<string> _reachable = new();
    public Map(string[] mapData)
    {
        this._mapData = mapData;
        (_sPosition, _coordinates) = ParseCoordinates(mapData);
    }

    private (Coordinate, char[,]) ParseCoordinates(string[] data)
    {
        Coordinate spos = null; ;
        if (data != null && data[0] != null)
        {
            int width = data[0].Length;
            int height = data.Length;
            char[,] coordinates = new char[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (data[y][x] == 'S')
                    {
                        spos = new Coordinate(y, x);
                    }
                    coordinates[y, x] = data[y][x];
                }
            }
            return (spos, coordinates);
        }
        return (new Coordinate(-1, 1), new char[0, 0]);
    }

    public long Part1(int steps)
    {
        return WalkMap(sPosition, steps - 1);
    }


    private long WalkMap(Coordinate fromPosition, int stepsLeft)
    {
        int fromY = fromPosition.Y;
        int fromX = fromPosition.X;
        string pos = $"{fromY}:{fromX}";

        if (stepsLeft == 0)
            return 0;

        // check north
        if (fromY > 0 && _coordinates[fromY - 1, fromX] == '.')
        {
            if (!_reachable.Contains($"{fromY - 1}{fromX})"))
            {
                _reachable.Add(pos);
                //Console.WriteLine($"{fromPosition.Y}:{fromPosition.Y} - {stepsLeft}");
                _ = WalkMap(new Coordinate(fromY - 1, fromX), stepsLeft - 1);
            }

        }
        // check south
        if (fromY < Height - 1 && _coordinates[fromY + 1, fromX] == '.')
        {
            if (!_reachable.Contains($"{fromY + 1}{fromX})"))
            {
                _reachable.Add(pos);
                //Console.WriteLine($"{fromPosition.Y}:{fromPosition.Y} - {stepsLeft}");
                _ = WalkMap(new Coordinate(fromY + 1, fromX), stepsLeft - 1);
            }
        }
        //check west
        if (fromX > 0 && _coordinates[fromY, fromX - 1] == '.')
        {
            if (!_reachable.Contains($"{fromY}{fromX - 1})"))
            {
                _reachable.Add(pos);
                //Console.WriteLine($"{fromPosition.Y}:{fromPosition.Y} - {stepsLeft}");
                _ = WalkMap(new Coordinate(fromY, fromX - 1), stepsLeft - 1);
            }
        }
        // check east
        if (fromX < Width - 1 && _coordinates[fromY, fromX + 1] == '.')
        {
            if (!_reachable.Contains($"{fromY}{fromX + 1})"))
            {
                _reachable.Add(pos);
                //Console.WriteLine($"{fromPosition.Y}:{fromPosition.Y} - {stepsLeft}");
                _ = WalkMap(new Coordinate(fromY, fromX + 1), stepsLeft - 1);
            }
        }
        return _reachable.Count + 1;
    }
}

public class Coordinate
{
    public int Y;
    public int X;
    public override string ToString()
    {
        return $"({Y}:{X})";
    }
    public Coordinate(int y, int x)
    {
        Y = y;
        X = x;
    }
}