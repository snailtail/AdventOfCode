namespace AdventOfCode.TwentyFifteen.Day06
{
    public class GridRange
    {
        public int xLow { get; set; }
        public int xHigh { get; set; }
        public int yLow { get; set; }
        public int yHigh { get; set; }

        public GridRange(string Instruction)
        {
            // we only care about the numbers here.
            //turn on 489,959 through 759,964
            string cleanedString = string.Empty;
            if(Instruction.StartsWith("turn on"))
            {
                cleanedString=Instruction.Substring(7,Instruction.Length-7).Trim();
            }
            else if(Instruction.StartsWith("turn off"))
            {
                cleanedString=Instruction.Substring(8,Instruction.Length-8).Trim();
            }
            else
            {
                cleanedString=Instruction.Substring(6,Instruction.Length-6).Trim();
            }
            string[] rangeStrings=cleanedString.Split(" through ", System.StringSplitOptions.None);
            int xlow=int.Parse(rangeStrings[0].Split(',')[0]);
            int xhigh=int.Parse(rangeStrings[1].Split(',')[0]);

            int ylow=int.Parse(rangeStrings[0].Split(',')[1]);
            int yhigh=int.Parse(rangeStrings[1].Split(',')[1]);
            this.xHigh=xhigh;
            this.xLow=xlow;
            this.yHigh=yhigh;
            this.yLow=ylow;
            //System.Console.WriteLine($"Cleaned String: '{cleanedString}'\t {xlow}:{ylow}-{xhigh}:{yhigh}");

        }
    }
}