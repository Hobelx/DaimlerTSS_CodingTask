using System;
using System.Collections.Generic;
using DaimlerTSS_CodingTask;

namespace DaimlerTSS_Coding_Task
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Interval<int>> listOfIntervals = new List<Interval<int>> { new Interval<int>(25, 30), new Interval<int>(2, 19), new Interval<int>(14, 23), new Interval<int>(4, 8) };

            foreach (Interval<int> interval in listOfIntervals)
            {
                //Console.WriteLine("LowerBound: " + interval.LowerBound);
                //Console.WriteLine("UpperBound: " + interval.UpperBound);
                //Console.WriteLine();
            }

            List<Interval<int>> listOfMergedIntervals = IntervalHelper.Merge(listOfIntervals);


            foreach (Interval<int> interval in listOfMergedIntervals)
            {
                Console.WriteLine("LowerBound: " + interval.LowerBound);
                Console.WriteLine("UpperBound: " + interval.UpperBound);
                Console.WriteLine(IntervalHelper.Overlaps<int>(new Interval<int>(2, 7), new Interval<int>(4, 10)));
            }

        }
    }
}
