public class DesertNode
{
    public string ID {get;}
    public DesertNode? Left;
    public DesertNode? Right;
    public DesertNode(string id)
    {
        ID = id;
    }
}