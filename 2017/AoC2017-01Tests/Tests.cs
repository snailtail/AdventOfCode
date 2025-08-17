using System;
using Xunit;
using Shouldly;
using AoC2017;

namespace AoC201701Tests
{
    public class Step1
    {

        /*
           1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.
           1111 produces 4 because each digit (all 1) matches the next.
           1234 produces 0 because no digit matches the next.
           91212129 produces 9 because the only digit that matches the next one is the last digit, 9.
       */
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        public void Sample(string numbers, int answer)
        {
            AoC201701.Step1(numbers).ShouldBe(answer);

        }
    }

    public class Step2
    {
        /*

            1212 produces 6: the list contains 4 items, and all four digits match the digit 2 items ahead.
            1221 produces 0, because every comparison is between a 1 and a 2.
            123425 produces 4, because both 2s match each other, but no other digit has a match.
            123123 produces 12.
            12131415 produces 4.

        */

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void Sample(string numbers, int answer)
        {
            AoC201701.Step2(numbers).ShouldBe(answer);

        }
    }
}
