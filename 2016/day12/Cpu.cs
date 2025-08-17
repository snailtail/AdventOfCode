

using System.ComponentModel.DataAnnotations;

public class Cpu
{
    public Dictionary<string, int> Registers = new();
    string[] Program;
    public Cpu()
    {
        Reset();
    }

    private void Reset()
    {
        Registers["a"] = 0;
        Registers["b"] = 0;
        Registers["c"] = 0;
        Registers["d"] = 0;
        //Registers["1"]=1;
    }

    public void Load(string[] program)
    {
        Reset();
        Program=program;
    }

    public void Run()
    {
        int ProgramPointer=0;
        while(ProgramPointer < Program.Length)
        {

            string[] commandParts = Program[ProgramPointer].Split(" ");
            switch (commandParts[0])
            {
                case "cpy":
                    int value;
                    if(char.IsLetter(commandParts[1][0]))
                    {
                        value = Registers[commandParts[1]];
                    }
                    else
                    {
                        value = int.Parse(commandParts[1]);
                    }

                    Registers[commandParts[2]]=value;
                    ProgramPointer++;
                    break;
                case "inc":
                    Registers[commandParts[1]]++;
                    ProgramPointer++;
                    break;
                case "dec":
                    Registers[commandParts[1]]--;
                    ProgramPointer++;
                    break;
                case "jnz":
                    int check;
                    if(int.TryParse(commandParts[1], out check))
                    {
                        if(check!=0)
                        {
                            ProgramPointer+=int.Parse(commandParts[2]);
                        }
                        else
                        {
                            ProgramPointer++;
                        }
                    }
                    else
                    {
                        if(Registers[commandParts[1]]!=0)
                        {
                            ProgramPointer+=int.Parse(commandParts[2]);
                        }
                        else
                        {
                            ProgramPointer++;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

