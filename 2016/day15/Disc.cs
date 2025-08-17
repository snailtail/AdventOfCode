public class Disc
{
    private int _discSize;
    private int _position;
    public int ID { get; set; }
    
    
    public int DiscSize
    {
        get { return _discSize; }
        set { _discSize = value; }
    }
    

    public int Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public Disc(int id, int Size, int Position)
    {
        _discSize=Size;
        _position=Position;
        ID = id;
    }   

}