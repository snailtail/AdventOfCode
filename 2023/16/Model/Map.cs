// See https://aka.ms/new-console-template for more information
// en beam har start o currentpos.
// den har direction som är -1,-1 till 1,1 (0,-1) (0,0) osv.
// när den träffar nåt som böjer den eller splittar den så stannar den och en eller två nya skapas därifrån
// stannad har movement 0,0

using System.ComponentModel.DataAnnotations;

public class Map
{
    public List<Beam> Beams = new();
    public char[,] MapData;
    public int MapWidth;
    public int MapHeight;
    public HashSet<(int,int)> CoordinatesWithBeam = new();
    public Map(string[] mapData, int initialY=0, int initialX=0, int initialVelY=0,int initialVelX=1)
    {
        MapHeight = mapData.Length;
        MapWidth = mapData[0].Length;
        MapData = new char[MapHeight, MapWidth];
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                MapData[y, x] = mapData[y][x];
            }
        }
        var initialBeam = new Beam(initialY, initialX, initialVelY, initialVelX);
        Beams.Add(initialBeam);
        // add starting position so we don't forget about it :D
        CoordinatesWithBeam.Add((initialY, initialX));
    }

    public int Run()
    {
       
            int samecount=0;
            int prevloop=ExtendBeams();
            while(true)
            {
                int nextloop = ExtendBeams();
                if(nextloop==prevloop)
                {
                    samecount++;
                    //PrintMap();
                }
                else
                {
                    samecount=0;
                }

                if(samecount>5 && nextloop==prevloop)
                {
                    //PrintMap();
                    return nextloop;
                }
                prevloop=nextloop;

            }
        

    }
    public int ExtendBeams()
    {
        Beams = Beams.Where(b=>!b.IsStopped()).ToList();

        for(int i = 0; i < Beams.Count; i ++)
        {
            //kolla vad vi har i gridden vi står i
            //beroende på om det är en tom . eller om det är nåt som vinklar eller splittar
            //ska vi sen beroende på velocity åt olika håll välja vad som händer
            //vid "collision".
            //tänk på att beam kan bara ha fem directions:
            // 0,0 = står still
            // 1,0 = neråt
            // -1,0 = uppåt
            // 0,1 = höger
            // 0,-1 = vänster
            int y = Beams[i].curPos.Y;
            int x = Beams[i].curPos.X;

            //save the position for this beam in this grid.
            CoordinatesWithBeam.Add((y, x));

            // check if we collide with mirror or splitter
            var curChar = MapData[y, x];
            if (curChar != '.')
            {
                Collision(Beams[i], curChar);
            }
            else
            {
                MoveBeam(Beams[i]);
            }
        }

        // check all edge beams and if they are not on a collision course - set their velocity to 0
        for(int i = 0; i < Beams.Count; i++)
        {
            if((MapData[Beams[i].curPos.Y,Beams[i].curPos.X]=='.' || MapData[Beams[i].curPos.Y,Beams[i].curPos.X]=='|') && (Beams[i].Direction.yVelocity!=0 && (Beams[i].curPos.Y == 0 || Beams[i].curPos.Y == MapHeight-1)))
            {
                Beams[i].Stop();
            }
            if((MapData[Beams[i].curPos.Y,Beams[i].curPos.X]=='.' || MapData[Beams[i].curPos.Y,Beams[i].curPos.X]=='-') && (Beams[i].Direction.xVelocity!=0 && (Beams[i].curPos.X == 0 || Beams[i].curPos.X == MapWidth-1)))
            {
                Beams[i].Stop();
            }
        }

        // calculate enegrylevels
        return CoordinatesWithBeam.Count;
    }

    private void Collision(Beam b, char curChar)
    {
        switch (curChar)
        {
            case '/':
                if (b.Direction.xVelocity == 1)
                {
                    // Colliding while going RIGHT
                    // Add new beam from the mirror position going up.
                    CollisionAction(b, -1, 0);
                    break;
                }
                if (b.Direction.xVelocity == -1)
                {
                    // Colliding while going LEFT
                    // Add new beam from the mirror position going down.
                    CollisionAction(b, 1, 0);
                    break;
                }
                if (b.Direction.yVelocity == 1)
                {
                    // Colliding while going DOWN
                    // Add new beam from the mirror position going left.
                    CollisionAction(b, 0, -1);
                    break;
                }
                if (b.Direction.yVelocity == -1)
                {
                    // Colliding while going UP
                    // Add new beam from the mirror position going right.
                    CollisionAction(b, 0, 1);
                    break;
                }
                break;

            case '\\':
                if (b.Direction.xVelocity == 1)
                {
                    // Colliding while going RIGHT
                    // Add new beam from the mirror position going down.
                    CollisionAction(b, 1, 0);
                    break;
                }
                if (b.Direction.xVelocity == -1)
                {
                    // Colliding while going LEFT
                    // Add new beam from the mirror position going up.
                    CollisionAction(b, -1, 0);
                    break;
                }
                if (b.Direction.yVelocity == 1)
                {
                    // Colliding while going DOWN
                    // Add new beam from the mirror position going right.
                    CollisionAction(b, 0, 1);
                    break;
                }
                if (b.Direction.yVelocity == -1)
                {
                    // Colliding while going UP
                    // Add new beam from the mirror position going left.
                    CollisionAction(b, 0, -1);
                    break;
                }
                break;

            case '|':
                // doesn't matter if we're going left or right, the outcome will be the same
                if(b.Direction.xVelocity!=0)
                {
                    // Add new beam from the mirror position going down.
                    CollisionAction(b, 1, 0);
                    // Add new beam from the mirror position going up.
                    CollisionAction(b, -1, 0);
                }
                else if(b.Direction.yVelocity!=0)
                {
                    MoveBeam(b);
                }
                break;

            case '-':
                // doesn't matter if we're going up or down, the outcome will be the same
                if(b.Direction.yVelocity!=0)
                {
                    // Add new beam from the mirror position going right.
                    CollisionAction(b, 0, 1);
                    // Add new beam from the mirror position going left.
                    CollisionAction(b, 0, -1);
                }
                else if(b.Direction.xVelocity!=0)
                {
                    MoveBeam(b);
                }
                break;

            default:
                break;
        };
    }

    private void MoveBeam(Beam b)
    {
        if( (b.curPos.Y > 0 && b.Direction.yVelocity==-1) || (b.curPos.Y <MapHeight-1 && b.Direction.yVelocity==1) )
        {
            b.curPos.Y+=b.Direction.yVelocity;
            CoordinatesWithBeam.Add((b.curPos.Y, b.curPos.X));
            return;
        }

        if((b.curPos.X > 0 && b.Direction.xVelocity==-1) || (b.curPos.X<MapWidth-1 && b.Direction.xVelocity==1))
        {
            b.curPos.X+=b.Direction.xVelocity;
            CoordinatesWithBeam.Add((b.curPos.Y, b.curPos.X));
            return;
        }

        //stop up-down movement if we have hit an edge.
        if((b.curPos.Y==0 && b.Direction.yVelocity==-1) || (b.curPos.Y==MapHeight-1 && b.Direction.yVelocity==1))
        {
            b.Stop();
        }

        //stop left-right movement if we have hit an edge.
        if((b.curPos.X==0 && b.Direction.xVelocity==-1) ||(b.curPos.X == MapWidth-1 && b.Direction.xVelocity==1))
        {
            b.Stop();
        }
        CoordinatesWithBeam.Add((b.curPos.Y, b.curPos.X));
        //PrintMap();
    }

    public void PrintMap()
    {
        for(int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                char c = CoordinatesWithBeam.Contains((y,x)) ? '#' : MapData[y,x];
                System.Console.Write(c);
            }
            System.Console.Write("\n");
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
    }

    private void CollisionAction(Beam b, int newYVelocity, int newXVelocity)
    {
        b.Stop();
        var newBeam = new Beam(b.curPos.Y, b.curPos.X, newYVelocity, newXVelocity);
        Beams.Add(newBeam);
        MoveBeam(newBeam);
    }

}
