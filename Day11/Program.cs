using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// https://adventofcode.com/2019/day/11
// Part1 = 2126
// Part2 =

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> lines = File.ReadLines("test3.txt");
            List<string> listLines = new List<string>();
            foreach (var line in lines)
                listLines.Add(line);
            Part1(listLines);
        }

        static void Part1(List<string> values)
        {
            int roundCount = 0;

            while (true)
            {
                int previousOccupiedCount = 0;
                int occupiedCount = 0;
                List<string> newLines = new List<string>();
                for (int row = 0; row < values.Count(); row++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int seat = 0; seat < values.ElementAt(row).Length; seat++)
                    {
                        char position = values.ElementAt(row)[seat];
                        if (Test2(values, position, row, seat))
                            if (position == 'L')
                                position = '#';
                            else
                                position = 'L';

                        if(position == '#')
                            occupiedCount++;
                        sb.Append(position);
                        //Console.Write(position);
                        //Console.Write(values.ElementAt(row)[seat]);
                    }
                    //Console.Write("\n");
                    newLines.Add(sb.ToString());
                }
                Console.Write("\n");
                roundCount++;
                Console.WriteLine("roundCount: " + roundCount);
                Console.WriteLine("occupiedCount: " + occupiedCount);
                if (previousOccupiedCount == occupiedCount)
                    Console.WriteLine();
                else
                    previousOccupiedCount = occupiedCount;
                Console.Write("\n\n");
                values = newLines;
            }
        }

        static bool Test(IEnumerable<string> values, char position, int row, int seat)
        {
            string N="", S ="", W ="", E ="", NE ="", NW ="", SE ="", SW ="";
            int adjacent = 1;
            bool check = true;

            switch (position)
            {
                case 'L':
                    if (row - adjacent >= 0)
                        N = values.ElementAt(row - adjacent)[seat].ToString();
                    if (row < values.Count() - 1)
                        S = values.ElementAt(row + adjacent)[seat].ToString();
                    if (seat - adjacent >= 0)
                        W = values.ElementAt(row)[seat - adjacent].ToString();
                    if (seat < values.ElementAt(row).Length - 1)
                        E = values.ElementAt(row)[seat + adjacent].ToString();
                    if (row - adjacent >= 0 && seat < values.ElementAt(row).Length - 1)
                        NE = values.ElementAt(row - adjacent)[seat + adjacent].ToString();
                    if (row < values.Count() - 1 && seat < values.ElementAt(row).Length - 1)
                        SE = values.ElementAt(row + adjacent)[seat + adjacent].ToString();
                    if (row - adjacent >= 0 && seat - adjacent >= 0)
                        NW = values.ElementAt(row - adjacent)[seat - adjacent].ToString();
                    if (row < values.Count() - 1 && seat - adjacent >= 0)
                        SW = values.ElementAt(row + adjacent)[seat - adjacent].ToString();

                    if (N == "#" || E == "#" || S == "#" || W == "#" || NE == "#" || SE == "#" || SW == "#" || NW == "#")
                        return false;
                    else return true;
                    break;
                case '#':
                    int occupiedCount = 0;
                    if (row - adjacent >= 0)
                        if(values.ElementAt(row - adjacent)[seat].ToString() == "#") //N
                            occupiedCount++;
                    if (row < values.Count() - 1)
                        if (values.ElementAt(row + adjacent)[seat].ToString() == "#") //S
                            occupiedCount++;
                    if (seat - adjacent >= 0)
                        if (values.ElementAt(row)[seat - adjacent].ToString() == "#") //W
                            occupiedCount++;
                    if (seat < values.ElementAt(row).Length - 1)
                        if (values.ElementAt(row)[seat + adjacent].ToString() == "#") //E
                            occupiedCount++;
                    if (row - adjacent >= 0 && seat < values.ElementAt(row).Length - 1)
                        if (values.ElementAt(row - adjacent)[seat + adjacent].ToString() == "#") //NE
                            occupiedCount++;
                    if (row < values.Count() - 1 && seat < values.ElementAt(row).Length - 1)
                        if (values.ElementAt(row + adjacent)[seat + adjacent].ToString() == "#") //SE
                            occupiedCount++;
                    if (row - adjacent >= 0 && seat - adjacent >= 0)
                        if (values.ElementAt(row - adjacent)[seat - adjacent].ToString() == "#") //NW
                            occupiedCount++;
                    if (row < values.Count() - 1 && seat - adjacent >= 0)
                        if (values.ElementAt(row + adjacent)[seat - adjacent].ToString() == "#") //SW
                            occupiedCount++;
                    if (occupiedCount >= 4)
                        return true;
                    else return false;
                    break;
                case '.':
                    return false;
                    break;
                //case 'A':
                //    if (row - adjacent >= 0)
                //        N = values.ElementAt(row - adjacent)[seat].ToString();
                //    if (row < values.Count() - 1)
                //        S = values.ElementAt(row + adjacent)[seat].ToString();
                //    if (seat - adjacent >= 0)
                //        W = values.ElementAt(row)[seat - adjacent].ToString();
                //    if (seat < values.ElementAt(row).Length - 1)
                //        E = values.ElementAt(row)[seat + adjacent].ToString();
                //    if (row - adjacent >= 0 && seat < values.ElementAt(row).Length - 1)
                //        NE = values.ElementAt(row - adjacent)[seat + adjacent].ToString();
                //    if (row < values.Count() - 1 && seat < values.ElementAt(row).Length - 1)
                //        SE = values.ElementAt(row + adjacent)[seat + adjacent].ToString();
                //    if (row - adjacent >= 0 && seat - adjacent >= 0)
                //        NW = values.ElementAt(row - adjacent)[seat - adjacent].ToString();
                //    if (row < values.Count() - 1 && seat - adjacent >= 0)
                //        SW = values.ElementAt(row + adjacent)[seat - adjacent].ToString();

                //    Console.WriteLine(NW.ToString()+N.ToString()+NE.ToString());
                //    Console.WriteLine(W.ToString() + position.ToString() + E.ToString());
                //    Console.WriteLine(SW.ToString() + S.ToString() + SE.ToString());
                //    break;

            }

            
            //int adjacent = 1;
            //try { N = values.ElementAt(row - adjacent)[seat]; } catch { }
            //try { S = values.ElementAt(row + adjacent)[seat]; } catch { }
            //try { E = values.ElementAt(row)[seat + adjacent]; } catch { }
            //try { W = values.ElementAt(row)[seat - adjacent]; } catch { }
            //try { NE = values.ElementAt(row - 1)[seat + adjacent]; } catch { }
            //try { NW = values.ElementAt(row - 1)[seat - adjacent]; } catch { }
            //try { SE = values.ElementAt(row + 1)[seat + adjacent]; } catch { }
            //try { SW = values.ElementAt(row + 1)[seat - adjacent]; } catch { }

            return check;
        }

        static bool Test2(IEnumerable<string> values, char position, int row, int seat)
        {
            string N = "", S = "", W = "", E = "", NE = "", NW = "", SE = "", SW = "";
            int adjacent = 1;
            bool check = true;

            switch (position)
            {
                case 'L':
                    if (row - adjacent >= 0)
                        N = values.ElementAt(row - adjacent)[seat].ToString();
                    if (row < values.Count() - 1)
                        S = values.ElementAt(row + adjacent)[seat].ToString();
                    if (seat - adjacent >= 0)
                        W = values.ElementAt(row)[seat - adjacent].ToString();
                    if (seat < values.ElementAt(row).Length - 1)
                        E = values.ElementAt(row)[seat + adjacent].ToString();
                    if (row - adjacent >= 0 && seat < values.ElementAt(row).Length - 1)
                        NE = values.ElementAt(row - adjacent)[seat + adjacent].ToString();
                    if (row < values.Count() - 1 && seat < values.ElementAt(row).Length - 1)
                        SE = values.ElementAt(row + adjacent)[seat + adjacent].ToString();
                    if (row - adjacent >= 0 && seat - adjacent >= 0)
                        NW = values.ElementAt(row - adjacent)[seat - adjacent].ToString();
                    if (row < values.Count() - 1 && seat - adjacent >= 0)
                        SW = values.ElementAt(row + adjacent)[seat - adjacent].ToString();

                    if (N == "#" || E == "#" || S == "#" || W == "#" || NE == "#" || SE == "#" || SW == "#" || NW == "#")
                        return false;
                    else return true;
                    break;
                case '#':
                    int occupiedCount = 0;
                    if (row - adjacent >= 0)
                        if (values.ElementAt(row - adjacent)[seat].ToString() == "#") //N
                            occupiedCount++;
                    if (row < values.Count() - 1)
                        if (values.ElementAt(row + adjacent)[seat].ToString() == "#") //S
                            occupiedCount++;
                    if (seat - adjacent >= 0)
                        if (values.ElementAt(row)[seat - adjacent].ToString() == "#") //W
                            occupiedCount++;
                    if (seat < values.ElementAt(row).Length - 1)
                        if (values.ElementAt(row)[seat + adjacent].ToString() == "#") //E
                            occupiedCount++;
                    if (row - adjacent >= 0 && seat < values.ElementAt(row).Length - 1)
                        if (values.ElementAt(row - adjacent)[seat + adjacent].ToString() == "#") //NE
                            occupiedCount++;
                    if (row < values.Count() - 1 && seat < values.ElementAt(row).Length - 1)
                        if (values.ElementAt(row + adjacent)[seat + adjacent].ToString() == "#") //SE
                            occupiedCount++;
                    if (row - adjacent >= 0 && seat - adjacent >= 0)
                        if (values.ElementAt(row - adjacent)[seat - adjacent].ToString() == "#") //NW
                            occupiedCount++;
                    if (row < values.Count() - 1 && seat - adjacent >= 0)
                        if (values.ElementAt(row + adjacent)[seat - adjacent].ToString() == "#") //SW
                            occupiedCount++;
                    if (occupiedCount >= 4)
                        return true;
                    else return false;
                    break;
                case '.':
                    return false;
                    break;
            }
            return check;
        }
    }
}
