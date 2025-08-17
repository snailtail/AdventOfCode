namespace AdventOfCode.TwentySixteen.Day02
{
    public class Map
    {
        public int AtX { get; set; }
        public int AtY { get; set; }
        
        private int _xSize {get; set;}
        private int _ySize { get; set; }

        /// <summary>
        /// MapPoints is a 2-dimensional map, consisting of Chars at each coordinate.
        /// In this project, a coordinate containing a '!' is treated as a wall/border, that cannot be crossed or moved into.
        /// </summary>
        public char[,] MapPoints;

        public Map(int XSize, int YSize)
        {
            _xSize=XSize;
            _ySize=YSize;
            MapPoints = new char[_xSize,_ySize];
        }

        /// <summary>
        /// Prints the contents of the Map to the console,
        /// In rows, starting from the top left map[min(x), max(y)]
        /// </summary>
        public void PrintMap()
        {
            for(int y = _ySize-1; y >=0; y--)
            {
                for(int x = 0; x <_xSize; x++)
                {
                    System.Console.Write(MapPoints[x,y].ToString());
                }
                System.Console.Write(System.Environment.NewLine);
            }
        }

        public char GetMapPointData(int X, int Y)
        {
            return MapPoints[X,Y];
        }
        public void GoToPos(int PosX, int PosY)
        {
            if(PosX <=_xSize && PosX >=0)
            {
                AtX=PosX;
            }
            else{
                throw new System.ArgumentException("X position is outside the boundaries of this map!");
            }

            if(PosY <=_ySize && PosY >=0)
            {
                AtY=PosY;
            }
            else{
                throw new System.ArgumentException("X position is outside the boundaries of this map!");
            }
        }

        public void Move(char Direction)
        {
            switch (Direction)
            {
                case 'L':
                    if(AtX>0 && MapPoints[AtX-1,AtY]!='!')
                    {
                        AtX-=1;
                    }
                    break;
                case 'R':
                    if(AtX<_xSize-1 && MapPoints[AtX+1,AtY]!='!')
                    {
                        AtX+=1;
                    }
                    break;
                case 'U':
                    if(AtY<_ySize-1 && MapPoints[AtX,AtY+1]!='!')
                    {
                        AtY+=1;
                    }
                    break;
                case 'D':
                    if(AtY>0 && MapPoints[AtX,AtY-1]!='!')
                    {
                        AtY-=1;
                    }
                    break;
                default:
                    break;
            }
        }
    }    
}