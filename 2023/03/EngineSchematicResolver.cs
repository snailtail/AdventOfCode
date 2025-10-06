public class EngineSchematicResolver
{
    private char[,] schemaData;
    public List<ElfNumber> allNumbers = new();
    private List<ElfSymbol> gridSymbols = new();
    private char[] symbols = { '%', '#', '*', '$', '/', '-', '&', '+', '@', '=' };
    private int rows;
    private int cols;

    public int PartNumberSum
    {
        get
        {

            int sum = 0;
            foreach (var en in allNumbers)
            {
                if (hasAdjacentSymbols(en))
                {
                    sum += en.Value;
                }

            }
            return sum;
        }
    }

    public int GearRatioSum
    {
        get
        {
            int sum = 0;
            var possibleGears = gridSymbols.Where(g => g.Symbol == '*').ToArray();
            foreach (var pg in possibleGears)
            {
                var adjNums = getAdjacentNumbersForSymbol(pg);
                if (adjNums.Count() == 2)
                {
                    sum += adjNums[0].Value * adjNums[1].Value;
                }
            }
            return sum;
        }
    }

    public ElfNumber[] getAdjacentNumbersForSymbol(ElfSymbol es)
    {

        List<ElfNumber> foundNumbers = new();
        int fromRow = es.yPos - 1;
        int toRow = es.yPos + 1;
        int fromCol = es.xPos - 1;
        int toCol = es.xPos + 1;
        for (int y = fromRow; y <= toRow; y++)
        {
            for (int x = fromCol; x <= toCol; x++)
            {
                var neighbors = allNumbers.Where(n => n.xStart <= x && n.length + n.xStart - 1 >= x && n.yPos == y).ToArray();
                foreach (var ne in neighbors)
                {
                    foundNumbers.Add(ne);
                    x = ne.xStart + ne.length;
                    //Console.WriteLine($"Neighbor: row: {y}, col: {x}, val: {ne.Value}");
                }
            }
        }
        return foundNumbers.ToArray();
    }
    public bool hasAdjacentSymbols(ElfNumber en)
    {


        int fromRow = en.yPos - 1;
        int toRow = en.yPos + 1;
        int fromCol = en.xStart - 1;
        int toCol = en.xStart + en.length;
        for (int y = fromRow; y <= toRow; y++)
        {
            for (int x = fromCol; x <= toCol; x++)
            {
                if (gridSymbols.Any(g => g.xPos == x && g.yPos == y))
                {
                    return true;
                }
            }
        }
        return false;

    }

    public EngineSchematicResolver(string[] schematicData)
    {
        rows = schematicData.Length;
        cols = schematicData[0].Length;
        schemaData = new char[rows, cols];
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                schemaData[y, x] = schematicData[y][x];
            }
        }
        ExtractNumbersAndSymbols();
    }
    private int ExtractNumbersAndSymbols()
    {
        //Extract all the numbers and store their positions in the grid
        for (int y = 0; y < rows; y++)
        {
            int x = 0;
            ElfNumber? en = null;
            while (x < cols)
            {
                if (char.IsAsciiDigit(schemaData[y, x]))
                {
                    if (en == null)
                    {
                        en = new();
                        en.yPos = y;
                        en.xStart = x;
                        en.AddNumber(schemaData[y, x]);
                    }
                    else
                    {
                        en.AddNumber(schemaData[y, x]);
                    }
                    if (x == cols - 1)
                    {
                        allNumbers.Add(en);
                    }
                }
                else
                {
                    if (en != null)
                    {
                        allNumbers.Add(en);
                        en = null;
                    }
                    // Extract the symbol to a list of all the symbols.
                    if (symbols.Contains(schemaData[y, x]))
                    {
                        gridSymbols.Add(new ElfSymbol { Symbol = schemaData[y, x], yPos = y, xPos = x });
                    }
                }
                x++;
            }
        }




        return -1;
    }
}
