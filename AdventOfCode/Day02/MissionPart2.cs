using System;
using System.IO;

namespace AdventOfCode.Day02
{
    public class MissionPart2
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day02\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            int validCount = 0;
            int notValidCount = 0;

            foreach (var line in lines)
            {
                var passwordPolicy = ParseLine(line);
                bool valid = IsValid(passwordPolicy);

                if (valid)
                {
                    validCount++;
                }
                else
                {
                    notValidCount++;
                }
            }

            Console.WriteLine("Valid: " + validCount);
            Console.WriteLine("Not valid: " + notValidCount);
        }

        private static bool IsValid(PasswordPolicy2 passwordPolicy)
        {
            string charAtPos1 = passwordPolicy.Password.Substring(passwordPolicy.Position1 -1, 1);
            string charAtPos2 = passwordPolicy.Password.Substring(passwordPolicy.Position2 -1, 1);

            if (charAtPos1 == passwordPolicy.Char && charAtPos2 == passwordPolicy.Char)
            {
                return false;
            }

            if (charAtPos1 != passwordPolicy.Char && charAtPos2 != passwordPolicy.Char)
            {
                return false;
            }

            return true;
        }

        private static PasswordPolicy2 ParseLine(string line)
        {
            var pass = new PasswordPolicy2();

            var split = line.Split();

            pass.Position1 = Int32.Parse( split[0].Split("-")[0]);
            pass.Position2 = Int32.Parse(split[0].Split("-")[1]);
            pass.Char = split[1].Replace(":", "");
            pass.Password = split[2];

            return pass;
        }
    }

    public class PasswordPolicy2
    {
        public int Position1;
        public int Position2;
        public string Char;
        public string Password;
    }
}
