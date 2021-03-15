using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


// https://adventofcode.com/2019/day/10
// Part1 = 2346
// Part2 = 

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("test.txt");
            List<int> intLines = new List<int>();

            foreach (var line in lines)
                intLines.Add(int.Parse(line));
            intLines.Sort();

            List<int> intLines2 = new List<int>();
            intLines2.Add(1);
            intLines2.Add(19);
            Part2(intLines);
        }


        static int Part2(List<int> values)
        {
            int correctCount = 0;

            int finalValue = values.Max();
            var maxTry = Math.Pow(2, values.Count());
            List<string> previousAttempts = new List<string>();
            List<string> correctAttempts = new List<string>();
            for (int i = 1; i < maxTry; i++)
            {
                string binary = Convert.ToString(i, 2).TrimEnd('0');
                if (!previousAttempts.Contains(binary))
                {
                    previousAttempts.Add(binary);
                    List<int> test = new List<int>();
                    int pos = 0;
                    foreach (var item in binary.ToArray())
                    {
                        if (item == '1')
                            test.Add(values.ElementAt(pos));
                        pos++;
                    }
                    if (Part1(test) == finalValue)
                    {
                        correctCount++;
                    }
                }
            }
            Console.WriteLine(correctCount);
            return correctCount;
        }

        static int Part2backup(List<int> values)
        {
            int correctCount = 0;
            
            int finalValue = values.Max();
            var maxTry = Math.Pow(2, values.Count());
            List<string> previousAttempts = new List<string>();
            List<string> correctAttempts = new List<string>();
            for (int i=1; i<maxTry; i++)
            {
                string binary = Convert.ToString(i, 2).TrimEnd('0');
                if (!previousAttempts.Contains(binary))
                {
                    previousAttempts.Add(binary);
                    List<int> test = new List<int>();
                    int pos = 0;
                    foreach (var item in binary.ToArray())
                    {
                        if (item == '1')
                            test.Add(values.ElementAt(pos));
                        pos++;
                    }
                    if (Part1(test) == finalValue)
                    {
                        correctCount++;
                    }
                }
            }
            Console.WriteLine(correctCount);
            return correctCount;
        }

        static int Part1(List<int> values)
        {
            int previousAdapter = 0;
            int singleJolt = 0;
            int threeJolt = 1;
            bool pass = true;

            foreach(var adapter in values)
            {
                int joltDiff = Math.Abs(previousAdapter - adapter);
                if (joltDiff <= 3)
                {
                    if (joltDiff == 1)
                        singleJolt++;
                    if (joltDiff == 3)
                        threeJolt++;
                }
                else
                    pass = false;

                previousAdapter = adapter;
            }
            //Console.WriteLine("1Jolt:  " + singleJolt);
            //Console.WriteLine("3Jolts: " + threeJolt);
            //Console.WriteLine("Answer: " + (singleJolt*threeJolt));
            if (pass)
                return previousAdapter;
            else
                return 0;
        }

        static int test(List<int> values)
        {
            int previousAdapter = 0;
            int singleJolt = 0;
            int threeJolt = 1;
            bool pass = true;

            foreach (var adapter in values)
            {
                int joltDiff = Math.Abs(previousAdapter - adapter);
                if (joltDiff <= 3)
                {
                    if (joltDiff == 1)
                        singleJolt++;
                    if (joltDiff == 3)
                        threeJolt++;
                }
                else
                    pass = false;

                previousAdapter = adapter;
            }
            Console.WriteLine("1Jolt:  " + singleJolt);
            Console.WriteLine("3Jolts: " + threeJolt);
            Console.WriteLine("Answer: " + (singleJolt * threeJolt));
            if (pass)
                return previousAdapter;
            else
                return 0;
        }

        static void Part2fail()
        {
            var lines = File.ReadLines("test.txt");
            List<int> intLines = new List<int>();

            //intLines.Add(0);
            foreach (var line in lines)
                intLines.Add(int.Parse(line));

            intLines.Sort();

            List<int> diffLines = new List<int>();
            List<int> count1s = new List<int>();
            List<string> diffs = new List<string>();
            List<int> diffCounts = new List<int>();
            int previousAdapter = 0;
            int adapterCombos = 0;
            int jolt1 = 0;
            int jolt3 = 1;
            int count1 = 0;
            
            foreach (var adapter in intLines)
            {
                int joltDiff = Math.Abs(previousAdapter - adapter);
                if (joltDiff <= 3)
                {
                    if (joltDiff == 1)
                    {
                        jolt1++;
                        diffLines.Add(1);
                        diffs.Add(adapter + "+1");
                        count1++;
                    }
                    if (joltDiff == 3)
                    {
                        jolt3++;
                        diffLines.Add(3);
                        diffs.Add(adapter + "+3");
                        if (count1 != 0)
                        {
                            switch(count1)
                            { 
                                case 1:
                                    diffCounts.Add(2);
                                    break;
                                case 2:
                                    diffCounts.Add(4);
                                    break;
                                case 3:
                                    diffCounts.Add(5);
                                    break;
                                case 4:
                                    diffCounts.Add(11);
                                    break;
                            }
                            count1s.Add(count1);
                            count1 = 0;
                        }
                    }
                }
                else
                    Console.WriteLine(adapter);

                previousAdapter = adapter;
            }

            if (intLines.Max() + 3 == previousAdapter + 3)
                adapterCombos++;


            foreach(var diff in diffLines)
            {

            }

            Console.WriteLine("Max  : " + (previousAdapter+3));
            Console.WriteLine("1Jolt:  " + jolt1);
            Console.WriteLine("3Jolts: " + jolt3);
            Console.WriteLine("old Answer: " + (jolt1 * jolt3));
            Console.WriteLine("Looking for: 8");
        }
    }
}
