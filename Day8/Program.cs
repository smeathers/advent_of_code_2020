using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


// https://adventofcode.com/2019/day/8
// Part1 = 1446
// Part2 = 1403 (line 254:jmp -128)

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            var lines = File.ReadLines("input.txt");
            runProgram(lines);
        }

        static void Part2()
        {
            var lines = File.ReadLines("input.txt");
            var problems = runProgram(lines);

            foreach (var problem in problems)
            {
                runProgram(lines, problem);
            }

        }

        static List<int> runProgram(IEnumerable<string> lines, int? swap = null)
        {
            var instructions = new List<int>();
            int accumulator = 0;
            int programCounter = 1;

            //foreach (var instruction in lines)
            for (int i = 0; i < lines.Count();)
            {
                string instruction = lines.ElementAt(i);
                string operation = instruction.Split(" ")[0];
                int argument = int.Parse(instruction.Split(" ")[1]);

                Console.WriteLine(programCounter + "\t" + (i + 1) + "\t" + instruction + " acc=" + accumulator);

                if (!instructions.Contains(i))
                {
                    instructions.Add(i);

                    if (!(swap is null) && swap == i)
                    {
                        switch (operation)
                        {
                            case "jmp":
                                operation = "nop";
                                break;
                            case "nop":
                                operation = "jmp";
                                break;
                        }
                    }

                        switch (operation)
                        {
                            case "acc":
                                accumulator = accumulator + argument;
                                i++;
                                break;
                            case "jmp":
                                i = i + argument;
                                break;
                            case "nop":
                                i++;
                                break;
                        }
                    }
                
                else
                {
                    Console.WriteLine("CRASH: acc:" + accumulator);
                    return instructions;
                }
                    programCounter++;
                }
                Console.WriteLine("HALT: acc:" + accumulator);
            Environment.Exit(0);
            return instructions;

        }


        static void Part2old()
        {
            var lines = File.ReadLines("input.txt");
            var instructions = new List<int>();
            int accumulator = 0;
            int programCounter = 1;

            //foreach (var instruction in lines)
            for (int i = 0; i < lines.Count();)
            {
                string instruction = lines.ElementAt(i);
                string operation = instruction.Split(" ")[0];
                int argument = int.Parse(instruction.Split(" ")[1]);

                Console.WriteLine((i + 1) + "\t" + instruction + " acc=" + accumulator);

                if (!instructions.Contains(i))
                {

                    instructions.Add(i);

                    switch (operation)
                    {
                        case "acc":
                            accumulator = accumulator + argument;
                            i++;
                            break;
                        case "jmp":
                            i = i + argument;
                            break;
                        case "nop":
                            i++;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("CRASH: acc:" + accumulator);
                    Environment.Exit(0);
                }
                programCounter++;
            }
            Console.WriteLine("HALT: acc:" + accumulator);
            Environment.Exit(0);

        }
    }
}
