public class Screen
{
    public bool[,] Pixels; // Col, Row
    public int PixelCount(bool state)
    {
        int count = 0;
        for(int c = 0; c< _width; c++)
        {
            for(int r = 0; r < _height; r++)
            {
                count += Pixels[c,r]==state ? 1:0;
            }
        }
        return count;
    }
    
    public Screen(int Width, int Height)
    {
        this._width = Width;
        this._height = Height;
        Pixels = new bool[Width,Height];
    }

    public int _width { get; }
    public int _height { get; }

    private void PixelOn(int col, int row)
    {
        Pixels[col,row] = true;
    }

    private void PixelOff(int col, int row)
    {
        Pixels[col,row] = false;
    }

    private void SwitchPixel(int col, int row)
    {
        Pixels[col,row] = !Pixels[col,row];
    }

    public void RefreshDisplay()
    {
        for(int r = 0; r < _height; r++)
        {
            for(int c = 0; c < _width; c++)
            {
                Console.Write(Pixels[c,r] ? "#" : ".");
            }
            Console.Write(Environment.NewLine);
        }
    }

    public void Execute(string command)
    {
        var DecodedCommand = command.Split(" ");
        string instruction = DecodedCommand[0].ToLower();
        switch (instruction)
        {
            case "rect":
                int[] WH = DecodedCommand[1].Split("x").Select(v => int.Parse(v)).ToArray();
                DrawRectangle(WH[0],WH[1]);
                break;
            case "rotate":
                string orientation = DecodedCommand[1].ToLower();
                if(orientation=="row")
                {
                    int y = int.Parse(DecodedCommand[2].Replace("y=",""));
                    int x = int.Parse(DecodedCommand[4]);
                    RotateRow(y,x);
                }
                else if(orientation =="column")
                {
                    int x = int.Parse(DecodedCommand[2].Replace("x=",""));
                    int y = int.Parse(DecodedCommand[4]);
                    RotateColumn(x,y);
                }
                else
                {
                    Console.WriteLine($"Unknown orientation {orientation} for command {instruction}");
                }
                break;
            default:
                break;
        }
    }


    private void DrawRectangle(int width, int height)
    {
        Console.WriteLine($"Draw a rectangle width:{width} height:{height}");
        for(int c = 0; c < width; c++)
        {
            for(int r = 0; r < height; r++)
            {
                PixelOn(c,r);
            }
        }
    }

    private void RotateRow(int row, int pixels)
    {
        
        bool[] updatedRow = new bool[_width];
        for(int c = 0; c < _width; c++)
        {
            //calculate where the pixel should end up in the updated column
            int newC = (c + pixels) % _width;
            updatedRow[newC] = Pixels[c,row];
        }

        for(int c = 0; c < _width; c++)
        {
            Pixels[c,row] = updatedRow[c];
        }
        Console.WriteLine($"Rotated Row: {row} by: {pixels} pixels");
    }

    private void RotateColumn(int col, int pixels)
    {
        bool[] updatedColumn = new bool[_height];
        for(int r = 0; r < _height; r++)
        {
            //calculate where the pixel should end up in the updated column
            int newR = (r + pixels) % _height;
            updatedColumn[newR]=Pixels[col,r];
        }
        for(int r = 0; r < _height; r++)
        {
            // transfer the updated column to the Screens column
            Pixels[col,r]=updatedColumn[r];
        }
        Console.WriteLine($"Rotated Column: {col} by: {pixels} pixels");
    }

}



/*
    The magnetic strip on the card you swiped encodes a series of instructions for the screen; these instructions are your puzzle input. The screen is 50 pixels wide and 6 pixels tall, all of which start off, and is capable of three somewhat peculiar operations:

    rect AxB turns on all of the pixels in a rectangle at the top-left of the screen which is A wide and B tall.
    rotate row y=A by B shifts all of the pixels in row A (0 is the top row) right by B pixels. Pixels that would fall off the right end appear at the left end of the row.
    rotate column x=A by B shifts all of the pixels in column A (0 is the left column) down by B pixels. Pixels that would fall off the bottom appear at the top of the column.

*/