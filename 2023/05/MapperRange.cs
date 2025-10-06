public class MapperRange
{
    private long destinationStart;
    private long sourceStart;
    private long rangeLength;

    public long DestinationStart { get => destinationStart; set => destinationStart = value; }
    public long SourceStart { get => sourceStart; set => sourceStart = value; }
    public long RangeLength { get => rangeLength; set => rangeLength = value; }
    public bool IsWithinDefinedSourceRange(long number)
    {
        return (number >= SourceStart && number <= SourceStart + RangeLength);
    }

    public bool IsWithinDefinedDestinationRange(long number)
    {
        return (number >= DestinationStart && number <= DestinationStart + RangeLength);
    }
    
}