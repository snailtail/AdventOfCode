namespace AdventOfCode
{
    public class Day15
    {
        private static string inputFile = "input.txt";
        private static readonly Vertex[][] _mapPart1 = File.ReadAllLines(inputFile)
                .Where(l => !string.IsNullOrEmpty(l))
                .Select((r, i) => r
                    .Select((n, j) => new Vertex { Value = Convert.ToInt32(n.ToString()), Y = i, X = j })
                    .ToArray())
                .ToArray();
        private static Vertex[][] _mapPart2;
        private static Vertex[][] map;

        public static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {Part1()}");
            Console.WriteLine($"Part 2: {Part2()}");
        }

        public static long Part1()
        {
            map = _mapPart1;
            return computeDijkstra(map);
        }

        public static long Part2()
        {
            //build the extended map. Stole "inspiration" from Reddit.
            _mapPart2 = new Vertex[_mapPart1.Length * 5][];
            var height = _mapPart1.Length;
            var width = _mapPart1[0].Length;
            for (var y = 0; y < 5; y++)
            {
                var targetY = y * height;
                for (var i = 0; i < height; i++)
                {
                    _mapPart2[targetY + i] = new Vertex[width * 5];
                    for (var x = 0; x < 5; x++)
                    {
                        var targetX = x * width;
                        for (var j = 0; j < width; j++)
                        {
                            var value = (_mapPart1[i][j].Value - 1 + y + x) % 9 + 1;
                            _mapPart2[targetY + i][targetX + j] = new Vertex()
                            { Value = value, Y = targetY + i, X = targetX + j };
                        }
                    }
                }
            }

            map = _mapPart2;
            return computeDijkstra(map);
        }

        private static long computeDijkstra(Vertex[][] Map)
        {
            int startX = 0;
            int startY = 0;
            Map[startY][startX].Distance = 0;

            //Use a priority queue which will allow us to always "pop" the Vertex with the lowest amount of distance.
            PriorityQueue<Vertex, long> q = new PriorityQueue<Vertex, long>();
            q.Enqueue(Map[startY][startX], Map[startY][startX].Distance);


            while (q.Count > 0)
            {
                var thisVertex = q.Dequeue();
                thisVertex.unProcessed = true;

                var neighbours = getNeighbours(Map, thisVertex.Y, thisVertex.X);

                foreach (var neighbour in neighbours)
                {
                    var newDistance = thisVertex.Distance + neighbour.Value;
                    if (newDistance >= neighbour.Distance) continue; //we must have stored a shorter distance from some other neighbor Vertex.

                    neighbour.Distance = newDistance;
                    neighbour.PreviousVertex = thisVertex;
                    q.Enqueue(neighbour, newDistance);
                }
            }

            //Return the distance of the Vertex in the lower right corner.
            return Map[^1][^1].Distance;
        }

        private static List<Vertex> getNeighbours(Vertex[][] Map, int y, int x)
        {
            var neighbors = new List<Vertex>();

            //up
            if (y > 0 && !Map[y - 1][x].unProcessed)
            {
                neighbors.Add(Map[y - 1][x]);
            }

            //down
            if (y < Map.Length - 1 && !Map[y + 1][x].unProcessed)
            {
                neighbors.Add(Map[y + 1][x]);
            }

            //left
            if (x > 0 && !Map[y][x - 1].unProcessed)
            {
                neighbors.Add(Map[y][x - 1]);
            }

            //right
            if (x < Map[y].Length - 1 && !Map[y][x + 1].unProcessed)
            {
                neighbors.Add(Map[y][x + 1]);
            }

            return neighbors;
        }
    }
    public class Vertex
    {
        public int Y { get; set; }
        public int X { get; set; }
        public int Value { get; set; }
        public long Distance { get; set; } = long.MaxValue;
        public Vertex PreviousVertex { get; set; }
        public bool unProcessed { get; set; }
    }

}

/*
 * 
 * Pseudo Dijkstra
 * https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
 1 function Dijkstra(Graph, source):
 2
 3      create vertex set Q
 4
 5      for each vertex v in Graph:            
 6          dist[v] ← INFINITY
 7          prev[v] ← UNDEFINED
 8          add v to Q                     
 9      dist[source] ← 0
10
11      while Q is not empty:
12          u ← vertex in Q with min dist[u]
13
14          remove u from Q
15         
16          for each neighbor v of u still in Q:
17              alt ← dist[u] + length(u, v)
18              if alt < dist[v]:              
19                  dist[v] ← alt
20                  prev[v] ← u
21
22      return dist[], prev[]

*/
