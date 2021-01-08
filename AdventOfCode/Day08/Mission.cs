using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day08
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day08\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            //Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            bool found = false;
            List<string> newLines;

            for (int i = 0; i < lines.Length; i++)
            {
                newLines = CloneList(lines);
                newLines[i] = ToggleJmpNop(newLines[i]);

                int index = 0;
                int accumulator = 0;
                var visitedIndexes = new List<int>();
                bool hit = false;

                do
                {
                    visitedIndexes.Add(index);
                    string line = newLines[index];
                    string instruction = line.Split(" ")[0];
                    int value = int.Parse(line.Split(" ")[1]);

                    switch (instruction)
                    {
                        case "jmp":
                            index = index + value;
                            break;
                        case "acc":
                            accumulator = accumulator + value;
                            index++;
                            break;
                        default:
                            index++;
                            break;
                    }

                    if (visitedIndexes.Contains(index))
                    {
                        //Console.WriteLine(accumulator);
                        hit = true;
                    }

                    if (index == lines.Length - 1)
                    {
                        hit = true;
                        found = true;
                        Console.WriteLine("Index: " + i);
                        Console.WriteLine("Old line: " + lines[i]);
                        Console.WriteLine("New line: " + newLines[i]);
                        Console.WriteLine("Accumulator: " + accumulator);
                    }

                } while (hit == false);

                if (found)
                {
                    break;
                }
            }
        }

        private static List<string> CloneList(string[] lines)
        {
            List<string> newLines = new List<string>();
            foreach (var line in lines)
            {
                newLines.Add(line);
            }

            return newLines;
        }

        private static string ToggleJmpNop(string line)
        {
            var split = line.Split(" ");

            if (split[0] == "jmp")
            {
                split[0] = "nop";
            }
            else if (split[0] == "nop")
            {
                split[0] = "jmp";
            }

            var newLine = string.Join(" ", split);
            return newLine;
        }

        private static void Part1(string[] lines)
        {
            int index = 0;
            int accumulator = 0;
            var visitedIndexes = new List<int>();
            bool hit = false;

            do
            {
                visitedIndexes.Add(index);
                string line = lines[index];
                string instruction = line.Split(" ")[0];
                int value = int.Parse(line.Split(" ")[1]);

                switch (instruction)
                {
                    case "jmp":
                        index = index + value;
                        break;
                    case "acc":
                        accumulator = accumulator + value;
                        index++;
                        break;
                    default:
                        index++;
                        break;
                }

                if (visitedIndexes.Contains(index))
                {
                    Console.WriteLine(accumulator);
                    hit = true;
                }

            } while (hit == false);
        }
    }
}
