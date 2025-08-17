using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyFifteen.Day06
{
    public class LightGrid
    {
        public int[,] Lights = new int[1000, 1000];
        private string[] arrInstructions;
        private const string Path = "input.txt";



        private void LoadInstructions(string _Path)
        {
            //turn on 489,959 through 759,964
            arrInstructions = File.ReadAllLines(_Path).Where(l => !string.IsNullOrEmpty(l)).ToArray();
        }


        private void ParseInstruction(string Instruction, bool Step2=false)
        {
            GridRange aGridRange = new GridRange(Instruction);

            if (Instruction.StartsWith("toggle"))
            {
                if(Step2)
                    Add(aGridRange,2);
                else
                    Toggle(aGridRange);
            }
            else if (Instruction.StartsWith("turn on"))
            {
                if(Step2)
                    Add(aGridRange,1);
                else
                    TurnOn(aGridRange);
            }
            else if (Instruction.StartsWith("turn off"))
            {
                if(Step2)
                    Add(aGridRange,-1);
                else
                    TurnOff(aGridRange);
            }
        }

        private void Set(GridRange theRange, int Value)
        {
            for (int x = theRange.xLow; x <= theRange.xHigh; x++)
            {
                for (int y = theRange.yLow; y <= theRange.yHigh; y++)
                {
                    Lights[x, y] = Value;
                }
            }
        }

        private void Toggle(GridRange theRange)
        {
            for (int x = theRange.xLow; x <= theRange.xHigh; x++)
            {
                for (int y = theRange.yLow; y <= theRange.yHigh; y++)
                {
                    if (Lights[x, y] == 1)
                    {
                        Lights[x, y] = 0;
                    }
                    else
                    {
                        Lights[x, y] = 1;
                    }
                }
            }
        }

        private void Add(GridRange theRange, int value)
        {
            for (int x = theRange.xLow; x <= theRange.xHigh; x++)
            {
                for (int y = theRange.yLow; y <= theRange.yHigh; y++)
                {
                    Lights[x, y] += value;
                    if(Lights[x, y]<0)
                    {
                        Lights[x, y]=0;
                    }
                }
            }
        }

        

        private void TurnOn(GridRange theRange)
        {
            Set(theRange,1);
        }

        private void TurnOff(GridRange theRange)
        {
            Set(theRange,0);
        }

        public int ComputeStep1()
        {
            int sum=0;
            LoadInstructions(Path);
            foreach (var line in arrInstructions)
            {
                ParseInstruction(line);
            }
            for(int y=0; y<1000; y++)
            {
                for(int x=0; x<1000; x++)
                {
                    if(Lights[x,y]==1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
        public int ComputeStep2()
        {
            int sum=0;
            ResetGrid();
            LoadInstructions(Path);
            foreach (var line in arrInstructions)
            {
                ParseInstruction(line, true);
            }
            for(int y=0; y<1000; y++)
            {
                for(int x=0; x<1000; x++)
                {
                    sum += Lights[x,y];
                }
            }
            return sum;
        }

        private void ResetGrid()
        {
            for(int y=0; y<1000; y++)
            {
                for(int x=0; x<1000; x++)
                {
                    Lights[x,y]=0;
                }
            }
        }






        #region Debugging
        public void DumpLightGrid()
        {
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    Console.Write(Lights[x, y]);
                }
                Console.Write('\n');
            }
        }
        #endregion
    }
}