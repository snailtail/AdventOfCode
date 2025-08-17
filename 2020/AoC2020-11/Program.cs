using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day11
{
    class Program
    {
        private static List<char[]> seatingChart = new List<char[]>();
        private static int RoundCounter;
        static void Main(string[] args)
        {
            /**

            Each position is either 
                floor (.)
                an empty seat (L)
                or an occupied seat (#).

            If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied.
            If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
            Otherwise, the seat's state does not change.

            **/

            Step1();
            Step2();


        }

        private static void Step1()
        {
            var rawData = File.ReadAllLines("input.txt");
            foreach (var row in rawData)
            {
                seatingChart.Add(row.ToCharArray());
            }

            System.Console.WriteLine($"Results of step1: {iterate_step1(seatingChart)}");
            System.Console.WriteLine($"Number of rounds performed: {RoundCounter}");

        }


        private static void Step2()
        {
            System.Console.WriteLine($"Results of step1: {iterate_step2(seatingChart)}");
        }

        private static int iterate_step1(List<char[]> initial_Seating)
        {
            List<char[]> current_seating = new List<char[]>(initial_Seating.Count);
            int row_count = 0;
            int column_count = 0;
            initial_Seating.ForEach((item) =>
            {
                current_seating.Add((char[])item.Clone());
            });
            var count_of_updates = -1;

            System.Console.WriteLine("Let's start");
            RoundCounter = 0;
            while (count_of_updates != 0)
            {
                RoundCounter++;
                count_of_updates = 0;

                List<char[]> new_seating = new List<char[]>(current_seating.Count);

                current_seating.ForEach((item) =>
                {
                    new_seating.Add((char[])item.Clone());
                });
                row_count = new_seating.Count;
                column_count = new_seating[0].Length;
                for (int row = 0; row < row_count; row++)
                {
                    for (int col = 0; col < column_count; col++)
                    {
                        var current_seat = current_seating[row][col];
                        if (current_seat == '.')
                        {
                            continue;
                            //there's nothing to do
                        }
                        var occupied_seats_count = count_occupied_adjacent_seats(current_seating, row, col);
                        if (current_seat == 'L' && occupied_seats_count == 0)
                        {
                            new_seating[row][col] = '#';
                            count_of_updates += 1;
                            continue;
                        }
                        if (current_seat == '#' && occupied_seats_count >= 4)
                        {
                            new_seating[row][col] = 'L';
                            count_of_updates += 1;
                            continue;
                        }

                    }
                }
                //printChart(new_seating);
                current_seating.Clear();
                new_seating.ForEach((item) =>
                {
                    current_seating.Add((char[])item.Clone());
                });

            }
            System.Console.WriteLine("reached stable state");
            var count_of_occupied = 0;
            for (int row = 0; row < row_count; row++)
            {
                for (int col = 0; col < column_count; col++)
                {
                    if (current_seating[row][col] == '#')
                        count_of_occupied += 1;
                }

            }


            return count_of_occupied;


        }

        private static int count_occupied_adjacent_seats(List<char[]> aSeatingChart, int row, int col)
        {
            int row_count = aSeatingChart.Count;
            int col_count = aSeatingChart[0].Length;
            int occupied_count = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r < 0 || r > row_count - 1 || c < 0 || c > col_count - 1 || (c == col && r == row))
                    {
                        continue;
                    }
                    char seat = aSeatingChart[r][c];
                    if (seat == '#')
                    {
                        occupied_count++;
                    }
                }
            }
            return occupied_count;
        }

        private static int count_occupied_adjacent_seats_part_2(List<char[]> seating_state, int row, int column)
        {
            int row_count = seating_state.Count;
            int column_count = seating_state[0].Length;
            int occupied_count = 0;

            List<(int, int)> direction = new List<(int, int)>();
            (int, int) val = (-1, -1);
            direction.Add(val);
            val = (-1, 0);
            direction.Add(val);
            val = (-1, 1);
            direction.Add(val);
            val = (0, -1);
            direction.Add(val);
            val = (0, 1);
            direction.Add(val);
            val = (1, -1);
            direction.Add(val);
            val = (1, 0);
            direction.Add(val);
            val = (1, 1);
            direction.Add(val);
            foreach (var dir in direction)
            {

                int r = row;
                int c = column;
                bool searching = true;
                while (searching)
                {
                    r += dir.Item1;
                    c += dir.Item2;
                    if (r < 0 || r > row_count - 1 || c < 0 || c > column_count - 1)
                    {
                        searching = false;
                        break;
                    }
                    var place = seating_state[r][c];
                    if (place == '#')
                    {
                        occupied_count += 1;
                        searching = false;
                    }
                    if (place == 'L')
                    {
                        searching = false;
                        break;
                    }
                }
            }
            return occupied_count;
        }


        private static int iterate_step2(List<char[]> initial_Seating)
        {
            List<char[]> current_seating = new List<char[]>(initial_Seating.Count);
            int row_count = 0;
            int column_count = 0;
            initial_Seating.ForEach((item) =>
            {
                current_seating.Add((char[])item.Clone());
            });
            var count_of_updates = -1;

            System.Console.WriteLine("Let's start");

            while (count_of_updates != 0)
            {
                count_of_updates = 0;

                List<char[]> new_seating = new List<char[]>(current_seating.Count);

                current_seating.ForEach((item) =>
                {
                    new_seating.Add((char[])item.Clone());
                });

                row_count = new_seating.Count;
                column_count = new_seating[0].Length;

                for (int row = 0; row < row_count; row++)
                {
                    for (int col = 0; col < column_count; col++)
                    {
                        var current_seat = current_seating[row][col];
                        if (current_seat == '.')
                        {
                            continue;
                            //there's nothing to do
                        }
                        var occupied_seats_count = count_occupied_adjacent_seats_part_2(current_seating, row, col);
                        if (current_seat == 'L' && occupied_seats_count == 0)
                        {
                            new_seating[row][col] = '#';
                            count_of_updates += 1;
                            continue;
                        }
                        if (current_seat == '#' && occupied_seats_count >= 5)
                        {
                            new_seating[row][col] = 'L';
                            count_of_updates += 1;
                            continue;
                        }



                    }
                }
                current_seating.Clear();
                new_seating.ForEach((item) =>
                {
                    current_seating.Add((char[])item.Clone());
                });
            }


            System.Console.WriteLine("reached stable state");
            var count_of_occupied = 0;
            for (int row = 0; row < row_count; row++)
            {
                for (int col = 0; col < column_count; col++)
                {
                    if (current_seating[row][col] == '#')
                        count_of_occupied += 1;
                }

            }


            return count_of_occupied;
        }


        private static void printChart(List<char[]> aChart)
        {
            System.Console.WriteLine("*******************");
            for (int row = 0; row <= aChart.Count - 1; row++)
            {
                for (int col = 0; col <= aChart[row].Length - 1; col++)
                {
                    System.Console.Write(aChart[row][col]);
                }
                System.Console.Write(Environment.NewLine);
            }
            System.Console.WriteLine("*******************");
        }
    }
}
