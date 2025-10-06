var input = File.ReadAllLines("../data/04.dat");
int step1Sum = 0;
List<ScratchCard> Step2Collection = new();
foreach(var line in input)
{
    ScratchCard sc = new(line);
    ScratchCard sc2 = new(line);
    Step2Collection.Add(sc2);
    step1Sum+=sc.Points;
}
Console.WriteLine($"Step 1: {step1Sum}");

List<ScratchCard> NotDone = Step2Collection.Where(c=> c.Done==false).ToList();
while(NotDone.Count > 0)
{
    foreach(var sc in NotDone)
    {
        int matchingNumbers = sc.ElfsWinningNumbers.Length;
        for(int add = 1; add <= matchingNumbers; add++)
        {
            var tempCard = Step2Collection.Where(c=> c.CardNumber==sc.CardNumber+add).First();
            tempCard.Copies+=sc.Copies;
        }
        sc.Done=true;
    }
    NotDone = Step2Collection.Where(c=> c.Done==false).ToList();
}
int step2Sum = 0;
foreach(var sc in Step2Collection)
{
    step2Sum+=sc.Copies;
}

Console.WriteLine($"Step 2: {step2Sum}");
