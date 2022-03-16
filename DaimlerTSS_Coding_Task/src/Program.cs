﻿using System;
using System.Collections.Generic;
using DaimlerTSS_CodingTask;

namespace DaimlerTSS_Coding_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var listOfIntervals = new List<Interval<int>>();

            while (!exit)
            {
                Console.WriteLine("Current list of Intervals: { " + string.Join(", ", listOfIntervals) + " }");
                Console.WriteLine("1. Add new Interval to list");
                Console.WriteLine("2. Delete all Intervals");
                Console.WriteLine("3. Merge list of intervals");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Enter Number: ");
                

                var input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0: exit = true; break;
                    case 1:
                        Console.Write("Lower Bound: ");
                        var lowerBound = int.Parse(Console.ReadLine());
                        Console.Write("Upper Bound: ");
                        var upperBound = int.Parse(Console.ReadLine());
                        listOfIntervals.Add(new Interval<int>(lowerBound, upperBound));
                        break;
                    case 2:
                        listOfIntervals.Clear();
                        break;
                    case 3:
                        listOfIntervals = IntervalHelper.Merge(listOfIntervals);
                        break;
                    default: break;    
                }

                Console.WriteLine();
            }

            

        }
    }
}
