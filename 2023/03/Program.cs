var schematicData = File.ReadAllLines("../data/03.dat");

EngineSchematicResolver esr = new(schematicData);

Console.WriteLine($"Step 1: {esr.PartNumberSum}");
Console.WriteLine($"Step 2: {esr.GearRatioSum}");
