using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day4
    {
        private const string filePath = @"Inputs\day4.txt";
        List<int[]> elf1Ranges = new List<int[]>();
        List<int[]> elf2Ranges = new List<int[]>();

        public Day4()
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] ranges = line.Split(',', 2);
                elf1Ranges.Add(new int[] { int.Parse(ranges[0].Split('-', 2)[0]), int.Parse(ranges[0].Split('-', 2)[1]) });
                elf2Ranges.Add(new int[] { int.Parse(ranges[1].Split('-', 2)[0]), int.Parse(ranges[1].Split('-', 2)[1]) });
            }
        }

        public void SolvePuzzle1()
        {
            int overlaps = 0;

            for (int i = 0; i < elf1Ranges.Count; i++)
            {
                var start1 = elf1Ranges[i][0];
                var end1 = elf1Ranges[i][1];
                var start2 = elf2Ranges[i][0];
                var end2 = elf2Ranges[i][1];

                if ((start1 <= start2 && end1 >= end2) || (start2 <= start1 && end2 >= end1))
                {
                    overlaps++;
                }
            }

            Console.WriteLine($"Overlaps: {overlaps}");
        }

        public void SolvePuzzle2()
        {
            int overlaps = 0;

            for (int i = 0; i < elf1Ranges.Count; i++)
            {
                var start1 = elf1Ranges[i][0];
                var end1 = elf1Ranges[i][1];
                var start2 = elf2Ranges[i][0];
                var end2 = elf2Ranges[i][1];

                if (!(end1 < start2 || start1 > end2))
                {
                    overlaps++;
                }
            }

            Console.WriteLine($"Overlaps: {overlaps}");
        }
    }
}
