using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day2
    {
        private const string filePath = @"Inputs\day2.txt";
        private List<int> elfInputs = new List<int>();
        private List<int> selfInputs = new List<int>();

        public Day2()
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] words = line.Split(' ');
                elfInputs.Add(priority(words[0]));
                selfInputs.Add(priority(words[1]));
            }
        }

        public int priority(string letter)
        {
            if (letter == "A" || letter == "X") return 1;
            if (letter == "B" || letter == "Y") return 2;
            if (letter == "C" || letter == "Z") return 3;
            return -1;
        }

        public int GetLosingNumber(int number) 
        {
            if (number == 1) return 3;
            if (number == 2) return 1;
            if (number == 3) return 2;
            return -1;
        }

        public int GetWinningNumber(int number)
        {
            if (number == 1) return 2;
            if (number == 2) return 3;
            if (number == 3) return 1;
            return -1;
        }

        public void SolvePuzzle1()
        {
            int score = 0;

            for (int i = 0; i < selfInputs.Count; i++)
            {
                var elfChoice = elfInputs[i];
                var selfChoice = selfInputs[i];

                //Draw
                if (elfChoice == selfChoice)
                {
                    score += 3;
                }

                //Win
                if (selfChoice == 1 && elfChoice == 3
                    || selfChoice == 3 && elfChoice == 2
                    || selfChoice == 2 && elfChoice == 1)
                {
                    score += 6;
                }

                score += selfChoice;
            }

            Console.WriteLine(score);
        }

        public void SolvePuzzle2()
        {
            int score = 0;

            for (int i = 0; i < elfInputs.Count; i++)
            {
                int choice = 0;

                //If self input = 1 lose
                if (selfInputs[i] == 1)
                {
                    choice = GetLosingNumber(elfInputs[i]);
                }

                //If self input = 2 draw
                if (selfInputs[i] == 2)
                {
                    choice = elfInputs[i];
                    score += 3;
                }

                //If self input = 3 win
                if (selfInputs[i] == 3)
                {
                    choice = GetWinningNumber(elfInputs[i]);
                    score += 6;
                }

                score += choice;
            }

            Console.WriteLine(score);
        }
    }
}
