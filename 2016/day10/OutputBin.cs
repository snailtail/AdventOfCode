public class OutputBin
{
    Queue<int> Values = new();
    
    public void AddValue(int value)
    {
        if (Values.Count > 1)
        {
            throw new System.ArgumentException("Can't add value to bot {_id}, it already has 2 for some reason...");
        }
        Values.Enqueue(value);
    }
}