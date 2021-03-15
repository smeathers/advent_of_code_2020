using System;
using System.Linq;
using System.IO;
using System.Diagnostics;


// https://adventofcode.com/2019/day/3
// Part1 = 191
// Part2 = 1478615040

namespace Day03
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

            int treeCount = 0;
            int x = 0;

            foreach (var line in lines)
            {
                int mapLength = line.Count();
                    if (x >= mapLength)
                        x -= mapLength;
                    var target = line.Substring(x, 1);
                    if (target == "#")
                        treeCount++;
                x += 3;
            }

            st.Stop();
            Console.WriteLine("Stopwatch:" + st.Elapsed);

            Console.WriteLine("Tree Count: " + treeCount);
            Environment.Exit(0);

        }

        static void Part2()
        {
            var st = new Stopwatch();
            st.Start();

            var product = navigate(1, 1) * navigate(3, 1) * navigate(5, 1) * navigate(7, 1) * navigate(1, 2);
            
            st.Stop();
            Console.WriteLine("Stopwatch:" + st.Elapsed);

            Console.WriteLine(product);
            Environment.Exit(0);
        }

        static long navigate(int xSize, int ySize)
        { 
            var lines = File.ReadLines("input.txt");

            long treeCount = 0;
            int x = 0;

            for (int y = 0; y < lines.Count(); y+=ySize)
            {
                int mapLength = lines.ElementAt(y).Count();
                if (x >= mapLength)
                    x -= mapLength;
                var target = lines.ElementAt(y).Substring(x, 1);
                if (target == "#")
                    treeCount++;
                x += xSize;
            }
            Console.WriteLine(treeCount);
            return treeCount;
        }

    }
}
