using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day06
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day06\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            Part1(lines);
            Part2(lines);

        }

        private static void Part2(string[] lines)
        {
            var group = new Dictionary<int, List<string>>();
            int totalCount = 0;
            int person = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    AddGroupAllYesCount(group, ref totalCount);
                    group = new Dictionary<int, List<string>>();
                    person = 0;
                    continue;
                }

                group[person] = new List<string>();
                var lineArray = line.ToCharArray();
                foreach (char c in lineArray)
                {
                    group[person].Add(c.ToString());
                }

                person++;
            }

            AddGroupAllYesCount(group, ref totalCount);


            Console.WriteLine("Total all yes count: " + totalCount);
        }

        private static void AddGroupAllYesCount(Dictionary<int, List<string>> group, ref int totalCount)
        {
            var firstPersonAnswers = group[0];

            foreach (string firstPersonAnswer in firstPersonAnswers)
            {
                if (AllMembersAnsweredSame(group, firstPersonAnswer))
                {
                    totalCount++;
                }
            }
        }

        private static bool AllMembersAnsweredSame(Dictionary<int, List<string>> group, string firstPersonAnswer)
        {
            var persons = group.Keys;

            foreach (int person in persons)
            {
                if (group[person].Contains(firstPersonAnswer) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static void Part1(string[] lines)
        {
            var groupAnswers = new List<string>();
            int totalCount = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    AddGroupCount(ref groupAnswers, ref totalCount);
                    continue;
                }

                var lineArray = line.ToCharArray();
                foreach (char c in lineArray)
                {
                    groupAnswers.Add(c.ToString());
                }
            }

            AddGroupCount(ref groupAnswers, ref totalCount);

            Console.WriteLine("Total count: " + totalCount);
        }

        private static void AddGroupCount(ref List<string> groupAnswers, ref int totalCount)
        {
            var groupCount = groupAnswers.Distinct().Count();
            totalCount = totalCount + groupCount;

            groupAnswers = new List<string>();
        }
    }
}
