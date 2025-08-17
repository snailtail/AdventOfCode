using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace AoC2017_08
{
    public static class AoC201708
    {
        public static string[] fileReader(string path)
        {
            string[] allLines = File.ReadAllLines(path).Where(l => !string.IsNullOrEmpty(l)).ToArray();
            return allLines;
        }

        
    }
    class Program
    {
        static Dictionary<string, int> registers = new Dictionary<string, int>();
        static List<Instruction> instructions = new List<Instruction>();
        static int highestValue = int.MinValue;
        static void Main(string[] args)
        {    
            var lines = AoC201708.fileReader("input.txt");
            Instruction instr;
            foreach(var line in lines)
            {
                instr = new Instruction(line);
                instructions.Add(instr);
                //Console.WriteLine(instr);
                processInstruction(instr);
            }
            int highValue = getHighValue();
            Console.WriteLine($"Step 1 -> Highest value in any register now: {highValue}");
            Console.WriteLine($"Step 2 -> Highest value in any register at any point: {highestValue}");

        }

        private static void processInstruction(Instruction instr)
        {
            bool checkCondition = false;

            switch (instr.CheckString)
            {
                case ">":
                    if (getRegisterValue(instr.CheckRegister) > instr.CheckValue) checkCondition = true;
                    break;
                case "<":
                    if (getRegisterValue(instr.CheckRegister) < instr.CheckValue) checkCondition = true;
                    break;
                case ">=":
                    if (getRegisterValue(instr.CheckRegister) >= instr.CheckValue) checkCondition = true;
                    break;
                case "<=":
                    if (getRegisterValue(instr.CheckRegister) <= instr.CheckValue) checkCondition = true;
                    break;
                case "==":
                    if (getRegisterValue(instr.CheckRegister) == instr.CheckValue) checkCondition = true;
                    break;
                case "!=":
                    if (getRegisterValue(instr.CheckRegister) != instr.CheckValue) checkCondition = true;
                    break;
            }
            //Console.WriteLine($"Conditions match: {checkCondition}");
            if (checkCondition)
            {
                modifyRegister(instr.Register, instr.Increase, instr.Amount);
                int highestNow = getHighValue();
                if(highestValue< highestNow) highestValue=highestNow;
            }
        }

        private static int getHighValue()
        {
            return registers.Values.Max();
        }

        private static void modifyRegister(string register, bool increase, int amount)
        {
            if(!registers.ContainsKey(register))
            {
                registers.Add(register,0);
            }

            if(increase)
            {
                registers[register]+=amount;
            }
            else
            {
                registers[register]-=amount;
            }
        }

        private static int getRegisterValue(string registerName)
        {
            if(registers.ContainsKey(registerName))
            {
                return registers[registerName];
            }
            else
            {
                registers.Add(registerName,0);
                return 0;
            }
        }
    }
}
