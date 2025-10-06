public class Galaxy
{
    public int Y => Coordinate.Y;
    public int X => Coordinate.X;
    public GalaxyCoordinate Coordinate;

    public Dictionary<GalaxyCoordinate,long> Neighbors = new();
    public Galaxy(int y, int x)
    {
        Coordinate = new GalaxyCoordinate(y,x);
    }
    public GalaxyCoordinate NearestNeighborCoordinate => Neighbors.OrderBy(g=> g.Value).First().Key;
}
