using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day09\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            //Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            int sumToFind = 23278925;
            List<int> list= new List<int>();
            bool found = false;

            for (int x = 0; x < lines.Length - 1; x++)
            {
                list = new List<int>();
                list.Add(int.Parse(lines[x]));
                int sum = int.Parse(lines[x]);

                for (int y = x + 1; y < lines.Length; y++)
                {
                    list.Add(int.Parse(lines[y]));
                    sum = sum + int.Parse(lines[y]);

                    if (sum == sumToFind)
                    {
                        found = true;
                        break;
                    }

                    if (sum > sumToFind)
                    {
                        break;
                    }
                }

                if (found == true)
                {
                    break;
                }
            }

            int minValue = FindMinValue(list);
            int maxValue = FindMaxValue(list);

            Console.WriteLine(minValue+maxValue);
        }

        private static int FindMinValue(List<int> list)
        {
            int value = int.MaxValue;

            foreach (int i in list)
            {
                if (i < value)
                {
                    value = i;
                }
            }

            return value;
        }

        private static int FindMaxValue(List<int> list)
        {
            int value = int.MinValue;

            foreach (int i in list)
            {
                if (i > value)
                {
                    value = i;
                }
            }

            return value;
        }

        private static void Part1(string[] lines)
        {
            int preambleSize = 25;
            int min = 0;
            int max = preambleSize - 1;
            int current = max + 1;

            bool found = false;

            do
            {
                if (IsValidNextNumber(min, max, current, lines))
                {
                    min++;
                    max++;
                    current++;
                }
                else
                {
                    Console.WriteLine("Line: " + current + " Value: " + lines[current]);
                    found = true;
                }

            } while (current < lines.Length && found == false);
        }

        private static bool IsValidNextNumber(int min, int max, int current, string[] lines)
        {
            for (int x = min; x < max; x++)
            {
                for (int y = x + 1; y <= max; y++)
                {
                    if (int.Parse(lines[x]) + int.Parse(lines[y]) == int.Parse(lines[current]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
