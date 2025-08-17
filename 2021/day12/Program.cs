namespace AdventOfCode;

public class Day12
{
    private static List<Cave> Caves = new List<Cave>();
    private static Queue<CavePath> Paths = new Queue<CavePath>();
    private static List<CavePath> fullPaths = new List<CavePath>();
    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();
        Caves.Clear();
        foreach (string line in lines)
        {
            LoadCaves(line);
        }

        var startCaves = Caves.Where(c => c.Name == "start").ToArray();
        foreach (var c in startCaves)
        {
            foreach (var relatedCave in c.relatedCaves)
            {
                c.VisitCount++;
                Paths.Enqueue(new CavePath(c.Name, relatedCave));
            }
        }
        Console.WriteLine(Explore(false));

    }

    private static void PrintAndClearQueue()
    {
        while (Paths.Count > 0)
        {
            Console.WriteLine(Paths.Dequeue());
        }
    }

    private static int Explore(bool Step1 = true)
    {
        int maxSmallOccurences;
        if (Step1)
        {
            maxSmallOccurences = 1;
        }
        else
        {
            maxSmallOccurences = 2;
        }
        while (Paths.Count > 0)
        {
            CavePath activePath = Paths.Dequeue();
            Cave nextCave = Caves.Where(c => c.Name == activePath.ToCave).FirstOrDefault();

            foreach (string c in nextCave.relatedCaves.Where(rc => rc != activePath.FromCave).ToArray())
            {

                if (c != "start" && c != "end")
                {
                    if (
                                    (Step1 == false &&
                                        (c == c.ToLower() &&
                                        !activePath.HasTwoOrMoreSmallCavesAlready &&
                                        activePath.CaveOccurrences(c) < maxSmallOccurences)
                                    )
                                    ||
                                    (Step1 == false &&
                                        (c == c.ToLower() &&
                                        activePath.HasTwoOrMoreSmallCavesAlready &&
                                        activePath.CaveOccurrences(c) == 0)
                                    )
                                    ||
                                    (Step1 == false &&
                                        (c.ToLower() != c)
                                    )
                        )
                    {
                        var path = activePath.AppendCave(c);
                        Paths.Enqueue(path);
                    }
                    else if(
                                (Step1 == true &&
                                (c.ToLower() != c))
                                ||
                                (Step1 == true &&
                                (c == c.ToLower() && activePath.CaveOccurrences(c) < maxSmallOccurences))
                           )
                    {
                        var path = activePath.AppendCave(c);
                        Paths.Enqueue(path);
                    }
                }
                else if (c == "end")
                {
                    var path = activePath.AppendCave(c);
                    if (!fullPaths.Contains(path))
                    {
                        fullPaths.Add(path);
                    }
                }
            }
        }

        return fullPaths.Count();
    }

    private static void LoadCaves(string line)
    {

        string name1, name2 = string.Empty;
        name1 = line.Split("-")[0];
        name2 = line.Split("-")[1];
        var existingCave = Caves.Where(c => c.Name == name1).FirstOrDefault();
        if (existingCave != null)
        {
            existingCave.relatedCaves.Add(name2);
        }
        else
        {
            Caves.Add(new Cave(name1, name2));
        }

        existingCave = Caves.Where(c => c.Name == name2).FirstOrDefault();
        if (existingCave != null)
        {
            existingCave.relatedCaves.Add(name1);
        }
        else
        {
            Caves.Add(new Cave(name2, name1));
        }
    }
}

public class CavePath
{

    public string Path { get; private set; }
    public string FromCave { get; set; }
    public string ToCave { get; set; }

    public CavePath(string start, string next)
    {
        Path = $"{start}-{next}";
        FromCave = start;
        ToCave = next;
    }

    public CavePath(string start, string existingPath, string next)
    {
        Path = existingPath;
        FromCave = start;
        ToCave = next;
    }
    public CavePath AppendCave(string caveName)
    {
        string nPath = $"{Path}-{caveName}";
        CavePath newPath = new CavePath(FromCave, nPath, caveName);
        return newPath;
    }

    public int CaveOccurrences(string caveName) => Path.Split(caveName).Count() - 1;

    public bool HasTwoOrMoreSmallCavesAlready
    {
        get
        {
            var smallCaves = Path.Split("-").Where(c => c.ToLower() == c).ToArray();
            List<string> multipleSmallCaves = new List<string>();
            foreach (var sc in smallCaves)
            {

                if (multipleSmallCaves.Contains(sc))
                {
                    return true;
                }
                else
                {
                    multipleSmallCaves.Add(sc);
                }
            }
            return false;

        }
    }
}


public class Cave
{
    public string Name { get; set; }
    public bool Visited { get; set; }
    public int VisitCount { get; set; }
    public List<string> relatedCaves;
    public bool Small { get; private set; }

    public Cave(string name, string related)
    {
        Name = name;
        Visited = false;
        VisitCount = 0;
        Small = name.ToLower() == name;
        relatedCaves = new List<string>();
        relatedCaves.Add(related);
    }
}