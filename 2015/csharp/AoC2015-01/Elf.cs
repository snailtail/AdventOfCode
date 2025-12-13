using System;

namespace AdventOfCode.TwentyFifteen.Day01
{
    public class Elf
    {
        public int EnteredBasementAt = 0; //This is the index (1-based) where Santa first entered floor -1
        public Elf()
        {
            System.Console.WriteLine("Ho ho ho...");
        }

        public int ParseFloorInstructions(string Instructions)
        {
            int sum=0; // calculate the floor
            int pos=1; // the position in the array (Actually 1 higher than, but...)
            foreach(char cInt in Instructions)
            {
                sum+=CalculateInstruction(cInt);
                if(EnteredBasementAt == 0 && sum==-1)
                {
                    EnteredBasementAt=pos;
                }
                pos++;
            }
            return sum;
        }

        private int CalculateInstruction(char cInstruction)
        {
            if(cInstruction=='(')
                return 1;
            else if(cInstruction==')')
                return -1;
            else
                return 0;
        }
    }
}