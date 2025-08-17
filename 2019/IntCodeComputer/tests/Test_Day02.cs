namespace Day02Tests;
using Shouldly;
public partial class IntCodeComputerTests
{
    [Theory]
    [InlineData(new int[]{1,0,0,0,99},new int[]{2,0,0,0,99})]
    [InlineData(new int[]{1,9,10,3,2,3,11,0,99,30,40,50},new int[]{3500,9,10,70,2,3,11,0,99,30,40,50})]
    [InlineData(new int[]{2,3,0,3,99},new int[]{2,3,0,6,99})]
    [InlineData(new int[]{2,4,4,5,99,0},new int[]{2,4,4,5,99,9801})]
    [InlineData(new int[]{1,1,1,4,99,5,6,0,99},new int[]{30,1,1,4,2,5,6,0,99})]
    public void Step1_TestInputs(int[] program, int[] expectedProgram)
    {
        var myCpu = new intCode.Computer(program);
        int result;
        bool success = myCpu.Run(out result);
        for(int i = 0; i < myCpu.Program.Length;i++)
        {
            myCpu.Program[i].ShouldBe(expectedProgram[i]);
        }
    }
    
    
    [Fact]
    public void Step1_RealInput()
    {
        int[] realInput=new int[]{1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,2,27,13,31,1,10,31,35,1,10,35,39,2,39,6,43,1,43,5,47,2,10,47,51,1,5,51,55,1,55,13,59,1,59,9,63,2,9,63,67,1,6,67,71,1,71,13,75,1,75,10,79,1,5,79,83,1,10,83,87,1,5,87,91,1,91,9,95,2,13,95,99,1,5,99,103,2,103,9,107,1,5,107,111,2,111,9,115,1,115,6,119,2,13,119,123,1,123,5,127,1,127,9,131,1,131,10,135,1,13,135,139,2,9,139,143,1,5,143,147,1,13,147,151,1,151,2,155,1,10,155,0,99,2,14,0,0};
        var myCpu = new intCode.Computer(realInput);
        myCpu.Noun=12;
        myCpu.Verb=2;
        int result;
        var success = myCpu.Run(out result);
        success.ShouldBeTrue();
        result.ShouldBe(4462686);
    }

}
