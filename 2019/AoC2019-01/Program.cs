string path ="input.txt";
var data = File.ReadAllLines(path).Select(l => int.Parse(l.Trim())).ToArray();
int sum_part1 = 0;
int sum_part2 = 0;
foreach(var mass in data)
{
    // Get fuel needed for the initial mass
    int fuelForMassOnly = Day01.fuelForMass(mass);
    sum_part1 += fuelForMassOnly;
    
    // Now store the fuel for the initial mass
    sum_part2 += fuelForMassOnly;
    // And then calculate fuel needed for the fuel as well.
    sum_part2 += Day01.fuelForFuel(fuelForMassOnly);
    
}
Console.WriteLine("Advent of Code 2019 - Day 1");
Console.WriteLine("Part 1: {0}", sum_part1);
Console.WriteLine("Part 2: {0}", sum_part2);