using System.Text.RegularExpressions;

public class ElfMapper
{
    public List<MapperRange> MappedRanges = new();
    public long GetDestination(long number)
    {

        foreach (MapperRange mr in MappedRanges)
        {
            if (mr.IsWithinDefinedSourceRange(number))
            {
                long destination = number - mr.SourceStart + mr.DestinationStart;
                return destination;
            }
        }
        return number;
    }

    public long GetSourceFromDestination(long number)
    {

        foreach (MapperRange mr in MappedRanges)
        {
            if (mr.IsWithinDefinedDestinationRange(number))
            {
                long source = number + mr.SourceStart - mr.DestinationStart;
                return source;
            }
        }
        return number;
    }
   

    public ElfMapper(string[] input)
    {
        
        string pattern = @"^(\d+)\s(\d+)\s(\d+)$";
        foreach (string range in input)
        {
            MatchCollection matches = Regex.Matches(range, pattern);
            foreach (Match m in matches)
            {
                MapperRange mr = new();
                mr.DestinationStart = long.Parse(m.Groups[1].Value);
                mr.SourceStart = long.Parse(m.Groups[2].Value);
                mr.RangeLength = long.Parse(m.Groups[3].Value);
                MappedRanges.Add(mr);
            }
        }
    }

}
