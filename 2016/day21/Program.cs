// See https://aka.ms/new-console-template for more information
using day21;

string[] instructions = File.ReadAllLines("testinput.txt");



Scrambler sc = new Scrambler();

string startValue = "abcde";
string scrambledValue = sc.Scramble(startValue, instructions);
Console.WriteLine("Done...");