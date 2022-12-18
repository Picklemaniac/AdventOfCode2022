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
        private const string testfilePath = @"Inputs\TestInputs\day9test.txt";
        private const string filePath = @"Inputs\day9.txt";

        private string[,] grid = new string[27, 60];

        private IEnumerable<string> instructions;

        private (int x, int y) headerLocation;
        private (int x, int y) tailLocation;
        private (int x, int y)[] tailLocations;

        private HashSet<(int, int)> visitedSpots = new HashSet<(int, int)>();


        public Day9()
        {
            instructions = File.ReadAllLines(filePath);
            headerLocation = new(20, 45);
        }

        public void SolvePuzzle1()
        {
            tailLocation = new(20, 45);

            foreach (var instruction in instructions)
            {
                string dir = instruction.Split(" ")[0];
                int steps = int.Parse(instruction.Split(" ")[1]);

                for (int i = 0; i < steps; i++)
                {
                    if (dir == "U")
                    {
                        headerLocation.x += 1;
                    }
                    if (dir == "D")
                    {
                        headerLocation.x += -1;
                    }
                    if (dir == "L")
                    {
                        headerLocation.y += -1;
                    }
                    if (dir == "R")
                    {
                        headerLocation.y += 1;
                    }

                    // tussen -2 en 2
                    int directionX = headerLocation.x - tailLocation.x;
                    int directionY = headerLocation.y - tailLocation.y;

                    //Als je -2 zit of +2
                    if (directionX < -1 || directionY < -1)
                    {
                        tailLocation.x += Math.Sign(directionX);
                        tailLocation.y += Math.Sign(directionY);

                    }
                    else if (directionX > 1 || directionY > 1)
                    {
                        tailLocation.x += Math.Sign(directionX);
                        tailLocation.y += Math.Sign(directionY);
                    }

                    visitedSpots.Add(tailLocation);

                    printGridState();
                    Thread.Sleep(1);
                }
            }

            Console.WriteLine($"AANTAL BEZOCHTE PLEKKEN: {visitedSpots.Count()}");
        }

        public void SolvePuzzle2()
        {
            //Beun
            tailLocations = new (int x, int y)[9] { (20, 45), (20, 45), (20, 45), (20, 45), (20, 45), (20, 45), (20, 45), (20, 45), (20, 45) };

            foreach (var instruction in instructions)
            {
                string dir = instruction.Split(" ")[0];
                int steps = int.Parse(instruction.Split(" ")[1]);

                for (int i = 0; i < steps; i++)
                {
                    if (dir == "U")
                    {
                        headerLocation.x += 1;
                    }
                    if (dir == "D")
                    {
                        headerLocation.x += -1;
                    }
                    if (dir == "L")
                    {
                        headerLocation.y += -1;
                    }
                    if (dir == "R")
                    {
                        headerLocation.y += 1;
                    }

                    for (int j = 0; j <= 8; j++)
                    {
                        int directionX = 0;
                        int directionY = 0;

                        // tussen -2 en 2
                        if (j == 0)
                        {
                            directionX = headerLocation.x - tailLocations[j].x;
                            directionY = headerLocation.y - tailLocations[j].y;
                        }
                        else
                        {
                            directionX = tailLocations[j - 1].x - tailLocations[j].x;
                            directionY = tailLocations[j - 1].y - tailLocations[j].y;
                        }

                        //Als je -2 zit of +2
                        if (directionX < -1 || directionY < -1)
                        {
                            tailLocations[j].x += Math.Sign(directionX);
                            tailLocations[j].y += Math.Sign(directionY);

                        }
                        else if (directionX > 1 || directionY > 1)
                        {
                            tailLocations[j].x += Math.Sign(directionX);
                            tailLocations[j].y += Math.Sign(directionY);
                        }

                    }

                    visitedSpots.Add(tailLocations[8]);

                    printGridState();
                    Thread.Sleep(1);
                }

            }
            Console.WriteLine($"AANTAL BEZOCHTE PLEKKEN: {visitedSpots.Count()}");
        }

        private void printGridState()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);

                    if ((headerLocation.Item1 == i && headerLocation.Item2 == j))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("H");
                    }
                    else if ((tailLocation.Item1 == i && tailLocation.Item2 == j) || (tailLocations.Contains((i, j))))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("T");
                    }
                    else if (visitedSpots.Contains((i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
        }
    }
}
