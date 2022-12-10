using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{

    public class Day3
    {
        private const string filePath = @"Inputs\day3.txt";
        private const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Dictionary<char, int> letterPriority = new Dictionary<char, int>();

        public Day3()
        {
            GetPriority();
        }

        private void GetPriority()
        {
            for (int i = 1; i <= alphabet.Length; i++)
            {
                letterPriority.Add(alphabet[i - 1], i);
            }
        }

        public void SolvePuzzle1()
        {
            List<string> firstCompartments = new List<string>();
            List<string> secondCompartments = new List<string>();

            foreach (string line in File.ReadLines(filePath))
            {
                firstCompartments.Add(line.Substring(0, line.Length / 2));
                secondCompartments.Add(line.Substring(line.Length / 2));
            }

            int sum = 0;

            for (int i = 0; i < firstCompartments.Count; i++)
            {
                var matchingCharacters = firstCompartments[i].Intersect(secondCompartments[i]);
                sum += letterPriority[matchingCharacters.First()];
            }
            Console.WriteLine(sum);
        }

        public void SolvePuzzle2()
        {
            List<string> allCompartments = new List<string>();

            foreach (string line in File.ReadLines(filePath))
            {
                allCompartments.Add(line);
            }

            int sum = 0;

            for (int i = 0; i < allCompartments.Count; i += 3)
            {
                var common = allCompartments[i].Intersect(allCompartments[i + 1]).Intersect(allCompartments[i + 2]);
                sum += letterPriority[common.First()];
            }

            Console.WriteLine(sum);
        }
    }
}
