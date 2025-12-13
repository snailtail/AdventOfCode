using System.Collections.Generic;

namespace AdventOfCode.TwentyFifteen.Day03
{
    public class DirectionParser
    {
        public int AtX { get; set; }
        public int AtY { get; set; }

        public int MovesMade = 0;
        public Dictionary<string, int> CoordinateVisits = new Dictionary<string, int>();

        public string Move(char Direction)
        {
            // north (^), south (v), east (>), or west (<).
            // generates a string coordinate, stores it in the global Dictionary (or increases it by 1 if it alreade exists (has been visited before)), and modifies the class variables AtX and AtY.
            // Also increases MovesMade, to keep track of how many movements Santa has made.
            switch (Direction)
            {
                case '>':
                    AtX += 1;
                    break;
                case '<':
                    AtX -= 1;
                    break;
                case '^':
                    AtY += 1;
                    break;
                case 'v':
                    AtY -= 1;
                    break;
                default:
                    break;
            }
            MovesMade += 1;
            string Coord = $"{AtX}:{AtY}";
            if(CoordinateVisits.ContainsKey(Coord)){
                CoordinateVisits[Coord] += 1;
            }
            else
            {
                CoordinateVisits.Add(Coord,1);
            }
            return Coord;
        }
    }
}