using System.Text.RegularExpressions;

public class DesertMapper
{
    private string directions;
    private List<DesertNode> nodes = new();

    public string Directions { get => directions; }
    public List<DesertNode> Nodes { get => nodes; }

    public DesertMapper(string mapinput)
    {
        string[] parts = mapinput.Split(Environment.NewLine);
        directions = parts[0].Trim();
        for (int i = 2; i < parts.Length; i++)
        {
            string nodeName = parts[i].Split(" ")[0];

            nodes.Add(new DesertNode(nodeName));
        }
        for (int i = 2; i < parts.Length; i++)
        {
            string pattern = @"^(\w+)\s=\s\((\w+),\s(\w+)\)$";
            var match = Regex.Match(parts[i], pattern);
            string nodeName = match.Groups[1].Value;
            string leftID = match.Groups[2].Value;
            string rightID = match.Groups[3].Value;
            DesertNode? left = nodes.Where(n => n.ID == leftID).FirstOrDefault();
            DesertNode? right = nodes.Where(n => n.ID == rightID).FirstOrDefault();
            DesertNode? nodeToUpdate = nodes.Where(n => n.ID == nodeName).FirstOrDefault();
            if (nodeToUpdate != null)
            {
                nodeToUpdate.Left = left;
                nodeToUpdate.Right = right;
            }
        }
    }

    public long FollowDirections(string directionData, string destinationID)
    {
        DesertNode start = nodes.Where(n => n.ID == "AAA").First();
        DesertNode? activeNode = start;
        string activeNodeID = "";
        int directionIndex = 0;
        long steps = 0;
        while (activeNodeID != destinationID)
        {
            if (directionIndex >= directionData.Length)
            {
                directionIndex = 0;
            }
            switch (directionData[directionIndex])
            {
                case 'L':
                    activeNode = activeNode != null ? activeNode.Left : null;
                    break;
                case 'R':
                    activeNode = activeNode != null ? activeNode.Right : null;
                    break;
                default:
                    throw new System.Exception($"Directiondata \"{directionData[directionIndex]}\" not understood ");
            }
            steps++;
            directionIndex++;
            activeNodeID = activeNode == null ? "" : activeNode.ID;
        }
        return steps;
    }

    public long FollowGhostDirections(string directionData, string startNodeID)
    {
        DesertNode start = nodes.Where(n => n.ID == startNodeID).First();
        DesertNode? activeNode = start;
        string activeNodeID = "";
        int directionIndex = 0;
        long steps = 0;
        while (!activeNodeID.EndsWith('Z'))
        {
            if (directionIndex >= directionData.Length)
            {
                directionIndex = 0;
            }
            switch (directionData[directionIndex])
            {
                case 'L':
                    activeNode = activeNode != null ? activeNode.Left : null;
                    break;
                case 'R':
                    activeNode = activeNode != null ? activeNode.Right : null;
                    break;
                default:
                    throw new System.Exception($"Directiondata \"{directionData[directionIndex]}\" not understood ");
            }
            steps++;
            directionIndex++;
            activeNodeID = activeNode == null ? "" : activeNode.ID;
        }
        return steps;
    }

    #region LCM calculations
    public long LeastCommonMultiple(IEnumerable<long> numbers)
    {
        return numbers.Aggregate((long)1, (current, number) => current / GreatestCommonDivisor(current, number) * number);

    }

    private long GreatestCommonDivisor(long a, long b)
    {
        while (b != 0)
        {
            a %= b;
            (a, b) = (b, a);
        }
        return a;
    }
    #endregion
}