using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.TwentyNineteen.Day02
{
    class Day2
    {
        /**
        Take a string with "integer" separated by commas.
        Position 0 is opcode
        Position 1 is where to read input1 from
        Position 2 is where to read input2 from
        Position 3 is where to store results of operation

        Opcode 1 is add
        Opcode 2 is multiply
        Opcode 99 is halt immediately



        **/
        public int FinishedResult { get; set; }

        public Day2(string InputString, int x=-1, int y=-1)
        {
            
            var stringIntArr = InputString.Split(',');
            if (x > -1)
            {
                stringIntArr[1] = x.ToString();
            }
            if (y > -1)
            {
                stringIntArr[2] = y.ToString();
            }
            //Console.WriteLine($"Running with x={x}, y={y}");
            //Console.WriteLine("Number of positions in input: {0}", stringIntArr.Length);
            int op_pos = 0;
            for(op_pos=0;op_pos<= (stringIntArr.Length-5); op_pos+=4)
            {
                var opCode = int.Parse(stringIntArr[op_pos]);
                var result = 0;
                //Console.WriteLine("Position {0}: {1} {2} {3} {4}", op_pos+1, stringIntArr[op_pos], stringIntArr[op_pos+1], stringIntArr[op_pos+2], stringIntArr[op_pos+3]);
                if (opCode == 99)
                {
                    //Console.WriteLine("OPCODE 99 EXITING");
                    return;
                }
                else if(opCode==1)
                {
                    // Operation = add
                    //Console.WriteLine("OpCode 1, adding.");
                    var input1 = int.Parse(stringIntArr[int.Parse(stringIntArr[op_pos + 1])]);
                    var input2 = int.Parse(stringIntArr[int.Parse(stringIntArr[op_pos + 2])]);
                    result =  input1 + input2 ;
                }
                else if(opCode==2)
                {
                    //Console.WriteLine("OpCode 2, multiplying.");
                    var input1 = int.Parse(stringIntArr[int.Parse(stringIntArr[op_pos + 1])]);
                    var input2 = int.Parse(stringIntArr[int.Parse(stringIntArr[op_pos + 2])]);
                    result = input1 * input2;
                }
                else
                {
                    Console.WriteLine("Incorrect opcode {0}", opCode);
                    return;
                }
                var storePos = int.Parse(stringIntArr[op_pos + 3]);
                //Console.WriteLine("Trying to store result {0} in stringIntArr[{1}]", result.ToString(), stringIntArr[storePos]);
                
                stringIntArr[storePos] = result.ToString();
                //Console.WriteLine(stringIntArr[storePos]);
                //Console.WriteLine("***********************");
                FinishedResult = int.Parse(stringIntArr[0]);
            }
            

        }
    }
}
