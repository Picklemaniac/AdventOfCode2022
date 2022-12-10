using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day9
    {
        private const string filePath = @"Inputs\day9.txt";

        private string[,] grid = new string[21, 21];

        private IEnumerable<string> instructions;

        private Tuple<int, int> headerLocation;
        private Tuple<int, int> tailLocation;

        private HashSet<(int, int)> visitedSpots = new HashSet<(int, int)>();


        public Day9()
        {
            instructions = File.ReadAllLines(filePath);
            headerLocation = new Tuple<int, int>(0, 0);
            tailLocation = new Tuple<int, int>(0, 0);
        }

       

        public void SolvePuzzle1()
        {
            foreach (var instruction in instructions)
            {
                string dir = instruction.Split(" ")[0];
                int steps = int.Parse(instruction.Split(" ")[1]);

                for (int i = 0; i < steps; i++)
                {
                    if (dir == "U")
                    {

                    }
                    if (dir == "D")
                    {

                    }
                    if (dir == "L")
                    {

                    }
                    if (dir == "R")
                    {

                    }

                    printGridState();
                }
            }
        }

        private void printGridState()
        {
            Console.Clear();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {

                    if (headerLocation.Item1 == i && headerLocation.Item2 == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("H");
                    }
                    else if (tailLocation.Item1 == i && tailLocation.Item2 == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write(grid[i, j]);
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
        }
    }
}
