namespace UnitTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(@"""""", 2, 0)]
        [InlineData(@"""\"aaa\\\"aaa\"""",10,7)]
        public void ParseLine(string line, int source, int chars)
        {
            day08 day = new();
            (int _src, int _chrs) = day.ParseLine(line);
            _src.ShouldBe(source);
            _chrs.ShouldBe(chars);
        }
    }
}