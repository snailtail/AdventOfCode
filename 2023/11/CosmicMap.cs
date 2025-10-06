public class CosmicMap
{
    private long addedMultiplicator;
    private int mapWidth;
    private string map;
    private int rowCount;
    private List<Galaxy> galaxies = new();

    public List<Galaxy> Galaxies => galaxies;

    public int MapWidth => mapWidth;
    public int RowCount => rowCount;
    private Queue<int> columnsToDuplicate = new();
    private Queue<int> rowsToDuplicate = new();
    private HashSet<int> duplicatedRows = new();
    private HashSet<int> duplicatedCols = new();
    private HashSet<GalaxyCoordinate> UsedInpair = new();

    public CosmicMap(string filePath = "../data/11test.dat", long AddedMultiplicator = 2)
    {
        string[] mapData = File.ReadAllText(filePath).Split(Environment.NewLine);
        mapWidth = mapData[0].Length;
        map = string.Join("", mapData);
        rowCount = map.Length / mapWidth;
        addedMultiplicator=AddedMultiplicator-1;
        ExtendMap();
        ScanForGalaxies();
    }


    public long SumOfShortestPathsBetweenPairs()
    {
        long sum = 0;
        for (int x = 0; x < galaxies.Count; x++)
        {
            UsedInpair.Add(galaxies[x].Coordinate);
            var neighborGalaxies = galaxies.Where(g => !UsedInpair.Contains(g.Coordinate)).ToArray();
            foreach (var g in neighborGalaxies)
            {
                long distance = CalculateManhattanDistance(galaxies[x].Coordinate, g.Coordinate);
                sum += distance;
            }
        }
        return sum;
    }


    public void ScanForGalaxies()
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                if (map[row * mapWidth + col] == '#')
                {
                    galaxies.Add(new Galaxy(row, col));
                }
            }
        }
    }
    public void ExtendMap()
    {


        for (int i = 0; i < mapWidth; i++)
        {
            if (ColumnIsEmpty(i))
            {
                columnsToDuplicate.Enqueue(i);
                duplicatedCols.Add(i);
            }

        }
        for (int i = 0; i * mapWidth < map.Length; i++)
        {
            if (RowIsEmpty(i))
            {
                rowsToDuplicate.Enqueue(i);
                duplicatedRows.Add(i);
            }
        }
    }


    public string GetPrintableMap()
    {
        int row = 0;
        string output = "";
        while (row * mapWidth < map.Length)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                output += map[row * mapWidth + col];
            }
            output += Environment.NewLine;
            row++;
        }
        return output;
    }


    public long CalculateManhattanDistance(GalaxyCoordinate point1, GalaxyCoordinate point2)
    {
        long minX = Math.Min(point1.X, point2.X);
        long minY = Math.Min(point1.Y, point2.Y);

        long maxX = Math.Max(point1.X, point2.X);
        long maxY = Math.Max(point1.Y, point2.Y);

        int extendedRows = duplicatedRows.Where(r=> r >=minY && r <=maxY).Count();
        int extendedCols = duplicatedCols.Where(c=> c >=minX && c <=maxX).Count();

        long addedY = addedMultiplicator * extendedRows;
        long addedX = addedMultiplicator * extendedCols;

        maxY +=addedY;
        maxX+=addedX;
        long deltaY = Math.Abs(maxY - minY);
        long deltaX = Math.Abs(maxX - minX);

        return deltaY + deltaX;
    }
    bool ColumnIsEmpty(int columnIndex)
    {
        int row = 0;
        while (row * mapWidth < map.Length)
        {

            if (map[row * mapWidth + columnIndex] == '#')
            {
                return false;
            }
            row++;
        }
        return true;
    }

    bool RowIsEmpty(int rowIndex)
    {
        for (int col = 0; col < mapWidth; col++)
        {
            if (map[rowIndex * mapWidth + col] == '#')
            {
                return false;
            }
        }
        return true;
    }
}