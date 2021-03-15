using System;
using System.IO;
using System.Linq;
using System.Diagnostics;


// https://adventofcode.com/2019/day/6
// Part1 = 6748
// Part2 = 3445

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            var st = new Stopwatch();
            st.Start();

            var text = File.ReadAllText("input.txt");
            var answerSets = text.Split("\n\n");
            int totalCount = 0;

            foreach (var answerSet in answerSets)
            {
                var count = answerSet.Replace("\n", null).Replace("\r", null).Distinct().ToArray().Count();
                totalCount = totalCount + count;
            }
            Console.WriteLine(totalCount);
        }

        static void Part2()
        {
            var st = new Stopwatch();
            st.Start();

            var text = File.ReadAllText("input.txt");
            var groupSets = text.Split("\n\n");
            int totalCount = 0;

            foreach (var groupSet in groupSets)
            {
                var questionSets = groupSet.Split("\n");
                string matchingQuestions = null;

                foreach (var questionSet in questionSets)
                {
                    Console.WriteLine(questionSet);
                    if (matchingQuestions == null)
                        matchingQuestions = questionSet;
                    else
                        matchingQuestions = String.Join(null, matchingQuestions.Intersect(questionSet));
                }

                var count = matchingQuestions.Count();
                totalCount = totalCount + count;
                //Console.WriteLine(matchingQuestions);
                //Console.WriteLine(count);
                //Console.WriteLine();
            }
            Console.WriteLine(totalCount);
        }
    }
}
