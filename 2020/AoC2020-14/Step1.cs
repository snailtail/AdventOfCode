using System.Collections.Generic;

namespace AdventOfCode.TwentyTwenty.Day14
{
    public class Step1
    {
        public Dictionary<long,Memoryaddress> Memory = new Dictionary<long, Memoryaddress>();
        public Mask activeMask = new Mask();
        public long Compute(string[] inputData)
        {
            foreach(var instruction in inputData)
            {
                var result=ReadInstruction(instruction);
                if(!result)
                {
                    throw new System.ArgumentException($"Could not perform Read of instruction: {instruction}");
                }
            }
            long Sum=0;
            foreach(KeyValuePair<long, Memoryaddress> kv in Memory)
            {
                Sum += activeMask.ConvertBinaryStringToLong(kv.Value.Data);
            }

            return Sum;
        }

        private bool ReadInstruction(string Instruction)
        {
            var status=true;
            if(Instruction.Substring(0,4).ToLower()=="mask"){
                SetMask(Instruction);
            }
            else if(Instruction.Substring(0,3).ToLower()=="mem")
            {
                long addressNum=long.Parse(Instruction.Split('[')[1].Split(']')[0]);
                
                // use the active mask and apply it to the data before we store it to memory
                long newMemData=long.Parse(Instruction.Split(" = ", System.StringSplitOptions.None)[1]);
                // convert the long to a binary string, before applying mask.
                string binaryMemData = activeMask.ConvertLongToBinaryString(newMemData, 36);
                char[] memData = activeMask.ApplyMask(binaryMemData.ToCharArray(), activeMask.Data);

                WriteMemoryAddress(addressNum, memData);
            }
            else
            {
                status=false;
            }
            
            return status;
        }

        private void SetMask(string MaskInstruction)
        {
            string[] newMask=MaskInstruction.Split(" = ");
            activeMask.Data=newMask[1].ToCharArray();
        }

        private void WriteMemoryAddress(long addressnum, char[] memdata)
        {
            if(Memory.ContainsKey(addressnum))
            {
                Memory[addressnum].Data=memdata;
            }
            else
            {
                Memory.Add(addressnum, new Memoryaddress(memdata));
            }
        }
        
        
    }
}