using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day08
{
    class Program
    {
        static long accumulator = 0;
        static int lastInstructionpos = 0;
        static Instruction lastInstruction;
        static List<Instruction> Software = new List<Instruction>();
        static void Main(string[] args)
        {

            string[] arrInstructions = File.ReadAllLines("input.txt");
            LoadSoftware(arrInstructions);
            // For Step1
            RunSoftware();
            System.Console.WriteLine($"Accumulator is: {accumulator}");
            System.Console.WriteLine($"Last instruction position was: {lastInstructionpos}");
            System.Console.WriteLine($"Last instruction definition was: {lastInstruction.code.command} {lastInstruction.code.direction}{lastInstruction.code.value}");

            // For Step2
            var finalCodePos = Software.Count - 1;
            System.Console.WriteLine($"DEBUG finalCodePos={finalCodePos}");
            for (int n = finalCodePos; n >= 0; n--)
            {
                System.Console.WriteLine($"DEBUG n={n}");
                var oldcommand = Software[n].code.command;
                //System.Console.WriteLine($"DEBUG command={oldcommand}");
                if (oldcommand == "acc")
                {
                }
                else if (oldcommand == "jmp")
                {
                    Software[n].code.command = "nop";
                    ResetExecCount();
                    RunSoftware();
                }
                else if (oldcommand == "nop")
                {
                    Software[n].code.command = "jmp";
                    ResetExecCount();
                    RunSoftware();
                }
                else
                {
                    System.Console.WriteLine("This should not happen!");
                }
                //System.Console.WriteLine($"DEBUG lastpos={lastInstructionpos}");
                if (lastInstructionpos == Software.Count - 1)
                {
                    System.Console.WriteLine($"Step 2 accumulator: {accumulator}");
                    break;
                }
                else
                {
                    Software[n].code.command = oldcommand;
                }
            }


        }

        static void LoadSoftware(string[] Instructions)
        {
            //Load the software from text instructions
            foreach (var instr in Instructions)
            {
                var myInstruction = new Instruction();
                myInstruction.ParseInstructionString(instr);
                Software.Add(myInstruction);
                //System.Console.WriteLine($"Command: {myInstruction.code.command}\tDirection: {myInstruction.code.direction}\tValue: {myInstruction.code.value}\tExecs: {myInstruction.execs}");
            }
            System.Console.WriteLine("Software Loaded...");




        }

        static void RunSoftware()
        {
            System.Console.WriteLine($"DEBUG: Running software...");
            accumulator = 0;
            var n = 0;
            var nextInstruction = Software[n];
            while (nextInstruction.execs == 0 && n < Software.Count)
            {
                Software[n].execs++;
                lastInstructionpos = n;
                lastInstruction = Software[n];
                switch (Software[n].code.command)
                {
                    case "acc":
                        if (Software[n].code.direction == '+')
                        {
                            accumulator += Software[n].code.value;
                        }
                        else if (Software[n].code.direction == '-')
                        {
                            accumulator -= Software[n].code.value;
                        }
                        else
                        {
                            System.Console.WriteLine($"Unknown direction {Software[n].code.direction}");
                        }
                        n++;
                        break;
                    case "jmp":
                        if (Software[n].code.direction == '+')
                        {
                            n += Software[n].code.value;
                        }
                        else if (Software[n].code.direction == '-')
                        {
                            n -= Software[n].code.value;
                        }
                        else
                        {
                            System.Console.WriteLine($"Unknown direction {Software[n].code.direction}");
                        }
                        break;
                    case "nop":
                        n++;
                        break;
                    default:
                        break;
                }

                if (n < Software.Count)
                    nextInstruction = Software[n];
            }



            /**
            var usedInstructions = Software.Where(s => s.execs>0).ToList();
            foreach(var instr in usedInstructions)
            {
                System.Console.WriteLine($"{instr.code.command} {instr.code.direction}{instr.code.value}");
            }
            **/

        }

        private static void ResetExecCount()
        {
            for (int zz = 0; zz < Software.Count - 1; zz++)
            {
                Software[zz].execs = 0;
            }
        }

    }

    public class Instruction
    {
        public Code code { get; set; }
        public int execs { get; set; }
        public void ParseInstructionString(string InstructionString)
        {
            var arrSplit = InstructionString.Split(' ');
            code = new Code { command = arrSplit[0], direction = arrSplit[1].Substring(0, 1).ToCharArray()[0], value = int.Parse(arrSplit[1].Substring(1)) };
            execs = 0;
        }

    }

    public class Code
    {
        public string command { get; set; }

        public char direction { get; set; }

        public int value { get; set; }

    }
}
