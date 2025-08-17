// See https://aka.ms/new-console-template for more information
var Lines = File.ReadAllLines("input.txt").Where(l=> !string.IsNullOrEmpty(l)).ToList();
Screen sc = new Screen(50,6);

foreach(string line in Lines)
{
    sc.Execute(line);
    sc.RefreshDisplay();
    
}
int PixelsOn = sc.PixelCount(true);
Console.WriteLine($"Amount of lit pixels: {PixelsOn}");