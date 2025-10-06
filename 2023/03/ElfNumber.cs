public class ElfNumber
{
    public int Value => int.Parse(numberAsString);
    public int yPos;
    public int xStart;
    public int length => numberAsString.Length;
    public string numberAsString = "";

    public void AddNumber(char n)
    {
        numberAsString += n;
    }
}
