using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;


// https://adventofcode.com/2020/day/4
// Part1 = 228
// Part2 = 1478615040

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2();
        }

        static void Part1()
        {
            var st = new Stopwatch();
            st.Start();

            var text = File.ReadAllText("input.txt");
            var rawPassports = text.Split("\n\n");
            var passports = new List<Passport>();
            string[] passportItems = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };//, "cid" };
            var validCount = 0;

            foreach (var rawPassport in rawPassports)
            {

                // new idea.  rawPassport.Contains(strings we're looking for...)
                bool check = true;
                foreach (var item in passportItems)
                {
                    if (!rawPassport.Contains(item))
                    {
                        check = false;
                        break;
                    }
                }

                if (check == true)
                    validCount++;

                //Passport p = new Passport();

                //// notes - split values out by whitespace then by : to get key value pairs

                //var rawPassportItems = rawPassport.Split(" ");
                ////rawPassportItems = rawPassportItems.Split("\n");

                //// notes - populate the p Passport object

            }
            Console.WriteLine(validCount);
        }

        static void Part2()
        {
            var st = new Stopwatch();
            st.Start();

            var text = File.ReadAllText("valid.txt");
            var rawPassports = text.Split("\n\n");
            string[] passportItems = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };//, "cid" };
            string[] eyeColor = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var validCount = 0;

            foreach (var rawPassport in rawPassports)
            {
                bool check = true;

                foreach (var item in passportItems)
                {
                    //if (rawPassport.Split(item).Length - 1 > 1)
                    //{
                    //    check = false;
                    //    break;
                    //}
                    if (!rawPassport.Contains(item))
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    //Console.WriteLine("    " + rawPassport.Replace("\n", " ").Trim().Split(" ").Count());
                    foreach (var item in rawPassport.Replace("\n", " ").Trim().Split(" "))
                    {
                        //Console.WriteLine(item);
                        var field = item.Split(":")[0];
                        var value = item.Split(":")[1];

                        Regex r = new Regex("");

                        switch (field)
                        {
                            case "byr": //(Birth Year) - four digits; at least 1920 and at most 2002.
                                check = (1920 <= int.Parse(value) && int.Parse(value) <= 2002);
                                Console.WriteLine(field);
                                break;
                            case "iyr": //(Issue Year) - four digits; at least 2010 and at most 2020.
                                check = (2010 <= int.Parse(value) && int.Parse(value) <= 2020);
                                break;
                            case "eyr": //(Expiration Year) - four digits; at least 2020 and at most 2030.
                                check = (2020 <= int.Parse(value) && int.Parse(value) <= 2030);
                                break;
                            case "hgt": //(Height) - a number followed by either cm or in:
                                check = (int.TryParse(value.Substring(0, value.Length - 2), out int num) &&
                                    (value.EndsWith("cm") && 150 <= int.Parse(value.Substring(0, value.Length - 2)) && 193 >= int.Parse(value.Substring(0, value.Length - 2))) ||
                                    (value.EndsWith("in") && 59 <= int.Parse(value.Substring(0, value.Length - 2)) && 76 >= int.Parse(value.Substring(0, value.Length - 2))));
                                break;
                            case "hcl": //(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                                r = new Regex("^#([a-fA-F0-9]{6}|[a-f0-9]{3})");
                                check = r.IsMatch(value);
                                if (check) Console.WriteLine(item);
                                break;
                            case "ecl": //(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                                check = eyeColor.Contains(value);
                                break;
                            case "pid": //(Passport ID) - a nine-digit number, including leading zeroes.
                                r = new Regex(@"^[0-9]{9}$");
                                check = r.IsMatch(value);
                                break;
                            case "cid":
                                check = true;
                                break;
                            default:
                                check = false;
                                break;
                        }
                        //if (!check) Console.WriteLine(item);
                        if (!check)
                            break;
                    }
                }
                if (check)
                    validCount++;
                
            }
            Console.WriteLine(validCount);
        }
    }

    class Passport
    {
        int byr { get; set; } //(Birth Year)
        int iyr { get; set; } //(Issue Year)
        int eyr { get; set; } //(Expiration Year)
        int hgt { get; set; } //(Height)
        string hcl { get; set; } //(Hair Color)
        string ecl { get; set; } //(Eye Color)
        string pid { get; set; } //(Passport ID)
        string cid { get; set; } //(Country ID)
    }

}
