using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Steps();
        }

        private  const string Path = "input.txt";
        public static List<string> final = new List<string>();
        public static void Steps()
        {
            string[] input = File.ReadAllText(Path).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Dictionary<string, List<string>> bagRules = ParseBags(input);
            Step1(bagRules);
            Console.WriteLine($"Part one solution:  {final.Count}");
            Console.WriteLine($"Part two solution:  {Step2(bagRules)}");
        }

        private static Dictionary<string, List<string>> ParseBags(string[] input)
        {
            Dictionary<string, List<string>> bagRules = new Dictionary<string, List<string>>();
            foreach (string b in input)
            {
                string[] bagsContent = b.Split(new string[] { " bags contain " }, StringSplitOptions.None);
                List<string> bagsChildren = bagsContent[1].Split(new string[] { "," }, StringSplitOptions.None).Select(x => x.Replace("bags.", "").Replace("bag.", "").Replace("bags", "").Replace("bag", "").Trim()).ToList();
                if (!bagRules.ContainsKey(bagsContent[0]))
                {
                    bagRules.Add(bagsContent[0], bagsChildren);
                }
                else
                {
                    bagRules[bagsContent[0]].AddRange(bagsChildren);
                }
            }

            return bagRules.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        private static int Step2(Dictionary<string, List<string>> bagRules)
        {
            string regex = @"(?<value>\d) (?<name>\w+ \w+)";
            int result = 0;
            var bags = bagRules["shiny gold"];
            foreach (var bag in bags)
            {
                Match match = Regex.Match(bag, regex);
                int count = Int32.Parse(match.Groups["value"].Value);
                string bagName = match.Groups["name"].Value;
                int bagsNumber = Recurse_Step2(bagName, bagRules, regex);
                if (bagsNumber == 1)
                {
                    result += count * bagsNumber;
                }
                else
                {
                    result += count + count * bagsNumber;
                }
            }

            return result;
        }

        private static int Recurse_Step2(string bagName, Dictionary<string, List<string>> bagsRecepies, string regex)
        {
            int result = 0;
            var bags = bagsRecepies[bagName];
            foreach (var bag in bags)
            {
                if (bag.Contains("no other"))
                {
                    return 1;
                }

                Match match = Regex.Match(bag, regex);
                int count = Int32.Parse(match.Groups["value"].Value);
                string bagName2 = match.Groups["name"].Value;
                int child = Recurse_Step2(bagName2, bagsRecepies, regex);
                if (child == 1)
                {
                    result += count * child;
                }
                else
                {
                    result += count + count * child;
                }
            }

            return result;
        }

        private static void Step1(Dictionary<string, List<string>> bagsRecepies)
        {
            var childBags = new List<string>();
            foreach (KeyValuePair<string, List<string>> recepie in bagsRecepies)
            {
                if (recepie.Value.Any(bag => bag.Contains("no other")))
                {
                    continue;
                }

                if (recepie.Value.Any(bag => bag.Contains("shiny gold")))
                {
                    childBags.Add(recepie.Key);
                    final.Add(recepie.Key);
                }
            }

            Recurse_Step1(childBags, bagsRecepies);
        }

        private static void Recurse_Step1(List<string> childBags, Dictionary<string, List<string>> allBags)
        {
            List<string> dependentBags = new List<string>();
            foreach (string needBag in childBags)
            {
                foreach (KeyValuePair<string, List<string>> bag in allBags)
                {
                    if (bag.Value.Any(x => x.Contains(needBag)))
                    {
                        dependentBags.Add(bag.Key);
                        final.Add(bag.Key);
                    }
                }
            }

            if (dependentBags.Count != 0)
            {
                dependentBags = dependentBags.Distinct().ToList();
                final = final.Distinct().ToList();
                Recurse_Step1(dependentBags, allBags);
            }
        }
    }
}
