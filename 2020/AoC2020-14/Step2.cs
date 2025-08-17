using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day14
{
    public class Step2
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
                
                // in step 2 we will use the mask for the memory address and not the data.
                long addressNum=long.Parse(Instruction.Split('[')[1].Split(']')[0]);
                long newMemData=long.Parse(Instruction.Split(" = ", System.StringSplitOptions.None)[1]);
                
                // we also need to convert the actual memory data to a binary string
                char[] binaryMemdata = activeMask.ConvertLongToBinaryString(newMemData,36).ToCharArray();
                var addressList=GetAddressesForMask(activeMask.Data, addressNum);
                foreach(var vAddress in addressList)
                {
                    WriteToMemory(binaryMemdata,vAddress);
                }
            }
            else
            {
                status=false;
            }
            
            return status;
        }
        public IEnumerable<long> GetAddressesForMask(char[] mask, long address) 
        {  
            var tails = mask[^1] switch {  
                'X' => new[] {0L, 1},
                '0' => new[] {address & 1},
                _ => new[] {1L}
            };
            return mask.Length == 1 
                ? tails 
                : tails.SelectMany(tail => 
                    GetAddressesForMask(mask[..^1], address >> 1).Select(head => head << 1 | tail)
                );
        }

        private void SetMask(string MaskInstruction)
        {
            string[] newMask=MaskInstruction.Split(" = ");
            activeMask.Data=newMask[1].ToCharArray();
        }

        private void WriteToMemory(char[] memorydata, long memoryaddress)
        {
            
            if(Memory.ContainsKey(memoryaddress))
            {
                Memory[memoryaddress].Data=memorydata;
            }
            else{
                var newAddr = new Memoryaddress();
                newAddr.Data = memorydata;
                Memory.Add(memoryaddress, newAddr);
            }
            
        }

        
        
        
    }
}