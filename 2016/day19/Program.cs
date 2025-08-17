

using System.Runtime.ExceptionServices;

Elf getElfGraph(int numberOfElves)
{
    Elf startElf = new Elf(1, null);
    Elf nextElf = new Elf(numberOfElves, startElf);


    for (int n = numberOfElves - 1; n > 1; n--)
    {
        Elf tmpElf = nextElf;
        nextElf = new Elf(n, tmpElf);
    }

    startElf.Next = nextElf;
    return startElf;
}



int numberOfElves = 3004953;
Elf step1Elf = getElfGraph(numberOfElves);
int Step1Answer = ProcessElfGraphStep1(step1Elf);

int ProcessElfGraphStep1(Elf currentElf)
{
    bool KeepRunning = true;
    while (KeepRunning)
    {
        currentElf.Value += currentElf.Next.Value;
        currentElf.Next.Value = 0;
        if(currentElf.Next.Next.Index==currentElf.Index)
        {
            Console.WriteLine("Here we are! One elf left with all the presents!");
            KeepRunning = false;
        
        }
        else
        {
        
        currentElf.Next = currentElf.Next.Next;
        //Console.WriteLine($"Looping through graph, currently at elf {currentElf.Index}");
        currentElf=currentElf.Next;
        }

    }
    return currentElf.Index;
}




Console.WriteLine($"Step 1: {Step1Answer}");


internal class Elf
{
    public int Index;
    public long Value;
    public Elf(int index, Elf? next)
    {
        Index=index;
        Value = 1;
        Next = next;
    }
    public Elf? Next;
}
