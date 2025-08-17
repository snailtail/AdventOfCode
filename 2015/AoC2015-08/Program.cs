using AoC2015_08;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input.txt");

int totalCode = lines.Sum(l => l.Length);
int totalCharacters = lines.Sum(CharacterCount);
int totalEncoded = lines.Sum(EncodedStringCount);

Console.WriteLine(totalCode - totalCharacters);
Console.WriteLine(totalEncoded - totalCode);

int CharacterCount(string arg) => Regex.Match(arg, @"^""(\\x..|\\.|.)*""$").Groups[1].Captures.Count;
int EncodedStringCount(string arg) => 2 + arg.Sum(CharsToEncode);
int CharsToEncode(char c) => c == '\\' || c == '\"' ? 2 : 1;
