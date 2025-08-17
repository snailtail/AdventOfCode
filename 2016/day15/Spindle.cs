public class Spindle
{
    public List<Disc>Discs = new();


    public void AddDisc(Disc disc)
    {
        Discs.Add(disc);
    }

    public void AddDisc(int id, int Size, int Position)
    {
        Disc nuu = new Disc(id,Size,Position);
        AddDisc(nuu);
    }

    private int TimeToOpenPosition
    {
        get {
            if(Discs[0].Position==0)
            {
                return 0;
            }
            
            return Discs[0].DiscSize-Discs[0].Position;
        }
    }

    
    private int interValToOpenPosition => Discs[0].DiscSize;

    private bool IsPathClear()
    {
        
    }

    public void SpinOneStep()
    {
        int SpindleAccelerator = 1; // since there will pass 1 time for reaching each disc, we need to spin each consecutive disc 1 more step than the previous one to see what will be the impact totally for passing through the entire stack.
        for(int n = 0; n< Discs.Count; n++)
        {
            Discs[n].Position+=SpindleAccelerator;
            if(Discs[n].Position >= Discs[n].DiscSize)
            {
                Discs[n].Position=0;
            }
            SpindleAccelerator++;
        }
    }
}