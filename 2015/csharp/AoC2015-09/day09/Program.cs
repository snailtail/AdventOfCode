using System.Text.RegularExpressions;
using System.Collections.Generic;
using day09;


var input = File.ReadAllLines("input.txt");
Solver s = new Solver();

var result = s.Solve(input,true);
Console.WriteLine(result);

