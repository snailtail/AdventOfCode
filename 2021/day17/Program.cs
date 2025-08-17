string[] targetareadata = File.ReadAllText("input.txt")[13..].Split(", ");
int maxYVelocity = int.MinValue;
int MaxY = int.MinValue;
Dictionary<string, bool> ValidVelocitySetups = new();
var targetArea = new Area(targetareadata);
Console.WriteLine(targetareadata[0]);
Console.WriteLine(targetareadata[1]);
Console.WriteLine($"{targetArea.x1}, {targetArea.x2}, {targetArea.y1}, {targetArea.y2}");



for (int x = 1; x < 512; x++)
{
    for (int y = 512; y > -512; y--)
    {
        var myProbe = new Probe(x, y);
        while (!passedTargetArea(myProbe))
        {
            myProbe.MoveStep();
            //Console.WriteLine("Moved 1 step");
            if (inTargetArea(myProbe))
            {
                break;
            }
        }
        if (inTargetArea(myProbe))
        {
            ValidVelocitySetups.TryAdd($"{myProbe.initialVelocityX},{myProbe.initialVelocityY}",true);
            if (myProbe.initialVelocityY > maxYVelocity)
            {
                maxYVelocity = myProbe.initialVelocityY;
                MaxY = myProbe.MaxY;
            }
        }
    }
}
Console.WriteLine($"Max Initial Velocity Y: {maxYVelocity}. Max Y reached in this trajectory: {MaxY}");
Console.WriteLine($"Step 2: Number of valid setup velocities: {ValidVelocitySetups.Count}");


bool inTargetArea(Probe probe)
{
    int x = probe.X;
    int y = probe.Y;
    if (x >= targetArea.x1 && x <= targetArea.x2 && y >= targetArea.y1 && y <= targetArea.y2)
    {
        return true;
    }
    return false;
}

bool passedTargetArea(Probe probe)
{
    //> x2 eller mindre än y1
    if ((probe.X > targetArea.x2) || (probe.Y < targetArea.y1))
    {
        return true;
    }
    else
    {
        return false;
    }

}


public class Area
{
    public int x1 { get; private set; }
    public int x2 { get; private set; }
    public int y1 { get; private set; }
    public int y2 { get; private set; }


    public Area(string[] AreaData)
    {
        var xdata = AreaData[0][2..];
        x1 = int.Parse(xdata.Split("..")[0]);
        x2 = int.Parse(xdata.Split("..")[1]);
        var ydata = AreaData[1][2..];
        y1 = int.Parse(ydata.Split("..")[0]);
        y2 = int.Parse(ydata.Split("..")[1]);
    }
}

public class Probe
{
    public int X { get; set; }
    public int Y { get; set; }
    public int VelocityX { get; set; }
    public int VelocityY { get; set; }
    public int initialVelocityX { get; private set; }
    public int initialVelocityY { get; private set; }
    public int MaxY { get; set; }
    public Probe(int velocityX, int velocityY)
    {
        VelocityX = velocityX;
        VelocityY = velocityY;
        initialVelocityX = velocityX;
        initialVelocityY = velocityY;
        X = 0;
        Y = 0;
        MaxY = 0;
    }
    public void MoveStep()
    {
        /*
        The probe's x,y position starts at 0,0. Then, it will follow some trajectory by moving in steps. On each step, these changes occur in the following order:
        The probe's x position increases by its x velocity.
        The probe's y position increases by its y velocity.
        Due to drag, the probe's x velocity changes by 1 toward the value 0; that is, it decreases by 1 if it is greater than 0, increases by 1 if it is less than 0, or does not change if it is already 0.
        Due to gravity, the probe's y velocity decreases by 1. 
        */
        X += VelocityX;
        Y += VelocityY;
        if (VelocityX < 0)
        {
            VelocityX++;
        }
        else if (VelocityX > 0)
        {
            VelocityX--;
        }

        VelocityY--;
        if (Y > MaxY)
        {
            MaxY = Y;
        }
    }
    public void MoveStep(int Count)
    {
        for (int n = 0; n < Count; n++)
        {
            MoveStep();
        }
    }
}