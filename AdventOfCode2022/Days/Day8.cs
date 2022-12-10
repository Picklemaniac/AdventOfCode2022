using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day8
    {
        private const string testfilePath = @"Inputs\TestInputs\day8test.txt";
        private const string filePath = @"Inputs\day8.txt";

        int[,] trees;

        HashSet<Tuple<int, int>> visTrees = new HashSet<Tuple<int, int>>();
        Tuple<int, int> bestSpot = new Tuple<int, int>(0, 0);
        public Day8()
        {
            string[] lines = File.ReadAllLines(filePath);
            trees = new int[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    trees[i, j] = int.Parse(lines[i][j].ToString());
                }
            }
        }

        public void SolvePuzzle1()
        {
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    //If this is an edge value, it's visible
                    if (i == 0 || i == trees.GetLength(0) - 1 || j == 0 || j == trees.GetLength(1) - 1)
                    {
                        visTrees.Add(new Tuple<int, int>(i, j));
                    }


                    // If edge value on top
                    if (i == 0)
                    {
                        int biggest = trees[i, j];
                        //Check all values down for visibility
                        for (int k = i + 1; k < trees.GetLength(0); k++)
                        {
                            if (trees[k, j] > biggest)
                            {
                                biggest = trees[k, j];
                                visTrees.Add(new Tuple<int, int>(k, j));
                            }
                        }
                    }

                    //If edge value on bottom
                    if (i == trees.GetLength(0) - 1)
                    {
                        int biggest = trees[i, j];

                        //Check all values up for visibility
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (trees[k, j] > biggest)
                            {
                                biggest = trees[k, j];
                                visTrees.Add(new Tuple<int, int>(k, j));
                            }
                        }
                    }

                    //If edge value on left
                    if (j == 0)
                    {
                        int biggest = trees[i, j];
                        //Check all values right for visibility
                        for (int k = j + 1; k < trees.GetLength(1); k++)
                        {
                            if (trees[i, k] > biggest)
                            {
                                biggest = trees[i, k];
                                visTrees.Add(new Tuple<int, int>(i, k));
                            }
                        }
                    }

                    //If edge value on right
                    if (j == trees.GetLength(1) - 1)
                    {
                        int biggest = trees[i, j];
                        //Check all values left for visibility
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (trees[i, k] > biggest)
                            {
                                biggest = trees[i, k];
                                visTrees.Add(new Tuple<int, int>(i, k));
                            }
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"-----------------------------------------");

            Console.WriteLine($"AANTAL ZICHTBARE BOMEN: {visTrees.Count}");
        }

        public void SolvePuzzle2()
        {
            int highestScenic = 0;

            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    if (i == 0 || i == trees.GetLength(0) - 1 || j == 0 || j == trees.GetLength(1) - 1)
                    {
                        continue;
                    }

                    //Tel omhoog
                    int up = 0;

                    for (int u = i - 1; u >= 0; u--)
                    {
                        up += 1;
                        if (trees[u, j] >= trees[i, j])
                        {
                            break;
                        }
                    }

                    //Tel beneden
                    int down = 0;
                    for (int d = i + 1; d < trees.GetLength(0); d++)
                    {
                        down += 1;
                        if (trees[d, j] >= trees[i, j])
                        {
                            break;
                        }
                    }

                    //Tel links
                    int left = 0;
                    for (int l = j - 1;l >= 0; l--)
                    {
                        left += 1;
                        if (trees[i, l] >= trees[i, j])
                        {
                            break;
                        }
                    }

                    //Tel rechts
                    int right = 0;
                    for (int r = j + 1; r < trees.GetLength(1); r++)
                    {
                        right += 1;
                        if (trees[i, r] >= trees[i, j])
                        {
                            break;
                        }
                    }

                    int scenic = up * left * right * down;

                    if (scenic > highestScenic)
                    {
                        highestScenic = scenic;
                        bestSpot = new Tuple<int, int>(i, j);
                    }
                }
            }

            printgrid();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"-----------------------------------------");

            Console.WriteLine($"BESTE PLEK SCORE: {highestScenic}");
        }

        private void printgrid()
        {
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    if (visTrees.Contains(new Tuple<int, int>(i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (bestSpot.Item1 == i && bestSpot.Item2 == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write(trees[i, j]);

                }
                Console.WriteLine();
            }
        }
    }
}
