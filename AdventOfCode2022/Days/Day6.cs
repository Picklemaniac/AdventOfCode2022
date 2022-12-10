using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{

    public class Day6
    {
        private string signal = File.ReadAllLines(@"Inputs\day6.txt")[0];

        public void SolvePuzzle1()
        {
            var queue = new Queue<char>();

            for (int i = 0; i < signal.Length; i++)
            {
                queue.Enqueue(signal[i]);
                if (queue.Count > 4) queue.Dequeue();

                if (queue.Count == 4 && !HasDoubleCharacters(queue))
                {
                    Console.WriteLine($"Position {i + 1}");
                    break;
                }
            }
        }

        public void SolvePuzzle2()
        {
            var queue = new Queue<char>();

            for (int i = 0; i < signal.Length; i++)
            {
                queue.Enqueue(signal[i]);
                if (queue.Count > 14) queue.Dequeue();

                if (queue.Count == 14 && !HasDoubleCharacters(queue))
                {
                    Console.WriteLine($"Position {i + 1}");
                    break;
                }
            }
        }

        public bool HasDoubleCharacters(Queue<char> queue)
        {
            HashSet<char> set = new HashSet<char>();

            foreach (char item in queue)
            {
                if (set.Contains(item))
                {
                    return true;
                }

                set.Add(item);
            }

            return false;
        }
    }
}
