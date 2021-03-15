using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


// https://adventofcode.com/2019/day/5
// Part1 = 
// Part2 = 

namespace Day05
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

            var text = File.ReadLines("input.txt");
            double seatMax = 0;

            foreach (var line in text)
            {
                double rowLow = 0, rowHigh = 127, seatLow = 0, seatHigh = 7, seatNumber = 0, seatLetter = 0;

                foreach (var letter in line)
                {
                    switch (letter)
                    {
                        case 'F':   //lower
                            rowHigh = Math.Floor(rowHigh - ((rowHigh - rowLow) / 2));
                            seatNumber = rowLow;
                            break;
                        case 'B':   //upper
                            rowLow = Math.Ceiling(rowHigh - ((rowHigh - rowLow) / 2));
                            seatNumber = rowHigh;
                            break;
                        case 'R':   //upper
                            seatLow = Math.Ceiling(seatHigh - ((seatHigh - seatLow) / 2));
                            seatLetter = seatHigh;
                            break;
                        case 'L':   //lower
                            seatHigh = Math.Floor(seatHigh - ((seatHigh - seatLow) / 2));
                            seatLetter = seatLow;
                            break;
                        default:
                            break;
                    }
                    //Console.WriteLine(letter + " Low: " + rowLow + "\tHigh: " + rowHigh + "\tLeft: " + seatLow + "\tRight: " + seatHigh);
                }
                double seatID = (seatNumber * 8) + seatLetter;
                Console.WriteLine("seatNumber: " + seatNumber +"\tseatLetter: " + seatLetter + "\t SeatID: " + seatID);
                if (seatID > seatMax)
                    seatMax = seatID;
            }
            Console.WriteLine("seatMax: " + seatMax);
        }

        static void Part2()
        {
            var st = new Stopwatch();
            st.Start();

            var text = File.ReadLines("input.txt");
            double seatMax = 0;
            var seats = new List<double>();

            foreach (var line in text)
            {
                double rowLow = 0, rowHigh = 127, seatLow = 0, seatHigh = 7, seatNumber = 0, seatLetter = 0;

                foreach (var letter in line)
                {
                    switch (letter)
                    {
                        case 'F':   //lower
                            rowHigh = Math.Floor(rowHigh - ((rowHigh - rowLow) / 2));
                            seatNumber = rowLow;
                            break;
                        case 'B':   //upper
                            rowLow = Math.Ceiling(rowHigh - ((rowHigh - rowLow) / 2));
                            seatNumber = rowHigh;
                            break;
                        case 'R':   //upper
                            seatLow = Math.Ceiling(seatHigh - ((seatHigh - seatLow) / 2));
                            seatLetter = seatHigh;
                            break;
                        case 'L':   //lower
                            seatHigh = Math.Floor(seatHigh - ((seatHigh - seatLow) / 2));
                            seatLetter = seatLow;
                            break;
                        default:
                            break;
                    }
                    //Console.WriteLine(letter + " Low: " + rowLow + "\tHigh: " + rowHigh + "\tLeft: " + seatLow + "\tRight: " + seatHigh);
                }
                double seatID = (seatNumber * 8) + seatLetter;
                seats.Add(seatID);
                Console.WriteLine("seatNumber: " + seatNumber + "\tseatLetter: " + seatLetter + "\t SeatID: " + seatID);
                if (seatID > seatMax)
                    seatMax = seatID;
            }
            Console.WriteLine("seatMax: " + seatMax);

            seats.Sort();

            double lastSeat = 0;

            foreach(var seat in seats)
            {
                if (seat-lastSeat != 1)
                    Console.WriteLine(seat);
                lastSeat = seat;
            }
        }

    }
}
