var day8Input = File.ReadAllText("../data/08.dat");
var DM = new DesertMapper(day8Input);

/*
* Step 1 
* Just follow the directions from AAA until we find ZZZ
*/
var step1Result = DM.FollowDirections(DM.Directions, "ZZZ");
System.Console.WriteLine($"Step 1: {step1Result}");

/* 
* Step 2 
* Find all the starting nodes, the ones that has an ID that ends with A.
* For each starting node, get the amount of steps needed to reach a node with ID that ends with Z
* Calculate the least common multiple for these numbers.
*/
var startnodes = DM.Nodes.Where(n => n.ID.EndsWith('A')).ToList();
var ghostResults = startnodes.Select(s => DM.FollowGhostDirections(DM.Directions, s.ID)).ToList();
var step2Result = DM.LeastCommonMultiple(ghostResults);
Console.WriteLine($"Step 2: {step2Result}");