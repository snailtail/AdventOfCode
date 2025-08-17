namespace AdventOfCode;

public static class Day13
{
    private static List<FoldInstruction> foldInstructions = new();
    private static Sheet oSheet = new();

    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();

        ProcessInput(lines);


    }

    private static void ProcessInput(string[] lines)
    {
        foreach (string line in lines)
        {
            if (line.Length > 11 && line.Substring(0, 4) == "fold")
            {
                string direction = line[11..].Split("=")[0];
                int position = int.Parse(line[11..].Split("=")[1]);
                foldInstructions.Add(new FoldInstruction(direction, position));
            }
            else
            {
                var numbers = line.Split(',').Select(Int32.Parse).ToArray();
                oSheet.Dots.Add(new Dot(numbers[0], numbers[1]));
            }
        }
        Console.WriteLine($"Set up sheet with Width: {oSheet.Width} and Height: {oSheet.Height}");
        // Step 1: After first fold instruction.
        oSheet.FoldSheet(foldInstructions[0].Direction, foldInstructions[0].Position);
        Console.WriteLine($"Step 1: {oSheet.DotCount}");

        // Step 2: Keep folding and get the characters that form by the dots on the transparent paper.. :D
        for (int i = 1; i < foldInstructions.Count; i++)
        {
            oSheet.FoldSheet(foldInstructions[i].Direction, foldInstructions[i].Position);
        }
        //Print the sheet. This could be processed by something and interpreted if you want to be snazzy.
        Console.WriteLine("Step 2:");
        oSheet.Print();

    }
}
public record Dot(int X, int Y);

public class Sheet
{
    public List<Dot> Dots;
    public int Width => Dots.MaxBy(d => d.X).X + 1;
    public int Height => Dots.MaxBy(d => d.Y).Y + 1;

    public int DotCount => Dots.Count();

    public Sheet()
    {
        Dots = new List<Dot>();
    }

    public void FoldSheet(string Direction, int Position)
    {
        if (Direction == "y")
        {
            // Fold horizontally
            
            int yDiff = 2;
            var removeDots = Dots.Where(d => d.Y == Position);
            foreach (Dot dot in removeDots)
            {
                Dots.Remove(dot);
            }
            for (int iY = Position + 1; iY < Height; iY++)
            {
                foreach (var dot in Dots.Where(d => d.Y == iY).ToArray())
                {

                    Dot newDot = new Dot(dot.X, (dot.Y - yDiff));
                    Dots.Remove(dot);
                    if (Dots.Contains(newDot))
                    {
                        //Dot already exists, we don't need this new/moved one.
                    }
                    else
                    {
                        //Dot does not exist, place it in its new location on the folded paper
                        Dots.Add(newDot);
                    }
                }
                yDiff += 2;
            }
        }
        else if (Direction == "x")
        {
            //Fold vertically
            
            int xDiff = 2;
            var removeDots = Dots.Where(d => d.X == Position);
            foreach (Dot dot in removeDots)
            {
                Dots.Remove(dot);
            }
            for (int iX = Position + 1; iX < Width; iX++)
            {
                foreach (var dot in Dots.Where(d => d.X == iX).ToArray())
                {
                    Dot newDot = new Dot((dot.X - xDiff), dot.Y);
                    Dots.Remove(dot);
                    if (Dots.Contains(newDot))
                    {
                        //Dot already exists, we don't need this new/moved one.
                    }
                    else
                    {
                        //Dot does not exist, place it in its new location on the folded paper
                        Dots.Add(newDot);
                    }
                }
                xDiff += 2;
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("Printout of sheet:");
        Console.WriteLine();
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write(Dots.Any(d => d.X == x && d.Y == y) ? "#" : " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

public class FoldInstruction
{
    public string Direction { get; set; }
    public int Position { get; set; }

    public FoldInstruction(string direction, int position)
    {
        Direction = direction;
        Position = position;
    }
}