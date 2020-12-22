using System;
using System.IO;

namespace AdventOfCode.Day03
{
    public class Mission
    {
        public static void Run()
        {
            // Right 1, down 1: 80
            // Right 3, down 1: 270
            // Right 5, down 1: 60
            // Right 7, down 1: 63
            // Right 1, down 2: 26

            var lines = File.ReadAllLines(@"Day03\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            int maxLength = lines[0].Length;
            int pos = 0;
            int trees = 0;
            int rowNumber = 0;

            foreach (var line in lines)
            {
                if (rowNumber % 2 != 0)
                {
                    rowNumber++;
                    continue;
                }
                rowNumber++;

                Console.WriteLine(line);

                Console.WriteLine(pos);
                Console.WriteLine(line[pos]);
                char charAtPos = line[pos];

                if (charAtPos == '#')
                {
                    trees++;
                }

                pos = pos + 1;
                if (pos >= maxLength)
                {
                    pos = pos - maxLength;
                }
            }

            Console.WriteLine("Total trees: " + trees);
        }
    }
}
