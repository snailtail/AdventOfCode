using System;
using Xunit;
using Shouldly;
using AdventOfCode.TwentyTwenty.Day16;

namespace AdventOfCode.TwentyTwenty.Day16tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(true, new string[] {"class: 1-3 or 5-7","row: 6-11 or 33-44","seat: 13-40 or 45-50", "","your ticket:","7,1,14"})]
        [InlineData(false, new string[] {"class: 1-3 or 5-7","row: 6-11 or 33-44","seat: 13-40 or 45-50", "","your ticket:","7,1,51"})]
        [InlineData(true, new string[] {"class: 1-3 or 5-7","row: 6-11 or 33-44","seat: 13-40 or 45-50", "","your ticket:","7,1,33,7,1"})]
        public void Test_MyTicket_Step1(bool ExpectedResult, string[] myInput)
        {
            
            var firstStep = new TicketTranslation();
            firstStep.ExtractTicketFields(myInput);
            firstStep.LoadYourTicket(myInput);
            System.Console.WriteLine($"MyTicket is valid?: {firstStep.YourTicket.IsValid}");
        }
    }
}
