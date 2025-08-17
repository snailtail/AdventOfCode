namespace AdventOfCode.Helpers
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Compass();
            x.Turn90Degrees(Compass.TurnDirection.Right);
            Logger.Log(x.Direction);
            x.Turn90Degrees(Compass.TurnDirection.Right);
            Logger.Log(x.Direction);
            x.Turn90Degrees(Compass.TurnDirection.Right);
            Logger.Log(x.Direction);
            x.Turn90Degrees(Compass.TurnDirection.Right);
            Logger.Log(x.Direction);
            x.Turn90Degrees(Compass.TurnDirection.Right);
            Logger.Log(x.Direction);
            x.Turn90Degrees(Compass.TurnDirection.Right);
            Logger.Log(x.Direction);
            x.Turn90Degrees(Compass.TurnDirection.Left);
            Logger.Log(x.Direction, LogLevel.Information);
            Logger.Log(x.Direction, LogLevel.Information);
            Logger.Log(x.CalculateDirection(315),LogLevel.Information);
        }
    }
}
