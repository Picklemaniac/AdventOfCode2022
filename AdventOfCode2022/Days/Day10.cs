using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day10
    {
        private const string testfilePath = @"Inputs\TestInputs\day10test.txt";
        private const string filePath = @"Inputs\day10.txt";

        private int cycles = 0;
        private int xValue = 1;
        private List<string> instructions = new List<string>();
        private int signalStrength = 0;
        private int rowSubtract = 0;

        public Day10()
        {
            instructions = File.ReadAllLines(filePath).ToList();
        }

        private void addCyclePart1()
        {
            cycles++;

            if ((cycles == 20 || cycles % 40 == 20) && cycles <= 220)
            {
                signalStrength += (cycles * xValue);
            }


            var position = (cycles - 1) - rowSubtract;

            //Draw pixel
            if (xValue == position || (xValue - 1) == position || (xValue + 1) == position)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("#");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
            }

            //Check for new row
            if (cycles % 40 == 0)
            {
                Console.WriteLine();
                rowSubtract += 40;
            }
        }

        public void SolvePuzzle1And2()
        {
            foreach (var item in instructions)
            {
                string[] full = item.Split(" ");
                string command = full[0];

                if (command == "noop")
                {
                    addCyclePart1();
                }

                if (command == "addx")
                {
                    addCyclePart1();
                    addCyclePart1();
                    xValue += int.Parse(full[1]);
                }
            }

            Console.WriteLine($"Signal Strength : {signalStrength}");
        }
    }
}