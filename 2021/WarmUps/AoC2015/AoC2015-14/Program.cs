namespace AoC2015
{
    public class Day14
    {
        private static List<Reindeer> OlympicReindeer = new();
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            foreach (string line in input)
            {
                var newReindeer = ParseReindeerInformation(line);
                OlympicReindeer.Add(newReindeer);
            }
            int sprintTime = 2503;
            var WinnerStep1 = OlympicReindeer.MaxBy(r => r.GetDistanceAfterSprint(sprintTime));
            Console.WriteLine($"{WinnerStep1.Name} = {WinnerStep1.GetDistanceAfterSprint(sprintTime)}");
            

            for(int n = 1; n<= sprintTime; n++)
            {
                var Leader = OlympicReindeer.MaxBy(r => r.GetDistanceAfterSprint(n));
                Leader.PointsAwarded++;                
            }

            var WinnerStep2 = OlympicReindeer.MaxBy(r => r.PointsAwarded);
            
            Console.WriteLine($"{WinnerStep2.Name} = {WinnerStep2.PointsAwarded}");

        }

        private static Reindeer ParseReindeerInformation(string information)
        {
            var instruction = information.Split(" can fly ");
            var name = instruction[0];
            var travel = instruction[1].Split(" km/s for ");
            var speed = int.Parse(travel[0].Split(' ')[0]);
            var endurance = int.Parse(travel[1].Split(' ')[0]);
            var rest = int.Parse(instruction[1].Split(" seconds, but then must rest for ")[1].Split(' ')[0]);
            return new Reindeer()
            {
                Name = name,
                Speed = speed,
                Endurance = endurance,
                Rest = rest
            };
        }
    }

    public class Reindeer
    {

        public string? Name { get; set; }
        public int Speed { get; set; }
        public int Endurance { get; set; }
        public int Rest { get; set; }
        public int PointsAwarded {get;set;}

        public int GetDistanceAfterSprint(int sprintDurationSeconds)
        {
            int distanceTraveled = 0;
            while (sprintDurationSeconds > 0)
            {
                if (sprintDurationSeconds >= Endurance)
                {

                    distanceTraveled += (Speed * Endurance);

                }
                else
                {
                    distanceTraveled += (Speed * sprintDurationSeconds);
                }

                sprintDurationSeconds -= Endurance;
                sprintDurationSeconds -= Rest;
            }
            return distanceTraveled;
        }

    }
}