using Shouldly;

public class Day12Tests
{
    [Theory]
    [InlineData("???.### 1,1,3", new int[] { 1, 1, 3 })]
    [InlineData(".??..??...?##. 1,1,3", new int[] { 1, 1, 3 })]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", new int[] { 1, 3, 1, 6 })]
    [InlineData("????.#...#... 4,1,1", new int[] { 4, 1, 1 })]
    [InlineData("????.######..#####. 1,6,5", new int[] { 1, 6, 5 })]
    [InlineData("?###???????? 3,2,1", new int[] { 3, 2, 1 })]
    public void TestRecordData_RecordGroupSizes(string input, int[] expectedGroupSizes)
    {
        ConditionRecord cr = new ConditionRecord(input);
        for (int i = 0; i < expectedGroupSizes.Length; i++)
        {
            cr.GroupSizes[i].ShouldBe(expectedGroupSizes[i]);
        }
    }
}