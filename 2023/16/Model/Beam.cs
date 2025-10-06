// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

public class Beam
{
    public BeamDirection Direction;
    public Coordinate startPos;
    public Coordinate curPos;
    public bool CollisionHandled;
    
    public Beam(int StartYcoord, int StartXcoord, int yvelocity, int xvelocity)
    {
        startPos=new Coordinate(StartYcoord,StartXcoord);
        curPos = new Coordinate(StartYcoord,StartXcoord);
        Direction = new BeamDirection(yvelocity,xvelocity);
        CollisionHandled=false;
    }

    public bool IsStopped() => Direction.xVelocity==0 && Direction.yVelocity==0;
    public override string ToString()
    {
        return $"{startPos.Y}:{startPos.X}==>{curPos.Y}:{curPos.X} yVel={Direction.yVelocity}, xVel={Direction.xVelocity}";
    }
    public void Stop()
    {
        Direction.xVelocity=0;
        Direction.yVelocity=0;
    }

}