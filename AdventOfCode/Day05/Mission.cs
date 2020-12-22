using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day05
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day05\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            //PrintHeighetsSeatId(lines);

            var seatIds = new List<int>();
            foreach (var line in lines)
            {
                int seatId = GetSeatId(line);
                seatIds.Add(seatId);
            }

            seatIds.Sort();

            for (int i = 0; i < 930; i++)
            {
                if (!seatIds.Contains(i))
                {
                    Console.WriteLine("Missing seat: " + i);
                }
            }
        }

        private static void PrintHeighetsSeatId(string[] lines)
        {
            int highetsSeatId = 0;

            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                int seatId = GetSeatId(line);

                if (seatId > highetsSeatId)
                {
                    highetsSeatId = seatId;
                }
            }

            Console.WriteLine("Highets seat id: " + highetsSeatId);
        }

        private static int GetSeatId(string line)
        {
            int row = GetRow(line);
            int col = GetColumn(line);

            int seatId = row * 8 + col;

            return seatId;
        }

        private static int GetRow(string line)
        {
            string binaryString = GetBinaryString(line.Substring(0, 7));
            return Convert.ToInt32(binaryString, 2);
        }

        private static int GetColumn(string line)
        {
            string binaryString = GetBinaryString(line.Substring(7, 3));
            return Convert.ToInt32(binaryString, 2);
        }

        private static string GetBinaryString(string input)
        {
            string binaryString = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'F')
                {
                    binaryString = binaryString + "0";
                }

                if (input[i] == 'B')
                {
                    binaryString = binaryString + "1";
                }

                if (input[i] == 'L')
                {
                    binaryString = binaryString + "0";
                }

                if (input[i] == 'R')
                {
                    binaryString = binaryString + "1";
                }
            }

            return binaryString;
        }
    }
}
