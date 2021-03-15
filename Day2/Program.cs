using System;
using System.Linq;
using System.IO;
using System.Diagnostics;


// https://adventofcode.com/2019/day/2
// Part1 = 550
// Part2 = 634

namespace Day02
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

            var lines = File.ReadLines("input.txt");

            int i = 0;

            foreach (var line in lines)
            {
                var split = line.Split(" ");
                var lowRange = int.Parse(split[0].Split("-")[0]);
                var highRange = int.Parse(split[0].Split("-")[1]);
                char letter = char.Parse(split[1].Trim(':'));
                string password = split[2];

                int count = password.Count(f => (f == letter));

                if (lowRange <= count && count <= highRange)
                    i++;
            }
            st.Stop();
            Console.WriteLine("Stopwatch:" + st.Elapsed);

            Console.WriteLine(i);
            Environment.Exit(0);
        }

        static void Part2()
        { 
            var st = new Stopwatch();
            st.Start();

            var lines = File.ReadLines("input.txt");

            int i = 0;

            foreach (var line in lines)
            {
                var split = line.Split(" ");
                var lowRange = int.Parse(split[0].Split("-")[0])-1;
                var highRange = int.Parse(split[0].Split("-")[1])-1;
                var letter = split[1].Trim(':');
                string password = split[2];

                var lowValue = password.Substring(lowRange, 1);
                var highValue = password.Substring(highRange, 1);

                if ((lowValue == letter.ToString() || highValue == letter.ToString()) && highValue != lowValue)
                    i++;
            }

            st.Stop();
            Console.WriteLine("Stopwatch:" + st.Elapsed);

            Console.WriteLine(i);
            Environment.Exit(0);
        }

    }
}