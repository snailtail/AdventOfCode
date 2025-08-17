using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day12
{
    class Program
    {
        private static int heading = 90; //start with a heading of due east.
        private static string[] arrInput;
        public static position currentPosition = new position();
        public static position waypointPosition = new position { x = 10, y = 1 }; // this is always relative to the ships position
        //public static readonly string inputfile="smallinput.txt"; // for testing with the small instruction set from the example
        public static readonly string inputfile="biginput.txt";


        static void Main(string[] args)
        {
            System.Console.WriteLine($"Step1 result: {Step1()}");
            System.Console.WriteLine($"Step2 result: {Step2()}");
        }
        #region step1
        private static int Step1()
        {
            //System.Console.WriteLine("*** Step 1***");
            currentPosition.x = 0;
            currentPosition.y = 0;

            arrInput = File.ReadAllLines(inputfile);
            foreach (var row in arrInput)
            {
                var activeInstruction = parseLineToInstruction(row);
                followInstruction(activeInstruction);
            }

            var posx = 0;
            var posy = 0;
            if (currentPosition.x < 0)
            {
                posx = -1 * currentPosition.x;
            }
            else
            {
                posx = currentPosition.x;
            }

            if (currentPosition.y < 0)
            {
                posy = -1 * currentPosition.y;
            }
            else
            {
                posy = currentPosition.y;
            }

            return (posx + posy);
        }

        

        private static void followInstruction(instruction activeInstruction)
        {
            switch (activeInstruction.code)
            {
                case 'F':
                    // move forward (in the direction we're facing)
                    moveForward(activeInstruction.steps);
                    break;
                case 'E':
                    currentPosition.x += activeInstruction.steps;
                    break;
                case 'S':
                    currentPosition.y -= activeInstruction.steps;
                    break;
                case 'W':
                    currentPosition.x -= activeInstruction.steps;
                    break;
                case 'N':
                    currentPosition.y += activeInstruction.steps;
                    break;
                case 'R':
                    turn(activeInstruction.steps);
                    break;
                case 'L':
                    turn((-1 * activeInstruction.steps));
                    break;
                default:
                    break;
            }
        }

        private static void turn(int steps)
        {
            if (heading + steps < 0)
            {
                heading = (heading + steps) + 360;
            }
            else if (heading + steps > 360)
            {
                heading = (heading + steps) - 360;
            }
            else if (heading + steps == 360)
            {
                heading = 0;
            }
            else
            {
                heading = heading + steps;
            }
        }

        private static void moveForward(int steps)
        {
            switch (heading)
            {

                case 0:
                    currentPosition.y += steps;
                    break;
                case 90:
                    currentPosition.x += steps;
                    break;
                case 180:
                    currentPosition.y -= steps;
                    break;
                case 270:
                    currentPosition.x -= steps;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region step2
        private static int Step2()
        {
            currentPosition.x = 0;
            currentPosition.y = 0;
            foreach (var row in arrInput)
            {
                var activeInstruction = parseLineToInstruction(row);
                followInstruction2(activeInstruction);
            }

            var posx = 0;
            var posy = 0;
            if (currentPosition.x < 0)
            {
                posx = -1 * currentPosition.x;
            }
            else
            {
                posx = currentPosition.x;
            }

            if (currentPosition.y < 0)
            {
                posy = -1 * currentPosition.y;
            }
            else
            {
                posy = currentPosition.y;
            }

            return (posx + posy);
        }

        private static void turn2(int steps)
        {
            int number_of_turns;
            if (steps < 0)
            {
                //left turn
                number_of_turns = ((-1 * steps) / 90);
                number_of_turns = number_of_turns % 4;
                turnLeft(number_of_turns);
            }
            else
            {
                number_of_turns = (steps / 90);
                number_of_turns = number_of_turns % 4;
                turnRight(number_of_turns);
            }
        }

        private static void turnLeft(int number_of_turns)
        {
            // just use right turn instead.
            // 1 left turn = 3 right turns
            // 2 left turns = 2 right turns
            // 3 left turns = 1 right turn
            // 4 = 0 turns (one complete spin of 360 degrees);

            turnRight(4 - number_of_turns);
        }
        private static void turnRight(int number_of_turns)
        {
            for (int n = 1; n <= number_of_turns; n++)
            {
                var oldy = waypointPosition.y;
                var oldx = waypointPosition.x;
                waypointPosition.x = oldy;
                waypointPosition.y = (-1 * oldx);
            }

        }

        private static void followInstruction2(instruction activeInstruction)
        {
            switch (activeInstruction.code)
            {
                case 'F':
                    // move forward (in the direction we're facing)
                    moveForward2(activeInstruction.steps);
                    break;
                case 'E':
                    waypointPosition.x += activeInstruction.steps;
                    break;
                case 'S':
                    waypointPosition.y -= activeInstruction.steps;
                    break;
                case 'W':
                    waypointPosition.x -= activeInstruction.steps;
                    break;
                case 'N':
                    waypointPosition.y += activeInstruction.steps;
                    break;
                case 'R':
                    turn(activeInstruction.steps);
                    turn2(activeInstruction.steps);
                    break;
                case 'L':
                    turn((-1 * activeInstruction.steps));
                    turn2((-1 * activeInstruction.steps));
                    break;
                default:
                    break;
            }
        }

        private static void moveForward2(int steps)
        {
            for (int n = 0; n < steps; n++)
            {
                currentPosition.x += waypointPosition.x;
                currentPosition.y += waypointPosition.y;
            }
        }


        #endregion

        #region global stuff
        private static instruction parseLineToInstruction(string theLine)
        {
            var parsedInstruction = new instruction { code = theLine.Substring(0, 1).ToCharArray()[0], steps = int.Parse(theLine.Substring(1)) };
            return parsedInstruction;
        }

        #endregion
    }

    public class position
    {
        public int x;
        public int y;
    }

    public class instruction
    {
        public char code;
        public int steps;
    }
}
