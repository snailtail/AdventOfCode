namespace AdventOfCode
{
    public static class Day06
    {
        private static Dictionary<int, long> fishAgeGroups = new();
        public static void Main(string[] args)
        {
            //Step 1, age the fishies 80 days
            resetFishAgeGroups();
            long sumStep1 = AgeFish(80);
            Console.WriteLine(sumStep1);

            //Step 2, age the fishies up to 256 days (we already did 80, so let's just continue on with the remaining 176)
            long sumStep2 = AgeFish(176);
            Console.WriteLine(sumStep2);
        }


        public static long AgeFish(int repetitions)
        {
            long sum = 0;
            for (int i = 0; i < repetitions; i++)
            {
                long new8 = fishAgeGroups[0];
                long add6 = fishAgeGroups[0];
                long new0 = fishAgeGroups[1];
                long new1 = fishAgeGroups[2];
                long new2 = fishAgeGroups[3];
                long new3 = fishAgeGroups[4];
                long new4 = fishAgeGroups[5];
                long new5 = fishAgeGroups[6];
                long new6 = fishAgeGroups[7] + add6;
                long new7 = fishAgeGroups[8];

                fishAgeGroups[0] = new0;
                fishAgeGroups[1] = new1;
                fishAgeGroups[2] = new2;
                fishAgeGroups[3] = new3;
                fishAgeGroups[4] = new4;
                fishAgeGroups[5] = new5;
                fishAgeGroups[6] = new6;
                fishAgeGroups[7] = new7;
                fishAgeGroups[8] = new8;
            }
            foreach (KeyValuePair<int, long> kv in fishAgeGroups)
            {
                sum += kv.Value;
            }
            return sum;
        }

        private static void resetFishAgeGroups()
        {
            fishAgeGroups.Clear();
            for (int i = 0; i < 9; i++)
            {
                fishAgeGroups.Add(i, 0);
            }
            int[] fishes = File.ReadAllText("input.txt").Split(',').Select(f => int.Parse(f)).ToArray();
            // add the initial fishes states
            foreach (var i in fishes)
            {
                fishAgeGroups[i]++;
            }
        }
    }
}