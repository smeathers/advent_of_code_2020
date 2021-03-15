using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


// https://adventofcode.com/2019/day/9
// Part1 = 36845998
// Part2 = 

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2(36845998);
        }

        static void Part2(int answer)
        {
            var lines = File.ReadLines("input.txt");
            for (int i = 0; i < lines.Count(); i++)
            {
                int sum = int.Parse(lines.ElementAt(i));
                var values = new List<int>();
                values.Add(int.Parse(lines.ElementAt(i)));

                for (int j = i+1; j < lines.Count(); j++)
                {
                    var value = int.Parse(lines.ElementAt(j));
                    sum = sum + value;
                    values.Add(value);
                    if (sum == answer)
                    {
                        Console.WriteLine("Done!");
                        values.Sort();
                        Console.WriteLine(values.First());
                        Console.WriteLine(values.Last());
                        Console.WriteLine("\n" + (values.First() + values.Last()));
                        Environment.Exit(0);
                    }
                    if (sum > answer)
                        break;
                }
            }

        }

        static void Part1()
        {
            int preambleSize = 25;

            var lines = File.ReadLines("input.txt");

            for (int i = preambleSize; i < lines.Count(); i++)
            {
                var preambleValues = new List<int>();
                var answer = int.Parse(lines.ElementAt(i));

                for (int j = i-1; j >= i-preambleSize; j--)
                {
                    var value = int.Parse(lines.ElementAt(j));
                    preambleValues.Add(value);
                }
                
                if (!Check(answer, preambleValues))
                    Console.WriteLine(i + ":\t" + lines.ElementAt(i));
            }

        }

        static bool Check(int answer, List<int> preambleValues)
        {
            // a + b = answer?
            foreach (var a in preambleValues)
                foreach (var b in preambleValues)
                    if (a != b)
                        if (a + b == answer)
                            return true;
            return false;
        }
    }
}
