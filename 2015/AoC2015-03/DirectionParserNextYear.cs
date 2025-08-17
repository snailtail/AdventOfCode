using System.Collections.Generic;

namespace AdventOfCode.TwentyFifteen.Day03
{
    public class DirectionParserNextYear
    {
        public int SantaX { get; set; }
        public int SantaY { get; set; }

        public int RoboX { get; set; }
        public int RoboY { get; set; }

        public int MovesMade = 0;
        public Dictionary<string, int> CoordinateVisits = new Dictionary<string, int>();
        public DirectionParserNextYear()
        {
            CoordinateVisits.Add("0:0",1);
        }
        public string Move(char Direction,bool Robo)
        {
            // north (^), south (v), east (>), or west (<).
            // generates a string coordinate, stores it in the global Dictionary (or increases it by 1 if it alreade exists (has been visited before)), and modifies the class variables AtX and AtY.
            // Also increases MovesMade, to keep track of how many movements Santa has made.
            var _x=0;
            var _y=0;

            switch (Direction)
            {
                case '>':
                    _x += 1;
                    break;
                case '<':
                    _x -= 1;
                    break;
                case '^':
                    _y += 1;
                    break;
                case 'v':
                    _y -= 1;
                    break;
                default:
                    break;
            }
            string Coord = string.Empty;
            if(Robo){
                RoboX += _x;
                RoboY +=_y;
                Coord= $"{RoboX}:{RoboY}";
            }
            else
            {
                SantaX += _x;
                SantaY +=_y;
                Coord= $"{SantaX}:{SantaY}";
            }
            MovesMade += 1;
             
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