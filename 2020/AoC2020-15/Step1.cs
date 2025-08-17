using System.Collections.Generic;

namespace AdventOfCode.TwentyTwenty.Day15
{
    public class Step1
    {
        public List<string> HaveBeenSpoken = new List<string>();
        public int AtNumberIndex = 0;
        public int GoalIndex; // we run until we find the GoalIndex:th (-1) array index

        public string Compute(string[] numberArr)
        {
            System.Console.WriteLine($"OK.. Goal Index is: {GoalIndex}");
            // first we need to speak all the numbers in the list once.
            for(int n = 0; n<numberArr.Length; n++)
            {
                HaveBeenSpoken.Add(numberArr[n]);
                //System.Console.WriteLine($"Spoken (1st) {numberArr[n]}");
            }

            // start looking at the last index
            AtNumberIndex=HaveBeenSpoken.Count-1;

            while(AtNumberIndex<(GoalIndex-1))
            {
                // Added for Step 2 performancecheck.
                if(AtNumberIndex % 1000 ==0){
                    System.Console.WriteLine($"At Index {AtNumberIndex} of {GoalIndex-1}");
                }
                //
                var activeNumber=HaveBeenSpoken[AtNumberIndex];
                var numberOf= HaveBeenSpoken.FindAll(x => x==activeNumber).ToArray().Length;
                var numberToSpeak = string.Empty;
                if(numberOf>1){
                    //System.Console.WriteLine($"Hittade fler än 1 förekomst av {activeNumber}");
                    var lastFoundIndex=HaveBeenSpoken.GetRange(0,AtNumberIndex).FindLastIndex(x => x == activeNumber);
                    //System.Console.WriteLine($"Vi är på index: {AtNumberIndex}, senast uttalad index = {lastFoundIndex}");
                    numberToSpeak=(AtNumberIndex - lastFoundIndex).ToString();
                    //System.Console.WriteLine($"NumberToSpeak: {numberToSpeak}");

                }
                else
                {
                    numberToSpeak="0";
                }
                HaveBeenSpoken.Add(numberToSpeak);
                AtNumberIndex++;
            }
            //System.Console.WriteLine($"Stannade vid index {AtNumberIndex}");
            
            var returnvalue=HaveBeenSpoken[AtNumberIndex];
            return returnvalue;
        }
    
        
    }
}