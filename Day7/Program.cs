using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;


// https://adventofcode.com/2019/day/7
// Part1 = 289
// Part2 = 30055

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2();
        }

        public static List<string> bags = new List<string>();
        public static int bagCount = 0;

        static void Part1()
        {
            var st = new Stopwatch();
            st.Start();
            string targetBag = "shiny gold";

            bagUp(targetBag);

            Console.WriteLine(bags.Distinct().Count());
        }

        static void Part2()
        {
            var st = new Stopwatch();
            st.Start();
            string targetBag = "shiny gold";

            bagDown(targetBag, 1);

            //Console.WriteLine(bags.Distinct().Count());
            Console.WriteLine(bagCount);
            //32 test1
        }

        static void bagDown(string bag, int count)
        {
            //Console.WriteLine(bag);
            IEnumerable<string> lines = File.ReadLines("input.txt");
            foreach (var line in lines)
            {
                if (line.StartsWith(bag))
                {
                    foreach(var output in line.Split("contain ")[1].Split(", "))
                    {
                        if (!line.Contains("contain no other bags"))
                        {
                            var name = output.TrimStart(output.Split(" ")[0].ToCharArray()).TrimEnd(output.Split(" ")[output.Split(" ").Count() - 1].ToCharArray()).Trim();
                            int subCount = int.Parse(output.Split(" ")[0]);
                            Console.WriteLine(output + "\t" + count + " * " + subCount + " = " + subCount*count );
                            //bagCount = bagCount + count;
                            //bagDown(name);
                            int productBag = subCount * count;
                            bagCount = bagCount + productBag;
                            bagDown(name, productBag);
                        }
                    }
                }
            }
        }

        static void bagUp(string bag)
        {
            //Console.WriteLine(bag);
            IEnumerable<string> lines = File.ReadLines("input.txt");
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                var bagName = line.Split(bag + " bag")[0].Split(" bag")[0];
                if (line.Contains(bag) && bagName != "")
                {
                    bags.Add(bagName);
                    bagUp(bagName);
                }
            }
        }

    }
}
