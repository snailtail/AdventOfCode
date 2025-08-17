using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day09
{
    public class Solver
    {
        public int Solve(string[] input, bool Step2 = false)
        {
            HashSet<string> Locations = new HashSet<string>();
            List<DistancePair> distancePairs = new List<DistancePair>();
            foreach(var item in input)
            {
                var groups = Regex.Match(item, @"^(\w+) to (\w+) = (\d+)").Groups;
                var From = groups[1].Value;
                var To = groups[2].Value;
                var Distance = int.Parse(groups[3].Value);
                distancePairs.Add(new DistancePair(From,To,Distance));
                Locations.Add(From);
                Locations.Add(To);
            }
            List<List<string>> perResult = new List<List<string>>();
            Permutation(Locations.ToList(), new List<string>(), perResult);
            int minDistance = int.MaxValue;
            int maxDistance = int.MinValue;
            foreach(var route in perResult)
            {
                // loopa igenom routes
                int pos = 0;
                int sumDistance = 0;
                while(pos < route.Count-1)
                {
                    DistancePair tempPair = new DistancePair(route[pos], route[pos + 1], -1);
                    int distance = distancePairs.Where(dp => (dp.Location1 == tempPair.Location1 && dp.Location2 == tempPair.Location2) || (dp.Location2 == tempPair.Location1 && dp.Location1 == tempPair.Location2)).Select(dp => dp.Distance).FirstOrDefault();
                    sumDistance += distance;
                    pos++;
                }
                minDistance = Math.Min(sumDistance, minDistance);
                maxDistance = Math.Max(sumDistance, maxDistance);
                
            }
            if (Step2)
                return maxDistance;
            else
                return minDistance;
        }

        private void Permutation<T>(List<T> choices, List<T> workingSet, List<List<T>> permutations)
        {
            if (choices.Count == 0)
                permutations.Add(new List<T>(workingSet));

            for (int i = 0; i < choices.Count; i++)
            {
                var value = choices[i];
                workingSet.Add(value);
                choices.RemoveAt(i);
                Permutation(choices, workingSet, permutations);
                choices.Insert(i, value);
                workingSet.Remove(value);
            }

        }
    }

    //public class Route
    //{
    //    public Route(DistancePair p1, DistancePair p2)
    //    {
    //        P1 = p1;
    //        P2 = p2;
    //    }

    //    public DistancePair P1 { get; }
    //    public DistancePair P2 { get; }
    //}

    public class DistancePair
    {
        public string Location1;
        public string Location2;
        public int Distance;
        public DistancePair(string from, string to, int distance)
        {
            Location1 = from;
            Location2 = to;
            Distance = distance;

        }

        public DistancePair(string Descriptor)
        {
            var groups = Regex.Match(Descriptor, @"^(\w+) to (\w+) = (\d+)").Groups;
            Location1 = groups[1].Value;
            Location2 = groups[2].Value;
            Distance = int.Parse(groups[3].Value);
        }


        public bool Contains(string Location)
        {
            return Location1 == Location || Location2 == Location;
        }
    }
}
