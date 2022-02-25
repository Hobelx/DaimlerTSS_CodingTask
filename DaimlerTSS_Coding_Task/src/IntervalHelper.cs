using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaimlerTSS_CodingTask
{
    class IntervalHelper
    {
        public static List<Interval<T>> Merge<T>(List<Interval<T>> intervalList) where T : IComparable
        {
            List<Interval<T>> listOfMergedIntervals = new List<Interval<T>>();
            for(int i=0; i< intervalList.Count; i++)
            {
                Interval<T> nextInterval = intervalList[i];
                for (int ii=0; ii < intervalList.Count; ii++)
                {
                    if (i == ii)
                        continue;

                    var tmpInterval = MergeIntervals<T>(nextInterval, intervalList[ii]);
                    if (tmpInterval != null)
                        nextInterval = tmpInterval;


                }
                listOfMergedIntervals.Add(nextInterval);
            }
            
            return listOfMergedIntervals.Distinct().ToList();
        }
        public static Interval<T> MergeIntervals<T>(Interval<T> interval1, Interval<T> interval2) where T: IComparable
        {
            if (Overlaps(interval1, interval2))
            {
                
                T upperBound = new List<T> { interval1.UpperBound, interval2.UpperBound }.Max();
                T lowerBound = new List<T> { interval1.LowerBound, interval2.LowerBound }.Min();

                return new Interval<T>(lowerBound, upperBound); ;
            }
            else
            {
                return null;
            }

        }

        public static bool Overlaps<T>(Interval<T> interval1, Interval<T> interval2) where T: IComparable
        {
            return (interval1.LowerBound.CompareTo(interval2.UpperBound) == 1 || interval1.UpperBound.CompareTo(interval2.LowerBound) == -1) ? false : true;
        }
    }
}
