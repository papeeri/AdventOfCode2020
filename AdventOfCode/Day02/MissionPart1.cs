using System;
using System.IO;

namespace AdventOfCode.Day02
{
    public class MissionPart1
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

        private static bool IsValid(PasswordPolicy1 passwordPolicy)
        {
            int charCount = passwordPolicy.Password.Length - passwordPolicy.Password.Replace(passwordPolicy.Char, "").Length;

            if (charCount < passwordPolicy.Min)
            {
                return false;
            }

            if (charCount > passwordPolicy.Max)
            {
                return false;
            }

            return true;
        }

        private static PasswordPolicy1 ParseLine(string line)
        {
            var pass = new PasswordPolicy1();

            var split = line.Split();

            pass.Min = Int32.Parse( split[0].Split("-")[0]);
            pass.Max = Int32.Parse(split[0].Split("-")[1]);
            pass.Char = split[1].Replace(":", "");
            pass.Password = split[2];

            return pass;
        }
    }

    public class PasswordPolicy1
    {
        public int Min;
        public int Max;
        public string Char;
        public string Password;
    }
}
