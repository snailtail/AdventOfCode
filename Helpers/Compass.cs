namespace AdventOfCode.Helpers {

    /// <summary>
    /// This class emulates a compass.
    /// It allows for tracking your current heading/direction.
    /// </summary>
    public class Compass
    {
        public enum TurnDirection
        {
            Right,
            Left
        }
        
        /// <summary>
        /// Direction is one of N, NW, W, SW, S, SE, E, NE - as a compass.
        /// This is calculated from the Heading, which is the more specific value measured in degrees.
        /// </summary>
        public string Direction 
        {
            get
            {
                return CalculateDirection(Heading);
            }
        }

        /// <summary>
        /// Heading is measured in degrees, 0 to 360. 0 and 360 is due North on the compass.
        /// 90 = Due East
        /// 180 = Due South
        /// 270 = Due West
        /// </summary>
        public int Heading {get; set;}


        /// <summary>
        /// Allows for a 90 degree turn either Left or Right.
        /// Use the enum TurnDirection in this class for the Direction.
        /// Modifies Heading with +90 degrees or -90 degrees.
        /// </summary>
        public void Turn90Degrees(TurnDirection Direction)
        {
            switch (Direction)
            {
                case TurnDirection.Left:
                    Heading -= 90;
                    if (Heading < 0)
                    {
                        Heading += 360;
                    }
                    break;
                case TurnDirection.Right:
                    Heading += 90;
                    if (Heading >= 360)
                    {
                        Heading -= 360;
                    }
                    break;

                default:
                    break;
            }
            System.Console.WriteLine($"Heading: {Heading}");
        }

        public string CalculateDirection(int HeadingDegrees)
        {
            var retval = string.Empty;
                switch(HeadingDegrees)
                {
                    case 0:
                        retval = "N";
                        break;
                    case 45:
                        retval = "NE";
                        break;
                    case 90:
                        retval = "E";
                        break;
                    case 135:
                        retval = "SE";
                        break;
                    case 180:
                        retval = "S";
                        break;
                    case 225:
                        retval = "SW";
                        break;
                    case 270:
                        retval = "W";
                        break;
                    case 315:
                        retval = "NW";
                        break;
                    default:
                        break;
                }
                return retval;
        }

    }
}