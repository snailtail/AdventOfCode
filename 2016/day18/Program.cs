using System.Runtime.CompilerServices;
using System.Text;

string input = File.ReadAllText("input.txt");

string? GenerateMap(string input, int TotalRows)
{
    if (TotalRows == 1)
        return input;

    char[,] Map = new char[TotalRows, input.Length]; //Rows,Cols
    
    // Add the first row - which is the input string
    for(int n = 0; n < input.Length; n++)
    {
        Map[0,n]= input[n];
    }


    /*
     * ^ = Trap (True)
     * . = Safe (false)
     *  Its left and center tiles are traps, but its right tile is not.
     *  Its center and right tiles are traps, but its left tile is not.
     *  Only its left tile is a trap.
     *  Only its right tile is a trap.
     * 
     */

    // ta ut left, center, right som booleaner
    // corner case om c = 0 eller = length-1 så är left respektive right = false (ej trap)

    for (int r = 1; r < TotalRows; r++)
    {
        for(int c = 0; c < input.Length; c++ )
        {
            bool left;
            bool center;
            bool right;
            char newChar;
            // check left
            if(c==0)
            {
                left = false;
            }
            else
            {
                left = Map[r - 1, c-1] == '^';
            }

            // check center
            center = Map[r-1,c] == '^';

            // check right
            if(c==input.Length-1)
            {
                // we are in the last col - right is to be considered as safe
                right = false;
            }
            else
            {
                right = Map[r - 1, c + 1] == '^';
            }

            // now consider the rules:
            if(left && center && !right)
            {
                newChar = '^';
            }
            else if (center && right && !left)
            {
                newChar = '^';
            }
            else if (left && !center && !right)
            {
                newChar = '^';
            }
            else if (right && !center && !left)
            {
                newChar = '^';
            }
            else
            {
                newChar = '.';
            }

            // apply this char to the current row/col
            Map[r,c]=newChar;
        }
    }



    // Build the output string

    StringBuilder sb = new();
    for(int r = 0; r < TotalRows; r++)
    {
        for(int c = 0; c < input.Length; c++)
        {
            sb.Append(Map[r, c]);
        }
        sb.Append("\r\n");
    }
    return sb.ToString();
}


string step1 = GenerateMap(input, 40);
string step2 = GenerateMap(input, 400000);

Console.WriteLine(step1.Where(c=> c=='.').Count());
Console.WriteLine(step2.Where(c => c == '.').Count());