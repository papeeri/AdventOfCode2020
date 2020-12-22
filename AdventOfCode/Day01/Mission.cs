using System;
using System.IO;

namespace AdventOfCode.Day01
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day01\input.txt");

            Part1(lines);
            Console.WriteLine("-----------------");
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            foreach (var outerLine in lines)
            {
                var x = Int32.Parse(outerLine);

                foreach (var innerLine in lines)
                {
                    var y = Int32.Parse(innerLine);

                    if (x + y == 2020)
                    {
                        Console.WriteLine("x: " + x);
                        Console.WriteLine("y: " + y);
                        Console.WriteLine("x*y: " + x * y);
                        return;
                    }
                }
            }
        }

        private static void Part2(string[] lines)
        {
            foreach (var lineX in lines)
            {
                var x = Int32.Parse(lineX);

                foreach (var lineY in lines)
                {
                    var y = Int32.Parse(lineY);

                    foreach (var lineZ in lines)
                    {
                        var z = Int32.Parse(lineZ);

                        if (x + y + z == 2020)
                        {
                            Console.WriteLine("x: " + x);
                            Console.WriteLine("y: " + y);
                            Console.WriteLine("z: " + z);
                            Console.WriteLine("x*y*z: " + x * y * z);
                            return;
                        }
                    }
                }
            }
        }
    }
}
