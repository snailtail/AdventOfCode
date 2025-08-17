using System;
using Xunit;
using AoC2017_16;
using Shouldly;

namespace AoC2017_16Tests
{
    public class Tests
    {
        [Fact]
        public void Step1()
        {
            //Set up the test string
            PermutationPromenade.programs="abcde";

            //Test the Character array generation
            PermutationPromenade.programCharArray.ShouldBe(new char[] {'a','b','c','d','e'});
            
            // Test Spin method
            string spin1result = "eabcd";
            PermutationPromenade.Spin(1);
            PermutationPromenade.programs.ShouldBe(spin1result);
            
            // Test Exchange method
            string exchangeResult = "eabdc";
            PermutationPromenade.Exchange(3,4);
            PermutationPromenade.programs.ShouldBe(exchangeResult);
            
            // Test Partner method
            string partnerResult = "baedc";
            PermutationPromenade.Partner('e','b');
            PermutationPromenade.programs.ShouldBe(partnerResult);
        }
    }
}
