using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day10\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            var intList = new List<int>();
            foreach (string line in lines)
            {
                intList.Add(int.Parse(line));
            }
            intList.Sort();

            Part1(intList);

        }

        private static void Part1(List<int> list)
        {
            int prev = 0;
            var d = new Dictionary<int, int> {{1, 0}, {2, 0}, {3, 0}};

            foreach (int x in list)
            {
                int diff = x - prev;

                Console.WriteLine("Value " + x + " Diff:" + diff);
                d[diff] = d[diff] + 1;
                prev = x;
            }

            d[3] = d[3] + 1;

            Console.WriteLine(d[1] * d[3]);
        }
    }
}
