using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day04
{
    public class Mission
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(@"Day04\input.txt");
            Console.WriteLine("Total lines: " + lines.Length);

            var passports = new List<Passport>();
            var passport = new Passport();

            int validPassports = 0;
            int notValidPassports = 0;

            foreach (var line in lines)
            {
                //Console.WriteLine(line);

                if (line.Length == 0)
                {
                    passports.Add(passport);
                    passport = new Passport();
                    continue;
                }

                AddFieldsToPassport(line, passport);
            }
            passports.Add(passport);

            foreach (var p in passports)
            {
                if (IsValid(p))
                {
                    validPassports++;
                }
                else
                {
                    notValidPassports++;
                }
            }

            Console.WriteLine("Valid Passports: " + validPassports);
            Console.WriteLine("Not Valid Passports: " + notValidPassports);
        }

        private static bool IsValid(Passport passport)
        {
            if (!IsValidByr(passport.byr))
            {
                return false;
            }

            if (!IsValidIyr(passport.iyr))
            {
                return false;
            }

            if (!IsValidEyr(passport.eyr))
            {
                return false;
            }

            if (!IsValidHgt(passport.hgt))
            {
                return false;
            }

            if (!IsValidHcl(passport.hcl))
            {
                return false;
            }

            if (!IsValidEcl(passport.ecl))
            {
                return false;
            }

            if (!IsValidPid(passport.pid))
            {
                return false;
            }

            /*
            public string cid; // (Country ID)
             */

            return true;
        }

        private static bool IsValidPid(string value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Length != 9)
            {
                return false;
            }

            try
            {
                Int32.Parse(value);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool IsValidEcl(string value)
        {
            if (value == null)
            {
                return false;
            }

            if ((value == "amb" ||
                value == "blu" ||
                value == "brn" ||
                value == "gry" ||
                value == "grn" ||
                value == "hzl" ||
                value == "oth") == false)
            {
                return false;
            }
            
            return true;
        }

        private static bool IsValidHcl(string value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Length != 7 && value.Substring(0, 1) != "#")
            {
                return false;
            }

            Match match = Regex.Match(value.Substring(1, 6), @"^[a-zA-Z0-9_.-]*$");

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        private static bool IsValidHgt(string value)
        {
            if (value == null)
            {
                return false;
            }

            if ((value.Contains("cm") || value.Contains("in")) == false)
            {
                return false;
            }

            if (value.Contains("cm"))
            {
                try
                {
                    int height = Int32.Parse(value.Replace("cm", ""));

                    if (height < 150 || height > 193)
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

            if (value.Contains("in"))
            {
                try
                {
                    int height = Int32.Parse(value.Replace("in", ""));

                    if (height < 59 || height > 76)
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidByr(string value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Length != 4)
            {
                return false;
            }

            try
            {
                int year = Int32.Parse(value);
                if (year < 1920 || year > 2002)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool IsValidIyr(string value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Length != 4)
            {
                return false;
            }

            try
            {
                int year = Int32.Parse(value);
                if (year < 2010 || year > 2020)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static bool IsValidEyr(string value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Length != 4)
            {
                return false;
            }

            try
            {
                int year = Int32.Parse(value);
                if (year < 2020 || year > 2030)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static void AddFieldsToPassport(string line, Passport passport)
        {
            var split = line.Split();

            foreach (var post in split)
            {
                var keyValue = post.Split(":");
                var key = keyValue[0];
                var value = keyValue[1];

                switch (key)
                {
                    case "byr":
                        passport.byr = value;
                        break;
                    case "iyr":
                        passport.iyr = value;
                        break;
                    case "eyr":
                        passport.eyr = value;
                        break;
                    case "hgt":
                        passport.hgt = value;
                        break;
                    case "hcl":
                        passport.hcl = value;
                        break;
                    case "ecl":
                        passport.ecl = value;
                        break;
                    case "pid":
                        passport.pid = value;
                        break;
                    case "cid":
                        passport.cid = value;
                        break;
                }
            }
        }

        class Passport
        {
            public string byr; // (Birth Year)
            public string iyr; // Issue Year)
            public string eyr; // Expiration Year)
            public string hgt; // Height)
            public string hcl; // Hair Color)
            public string ecl; // Eye Color)
            public string pid; // Passport ID)
            public string cid; // (Country ID)
        }
    }
}
