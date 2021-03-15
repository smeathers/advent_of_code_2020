using System;
using System.Linq;
using System.IO;
using System.Diagnostics;


// https://adventofcode.com/2019/day/1
// Part1 = 224436
// Part2 = 303394260

namespace Day01
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
            var nums = new int[lines.Count()];

            for (int i = 0; i < lines.Count(); i++)
            {
                nums[i] = int.Parse(lines.ElementAt(i));
            }

            for (int i = 0; i < nums.Count(); i++)
            {
                for (int j = 0; j < nums.Count(); j++)
                {
                    if (i != j)
                    {
                        var a = nums[i];
                        var b = nums[j];
                        var total = a + b;

                        if (total == 2020)
                        {
                            st.Stop();
                            Console.WriteLine("Stopwatch:" + st.Elapsed);

                            Console.WriteLine("WINNER!!");
                            Console.WriteLine("i=" + i + " value=" + a);
                            Console.WriteLine("j=" + j + " value=" + b);
                            Console.WriteLine("sum=" + total);
                            Console.WriteLine("product=" + (a*b));
                            Environment.Exit(0);
                        }
                    }
                    
                }
            }

        }

        static void Part2()
        {
            var lines = File.ReadLines("input.txt");

            var nums = new int[lines.Count()];

            for (int i = 0; i < lines.Count(); i++)
            {
                nums[i] = int.Parse(lines.ElementAt(i));
            }

            var st = new Stopwatch();
            st.Start();
            for (int i = 0; i < nums.Count(); i++)
            {
                for (int j = 0; j < nums.Count(); j++)
                {
                    for (int k = 0; k < nums.Count(); k++)
                    {

                        if (i != j && i != k && j != k)
                        {
                            //Console.WriteLine("Stopwatch:" + st.Elapsed);
                            var a = nums[i];
                            var b = nums[j];
                            var c = nums[k];
                            var total = a + b + c;

                            if (total == 2020)
                            {
                                st.Stop();
                                Console.WriteLine("Stopwatch:" + st.Elapsed);
                                Console.WriteLine("WINNER!!");
                                Console.WriteLine("i=" + i + " value=" + a);
                                Console.WriteLine("j=" + j + " value=" + b);
                                Console.WriteLine("k=" + k + " value=" + c);
                                Console.WriteLine("sum=" + total);
                                Console.WriteLine("product=" + (a * b * c));
                                Environment.Exit(0);
                            }
                        }
                    }

                }
            }
        }

    }
}
