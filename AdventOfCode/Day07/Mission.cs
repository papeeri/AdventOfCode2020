using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class Mission
    {
        private static List<string> _outerBagColors;
        private static int _containingBags;

        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day07\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            //Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            _containingBags = 0;
            AddContainingBags(lines, "shiny gold", 1);

            Console.WriteLine("Containing Bags: " + _containingBags);
        }

        private static void AddContainingBags(string[] lines, string bagColor, int parent)
        {
            foreach (string line in lines)
            {
                if (line.StartsWith(bagColor))
                {
                    if (line.Contains("no other bags"))
                    {
                        continue;
                    }

                    var containingBags = GetContainingBags(line);
                    foreach (string containingBag in containingBags)
                    {
                        int amount = GetAmount(containingBag);
                        string color = GetColor(containingBag);

                        _containingBags = _containingBags + amount * parent;
                        AddContainingBags(lines, color, amount * parent);
                    }
                }
            }
        }

        private static string GetColor(string containingBag)
        {
            var split = containingBag.Split(" ");
            string color = split[1] + " " + split[2];
            return color;
        }

        private static int GetAmount(string containingBag)
        {
            var split = containingBag.Split(" ");
            return int.Parse(split[0]);
        }

        private static string[] GetContainingBags(string line)
        {
            string[] containgBags = line.Split("contain ")[1].TrimEnd('.').Split(", ");
            return containgBags;
        }

        private static void Part1(string[] lines)
        {
            _outerBagColors = new List<string>();

            AddOuterBagColorForColor(lines, "shiny gold");

            _outerBagColors = _outerBagColors.Distinct().ToList();
            foreach (string outerBagColor in _outerBagColors)
            {
                Console.WriteLine(outerBagColor);
            }

            Console.WriteLine("Total count: " + _outerBagColors.Count);
        }

        private static void AddOuterBagColorForColor(string[] lines, string bagColor)
        {
            foreach (var line in lines)
            {
                if (line.Contains("no other bags"))
                {
                    continue;
                }

                if (line.Contains(bagColor))
                {
                    if (line.StartsWith(bagColor))
                    {
                        continue;
                    }

                    string outerBagColor = GetOuterBagColor(line);
                    _outerBagColors.Add(outerBagColor);
                    AddOuterBagColorForColor(lines, outerBagColor);
                }
            }
        }

        private static string GetOuterBagColor(string line)
        {
            var color = line.Split(" bags contain")[0];
            return color;
        }
    }
}
