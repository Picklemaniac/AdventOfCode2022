using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2022.Days
{
    public class Day7
    {
        private const string testfilePath = @"Inputs\TestInputs\day7test.txt";
        private const string filePath = @"Inputs\day7.txt";

        Dictionary<string, int> directorySizes = new Dictionary<string, int>();
        List<string> directories = new List<string>();


        public Day7()
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] command = line.Split();
                if (command[0] == "$")
                {
                    if (command[1] == "cd")
                    {
                        if (command[2] == "..")
                        {
                            directories = directories.GetRange(0, directories.Count - 1);
                        }
                        else if (command[2] == "/")
                        {
                            directories = new List<string> { "/" };
                        }
                        else
                        {
                            directories.Add(command[2]);
                        }
                    }
                }
                else
                {
                    if (command[0] != "dir")
                    {
                        string currentPath = "";
                        foreach (string folder in directories)
                        {
                            if (currentPath != "/" && folder != "/")
                            {
                                currentPath += "/";
                            }
                            currentPath += folder;
                            if (directorySizes.ContainsKey(currentPath))
                            {
                                directorySizes[currentPath] += int.Parse(command[0]);
                            }
                            else
                            {
                                directorySizes[currentPath] = int.Parse(command[0]);
                            }
                        }
                    }
                }
            }

        }

        public void SolvePuzzle1()
        {
            int sum = 0;
            foreach (var item in directorySizes)
            {
                if (item.Value <= 100000)
                {
                    sum += item.Value;
                }
            }

            Console.WriteLine($"Storage size sum: {sum}");
        }

        public void SolvePuzzle2()
        {
            int maxstorage = 70000000;
            int neededspace = 30000000;
            int totalspace = maxstorage - directorySizes["/"];

            var candidates = directorySizes.Where(item => item.Value >= neededspace - totalspace);

            Console.WriteLine($"Directory met minimale grootte: {candidates.Min(item => item.Value)}");
        }
    }
}
