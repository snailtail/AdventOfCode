namespace AdventOfCode
{
    public static class Day05
    {
        private static List<line> Lines = new();
        private static map ventMap = new();
        //0,9 -> 5,9
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrEmpty(l)).ToArray();
            
            //Step 1
            foreach (string linedata in lines)
            {
                line ventLine = new line(linedata);
                Lines.Add(ventLine);
                ventMap.drawLine(ventLine);
            }

            var Result1 = ventMap.Coordinates.Where(kvp => kvp.Value>=2).Count();
            Console.WriteLine(Result1);

            //Step 2
            ventMap.Coordinates.Clear();
            foreach(var ventline in Lines)
            {
                ventMap.drawLine(ventline,false);
            }
            var Result2 = ventMap.Coordinates.Where(kvp => kvp.Value>=2).Count();
            Console.WriteLine(Result2);
            
        }
    }

    public class line
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public line(string coords)
        {
            string[] endpoints = coords.Split(" -> ");
            x1 = int.Parse(endpoints[0].Split(",")[0]);
            y1 = int.Parse(endpoints[0].Split(",")[1]);

            x2 = int.Parse(endpoints[1].Split(",")[0]);
            y2 = int.Parse(endpoints[1].Split(",")[1]);
        }
    }

    public class map
    {
        //(x,y), number of "hits"
        public Dictionary<(int, int), int> Coordinates = new();


        public void drawLine(line lineToDraw, bool skipDiagonal=true)
        {

            // horizontal or vertical lines
            if (lineToDraw.x1 == lineToDraw.x2 || lineToDraw.y1 == lineToDraw.y2)
            {
                if (lineToDraw.y1 == lineToDraw.y2)
                {
                    if (lineToDraw.x1 > lineToDraw.x2)
                    {
                        for (int i = lineToDraw.x2; i <= lineToDraw.x1; i++)
                        {
                            visitCoordinate(i, lineToDraw.y1);
                        }
                    }
                    else
                    {
                        for (int i = lineToDraw.x1; i <= lineToDraw.x2; i++)
                        {
                            visitCoordinate(i, lineToDraw.y1 );
                        }
                    }
                }
                else if (lineToDraw.x1 == lineToDraw.x2)
                {
                    if (lineToDraw.y1 > lineToDraw.y2)
                    {
                        for (int i = lineToDraw.y2; i <= lineToDraw.y1; i++)
                        {
                            visitCoordinate(lineToDraw.x1, i);
                        }
                    }
                    else
                    {
                        for (int i = lineToDraw.y1; i <= lineToDraw.y2; i++)
                        {
                            visitCoordinate(lineToDraw.x1, i);
                        }
                    }
                }
            }

            // Diagonal lines
            if (!skipDiagonal && (lineToDraw.x1 != lineToDraw.x2 && lineToDraw.y1 != lineToDraw.y2))
            {
                int startX = lineToDraw.x1;
                int startY = lineToDraw.y1;
                int endX = lineToDraw.x2;
                int endY = lineToDraw.y2;

                if(startX < endX)
                {
                    if (startY < endY)
                    {
                        while(startX <=endX && startY <= endY)
                        {
                            visitCoordinate(startX,startY);
                            startX++;
                            startY++;
                        }
                        return;
                    }
                    else if(startY > endY)
                    {
                        while(startX <=endX && startY >= endY)
                        {
                            visitCoordinate(startX,startY);
                            startX++;
                            startY--;
                        }
                        return;
                    }
                }

                if(startX > endX)
                {
                    if (startY < endY)
                    {
                        while(startX >=endX && startY <= endY)
                        {
                            visitCoordinate(startX,startY);
                            startX--;
                            startY++;
                        }
                        return;
                    }
                    else if(startY > endY)
                    {
                        while(startX >=endX && startY >= endY)
                        {
                            visitCoordinate(startX,startY);
                            startX--;
                            startY--;
                        }
                        return;
                    }
                }
            }
        }

        private void visitCoordinate(int x, int y)
        {
            if (Coordinates.ContainsKey((x, y)))
            {
                Coordinates[(x, y)] += 1;
            }
            else
            {
                Coordinates.Add((x, y), 1);
            }
            //Console.WriteLine($"Coordinate {x},{y} now has {Coordinates[(x, y)]} visits");
        }

    }
}

