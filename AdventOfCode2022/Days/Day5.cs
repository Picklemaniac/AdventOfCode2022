using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2022.Days
{
    public class Day5
    {
        private const string filePath = @"Inputs\day5.txt";

        List<Stack<char>> stacks = new List<Stack<char>>();

        IEnumerable<string> instructions = new List<string>();

        public Day5()
        {
            var temp = File.ReadLines(filePath).ToList();

            //Initialize stacks
            for (int i = 0; i < 9; i++)
            {
                Stack<char> stack = new Stack<char>();
                stacks.Add(stack);
            }

            //Fill the stacks
            for (int i = 7; i >= 0; i--)
            {
                var line = temp[i].TrimStart();

                Console.WriteLine(temp[i]);

                int charSpot = 1;

                for (int j = 0; j < 9; j++)
                {
                    // If something is at the spot, add to stack[j].
                    if (charSpot < line.Length && char.IsLetter(line[charSpot]))
                    {
                        stacks[j].Push(line[charSpot]);
                    }

                    charSpot += 4;
                }
            }

            //parse the instructions
            instructions = temp.Skip(10); 
        }

        public void SolvePuzzle1()
        {
            foreach (string line in instructions)
            {
                string[] words = line.Split(' ');

                int quantity = int.Parse(words[1]);
                int fromstack = int.Parse(words[3]);
                int todestination = int.Parse(words[5]);

                Stack<char> fromStackList = stacks[fromstack - 1];
                Stack<char> toStackList = stacks[todestination - 1];
                for (int i = 0; i < quantity; i++)
                {
                    toStackList.Push(fromStackList.Pop());
                }
            }

            foreach (var item in stacks)
            {
                Console.Write(item.Peek());
            }
        }

        public void SolvePuzzle2()
        {
            foreach (string line in instructions)
            {
                string[] words = line.Split(' ');

                int quantity = int.Parse(words[1]);
                int fromstack = int.Parse(words[3]);
                int todestination = int.Parse(words[5]);

                Stack<char> fromStackList = stacks[fromstack - 1];
                Stack<char> toStackList = stacks[todestination - 1];

                Stack<char> tempStack = new Stack<char>();

                //Save in reverse order
                for (int i = 0; i < quantity; i++)
                {
                    tempStack.Push(fromStackList.Pop());
                }

                //Add in normal order
                for (int i = 0; i < quantity; i++)
                {
                    toStackList.Push(tempStack.Pop());
                }
            }

            foreach (var item in stacks)
            {
                Console.Write(item.Peek());
            }
        }
    }
}
