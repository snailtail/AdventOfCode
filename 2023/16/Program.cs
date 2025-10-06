
var mapdata = File.ReadAllLines("../data/16.dat");
Map m = new(mapdata);
var result = m.Run();
System.Console.WriteLine($"Part 1: {result}");

int topRow=0;
int bottomRow=0;
int leftCol=0;
int rightCol=0;
int total = 0;
for(int x =0; x < m.MapWidth; x++)
{
    var topRowRun = new Map(mapdata,0,x,1,0).Run();
    topRow=Math.Max(topRowRun,topRow);
    var bottomRowRun = new Map(mapdata,m.MapHeight-1,x,-1,0).Run();
    bottomRow=Math.Max(bottomRowRun,bottomRow);
    
    var leftColRun = new Map(mapdata,x,0,0,1).Run();
    leftCol=Math.Max(leftColRun,leftCol);

    var rightColRun = new Map(mapdata,m.MapWidth-1,0,0,-1).Run();
    rightCol=Math.Max(rightColRun,rightCol);
    int rowMax = Math.Max(topRow,bottomRow);
    int colMax = Math.Max(leftCol,rightCol);
    int thistotal = Math.Max(rowMax,colMax);
    total = Math.Max(total,thistotal);
}
    Console.WriteLine($"Part 2 result: {total}");
