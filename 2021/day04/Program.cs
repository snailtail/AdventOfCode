using System.IO;
namespace AdventOfCode
{
    public static class Day04
    {
        private static List<BingoBoard> BingoBoards = new List<BingoBoard>();
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Day 4 :)");
            string[] fileContents = File.ReadLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();
            int[] draws = fileContents.First().Split(",").Select(i => int.Parse(i)).ToArray();
            PlayBingo(fileContents, draws);
        }
        private static void PlayBingo(string[] fileContents, int[] draws)
        {
            for (int x = 5; x < fileContents.Length; x += 5)
            {
                var board = new BingoBoard();
                for (int y = 4; y >= 0; y--)
                {
                    board.AddRow(fileContents[x - y]);
                }

                BingoBoards.Add(board);
            }
            
            //Draw the numbers
            int n = 0;

            bool firstBingo = false;
            int step1Result = 0;
            int step2Result = 0;
            while ((numWithBingo() < BingoBoards.Count) && n < draws.Length)
            {
                foreach (var board in BingoBoards)
                {
                    if (!board.HasBingo)
                    {
                        board.DrawNumber(draws[n]);
                        if (board.HasBingo && firstBingo == false)
                        {
                            Console.WriteLine("First Bingo!");
                            firstBingo = true;
                            step1Result = board.unDrawnSum * draws[n];
                            Console.WriteLine($"Step 1 result: {step1Result}");
                        }
                        else if (board.HasBingo && numWithBingo() == BingoBoards.Count)
                        {
                            step2Result = board.unDrawnSum * draws[n];
                            Console.WriteLine("Last Bingo!");
                            Console.WriteLine($"Step 2 result: {step2Result}");
                        }
                    }
                }
                n++;
            }
        }

        private static int numWithBingo()
        {
            return BingoBoards.Where(bb => bb.HasBingo).Count();
        }
    }

    public class BingoNumber
    {
        public int Number { get; private set; }
        public bool Drawn { get; set; }
        public BingoNumber(int number, bool drawn = false)
        {
            Number = number;
            Drawn = drawn;
        }

    }

    public class BingoRow
    {
        public List<BingoNumber> Numbers  = new List<BingoNumber>();
        public bool HasBingo
        {
            get
            {
                return Numbers.Where(n => n.Drawn == true).Count() == 5;
            }
        }
        public int unDrawnSum
        {
            get
            {
                return Numbers.Where(n => n.Drawn == false).Sum(n => n.Number);
            }
        }

        public void DrawNumber(int number)
        {
            foreach (var n in Numbers)
            {
                if (n.Number == number)
                {
                    n.Drawn = true;
                }
            }
        }
        public BingoRow(string numberdata)
        {
            BingoNumber[] inputNumbers = numberdata.Split().Select(x => new BingoNumber(int.Parse(x), false)).ToArray();
            foreach(var n in inputNumbers)
            {
                Numbers.Add(n);
            }
        }

        public override string ToString()
        {
            string output = string.Empty;
            foreach (var bn in Numbers)
            {
                if (bn.Drawn == true)
                {
                    output += "*";
                }
                output += bn.Number + " ";
            }
            return output;
        }

    }

    public class BingoBoard
    {
        List<BingoRow> Rows = new List<BingoRow>();

        public void AddRow(string rowData)
        {
            rowData = rowData.Replace("  ", " ").Trim();
            Rows.Add(new BingoRow(rowData));
        }

        public void DrawNumber(int number)
        {
            foreach (var row in Rows)
            {
                row.DrawNumber(number);
            }
        }
        public bool HasBingo
        {
            get
            {
                for(int n =0; n< 5; n++)
                {
                    if(Rows.Where(br=> br.Numbers[n].Drawn).Count() ==5)
                    {
                        return true;
                    }
                }
                foreach (BingoRow br in Rows)
                {
                    if (br.HasBingo)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public override string ToString()
        {
            string output = string.Empty;
            foreach (var row in Rows)
            {
                output += row.ToString();
                output += Environment.NewLine;
            }
            output += $"(Undrawn sum: {unDrawnSum})" + Environment.NewLine;
            return output;
        }

        public int unDrawnSum
        {
            get
            {
                int sum = 0;
                foreach (BingoRow br in Rows)
                {
                    sum += br.unDrawnSum;
                }
                return sum;
            }
        }
    }
}