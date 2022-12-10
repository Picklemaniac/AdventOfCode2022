using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day1
    {
        private const string filePath = @"Inputs\day1.txt";
        private List<int> caloriesPerElf = new List<int>();

        private void calculateElfCalories()
        {
            int sum = 0;

            foreach (string line in File.ReadLines(filePath))
            {

                if (string.IsNullOrWhiteSpace(line))
                {
                    caloriesPerElf.Add(sum);
                    sum = 0;
                    continue;
                }

                sum += int.Parse(line);
            }
        }

        public void SolvePuzzle1()
        {
            calculateElfCalories();
            Console.WriteLine(caloriesPerElf.Max());
        }

        public void SolvePuzzle2()
        {
            calculateElfCalories();
            Console.WriteLine(caloriesPerElf.OrderByDescending(x => x).Take(3).Sum());
        }
    }
}
