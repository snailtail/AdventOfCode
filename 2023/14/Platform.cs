
public class Platform
{
    private char[,] _coordinates;
    private Queue<(int, int)> _rocksToRoll = new();
    private int platformWidth;
    private int platformHeight;
    public char[,] Coordinates { get => _coordinates; }
    public Platform(string[] platformData)
    {
        platformWidth = platformData[0].Length;
        platformHeight = platformData.Length;
        _coordinates = new char[platformHeight, platformWidth];
        for (int y = 0; y < platformHeight; y++)
        {
            for (int x = 0; x < platformWidth; x++)
            {
                char theChar = platformData[y][x];
                _coordinates[y, x] = theChar;
            }
        }
    }
    public int Part1()
    {
        TiltNorth();
        return GetNorthSupportBeamsLoad();
    }

    public int Part2()
    {
        RunCycle();
        int lastLoad= GetNorthSupportBeamsLoad();

        for(int i = 1; i < 1_000_000_000; i++)
        {
            RunCycle();
            int load = GetNorthSupportBeamsLoad();
            if(load==lastLoad)
            {
                Console.WriteLine($"Repeating load ({lastLoad})on cycle: {i}");
            }
            lastLoad=load;
        }
        return GetNorthSupportBeamsLoad();
    }

    public void RunCycle()
    {
        TiltNorth();
        TiltWest();
        TiltSouth();
        TiltEast();
    }

    private void ScanForRollingRocksToMove()
    {
        for (int y = 0; y < platformHeight; y++)
        {
            for (int x = 0; x < platformWidth; x++)
            {
                char theChar = _coordinates[y,x];
                if (theChar == 'O')
                {
                    _rocksToRoll.Enqueue((y, x));
                }
            }
        }
    }
    private void ScanForRollingRocksToMoveInverted()
    {
        for (int y = platformHeight-1 ; y >= 0; y--)
        {
            for (int x = platformWidth-1; x >=0; x--)
            {
                char theChar = _coordinates[y,x];
                if (theChar == 'O')
                {
                    _rocksToRoll.Enqueue((y, x));
                }
            }
        }
    }

    public int GetNorthSupportBeamsLoad()
    {
        int sum = 0;
        for (int y = 0; y < platformHeight; y++)
        {
            int rowWeight = platformHeight - y;
            for (int x = 0; x < platformWidth; x++)
            {
                if (_coordinates[y, x] == 'O')
                {
                    sum += rowWeight;
                }
            }
        }
        return sum;
    }
    public void TiltNorth()
    {
        ScanForRollingRocksToMove();
        while (_rocksToRoll.Count > 0)
        {
            (int Y, int X) = _rocksToRoll.Dequeue();
            int orgY = Y;
            int orgX = X;
            bool hasMoved = false;
            while (true)
            {
                // if we hit the north edge of the platform
                if (Y == 0)
                    break;

                // if we hit a rock or a square rock directly north of us
                if (_coordinates[Y - 1, X] == '#' || _coordinates[Y - 1, X] == 'O')
                    break;
                Y--;
                hasMoved = true;
            }
            if (hasMoved)
            {
                _coordinates[Y, X] = 'O';
                _coordinates[orgY, orgX] = '.';
            }
        }
    }

    public void TiltSouth()
    {
        ScanForRollingRocksToMoveInverted();
        while (_rocksToRoll.Count > 0)
        {
            (int Y, int X) = _rocksToRoll.Dequeue();
            int orgY = Y;
            int orgX = X;
            bool hasMoved = false;
            while (true)
            {
                // if we hit the south edge of the platform
                if (Y == platformHeight-1)
                    break;

                // if we hit a rock or a square rock directly south of us
                if (_coordinates[Y + 1, X] == '#' || _coordinates[Y + 1, X] == 'O')
                    break;
                Y++;
                hasMoved = true;
            }
            if (hasMoved)
            {
                _coordinates[Y, X] = 'O';
                _coordinates[orgY, orgX] = '.';
            }
        }
    }

    public void TiltWest()
    {
        ScanForRollingRocksToMove();
        while (_rocksToRoll.Count > 0)
        {
            (int Y, int X) = _rocksToRoll.Dequeue();
            int orgY = Y;
            int orgX = X;
            bool hasMoved = false;
            while (true)
            {
                // if we hit the west edge of the platform
                if (X == 0)
                    break;

                // if we hit a rock or a square rock directly west of us
                if (_coordinates[Y, X-1] == '#' || _coordinates[Y, X-1] == 'O')
                    break;
                X--;
                hasMoved = true;
            }
            if (hasMoved)
            {
                _coordinates[Y, X] = 'O';
                _coordinates[orgY, orgX] = '.';
            }
        }
    }

    public void TiltEast()
    {
        ScanForRollingRocksToMoveInverted();
        while (_rocksToRoll.Count > 0)
        {
            (int Y, int X) = _rocksToRoll.Dequeue();
            int orgY = Y;
            int orgX = X;
            bool hasMoved = false;
            while (true)
            {
                // if we hit the east edge of the platform
                if (X == platformWidth-1)
                    break;

                // if we hit a rock or a square rock directly east of us
                if (_coordinates[Y, X+1] == '#' || _coordinates[Y, X+1] == 'O')
                    break;
                X++;
                hasMoved = true;
            }
            if (hasMoved)
            {
                _coordinates[Y, X] = 'O';
                _coordinates[orgY, orgX] = '.';
            }
        }
    }

    public void Dump()
    {
        for (int y = 0; y < platformHeight; y++)
        {
            int rowWeight = platformHeight - y;
            for (int x = 0; x < platformWidth; x++)
            {
                Console.Write(_coordinates[y, x]);
            }
            Console.Write("\t");
            Console.Write(rowWeight);
            Console.Write("\n");
        }
    }



}