using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day21
{
    internal class Scrambler
    {

        public string Scramble(string input, string[] instructions)
        {
            char[] chars = input.ToCharArray();

            string rotateRightPattern = @"^rotate\\sright\\s([0-9]+)";
            string rotateLeftPattern = @"^rotate\sleft\s([0-9]+)";
            string rotateBasedPattern = @"^rotate\sbased\son\sposition\sof\sletter\s([a-z])";
            string swapPositionPattern = @"^swap\sposition\s([0-9]+).*position\s([0-9]+)";
            string swapLetterWithPattern = @"^swap\sletter\s([a-z])\swith\sletter\s([a-z])";
            string reversePositionsPattern = @"^reverse\spositions\s([0-9]+)\sthrough\s([0-9]+)";
            string movePositionXtoYPattern = @"^move\sposition\s([0-9]+)\sto\sposition\s([0-9]+)";
            foreach (string instruction in instructions)
            {
                Match match;
                match = Regex.Match(instruction,rotateRightPattern);
                if(match.Success)
                {
                    RotateInstruction rotateInstruction = new RotateInstruction();
                    rotateInstruction.Direction = RotateInstruction.RotateDirection.Right;
                    rotateInstruction.Steps = int.Parse(match.Groups[1].Value);
                    ExecuteInstruction(rotateInstruction);
                    continue;
                }

                match = Regex.Match(instruction, rotateLeftPattern);
                if (match.Success)
                {
                    RotateInstruction rotateInstruction = new RotateInstruction();
                    rotateInstruction.Direction = RotateInstruction.RotateDirection.Left;
                    rotateInstruction.Steps = int.Parse(match.Groups[1].Value);
                    ExecuteInstruction(rotateInstruction);
                    continue;
                }

                match = Regex.Match(instruction, rotateBasedPattern);
                if (match.Success)
                {
                    RotateInstruction rotateInstruction = new RotateInstruction();
                    rotateInstruction.Direction = RotateInstruction.RotateDirection.PositionBased;
                    rotateInstruction.Letter = match.Groups[1].Value[0];
                    ExecuteInstruction(rotateInstruction);
                    continue;
                }
            }

            return "empty...";



            
        }
        private void ExecuteInstruction(RotateInstruction rotateInstruction)
        {
            Console.WriteLine($"Rotateinstruction: {rotateInstruction.Direction.ToString()}, {rotateInstruction.Steps} steps.");
        }
    }

    internal class RotateInstruction
    {
        public enum RotateDirection
        {
            Left=0,
            Right=1,
            PositionBased=2
        }

        public RotateDirection Direction;
        public int Steps;
        public char? Letter;
        
    }

    internal class SwapInstruction
    {
        public enum SwapType
        {
            Positional=0,
            Letterbased=1
        }
    }

    internal class ReverseInstruction
    {
        public int X;
        public int Y;
    }

    internal class MoveInstruction
    {
        public int X;
        public int Y;
    }


    /*
     * 
        -swap position X with position Y means that the letters at indexes X and Y (counting from 0) should be swapped.
        -swap letter X with letter Y means that the letters X and Y should be swapped (regardless of where they appear in the string).
        -rotate left/right X steps means that the whole string should be rotated; for example, one right rotation would turn abcd into dabc.
        -rotate based on position of letter X means that the whole string should be rotated to the right based on the index of letter X (counting from 0) as determined before this instruction does any rotations. Once the index is determined, rotate the string to the right one time, plus a number of times equal to that index, plus one additional time if the index was at least 4.
        -reverse positions X through Y means that the span of letters at indexes X through Y (including the letters at X and Y) should be reversed in order.
        -move position X to position Y means that the letter which is at index X should be removed from the string, then inserted such that it ends up at index Y.
     * 
     * 
     * */
}
