



        Dictionary<string, string> Rules = new Dictionary<string, string>();
        Dictionary<string, long> Pairs = new Dictionary<string, long>();
        Dictionary<string, long> Polymercount = new Dictionary<string, long>();

        string[] lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();

        string inputPolymers = lines[0];
        
        // add rules
        foreach (var line in lines.Skip(1))
        {
            string[] ruleParts = line.Split(" -> ");
            Rules.Add(ruleParts[0], ruleParts[1]);
        }

        // add initial pairs
        for (int n = 0; n < inputPolymers.Length - 1; n++)
        {
            var pair = inputPolymers.Substring(n, 2);
            Pairs.TryAdd(pair, 0);
            Pairs[pair]++;
        }

        // add polymers with count
        for (int n = 0; n < inputPolymers.Length; n++)
        {
            Polymercount.TryAdd(inputPolymers[n].ToString(), 0);
            Polymercount[inputPolymers[n].ToString()]++;
        }

        //loop x amount of times
        for (int x = 0; x < 40; x++)
        {
            //get the keys, since we can't loop over the dictionary itself and simultaneously modify it
            List<string> pairKeys = new List<string>(Pairs.Keys);
            
            // make a new Dict for the updated polymerPairs
            var updatedPolymerPairs = new Dictionary<string, long>();

            
            foreach (var pair in pairKeys)
            {
                var polymerToInsert = Rules[pair];
                long count = Pairs[pair];
                string newPair1 = pair[0] + polymerToInsert;
                string newPair2 = polymerToInsert + pair[1];

                updatedPolymerPairs.TryAdd(newPair1, 0);
                updatedPolymerPairs[newPair1] += count;
                updatedPolymerPairs.TryAdd(newPair2, 0);
                updatedPolymerPairs[newPair2] += count;
                Polymercount.TryAdd(polymerToInsert, 0);
                Polymercount[polymerToInsert] += count;
            }
            Pairs = updatedPolymerPairs;
        }


        var maxPolymer = Polymercount.Max(kvp => kvp.Value);
        var minPolymer = Polymercount.Min(kvp => kvp.Value);


        Console.WriteLine($"{maxPolymer - minPolymer}");
