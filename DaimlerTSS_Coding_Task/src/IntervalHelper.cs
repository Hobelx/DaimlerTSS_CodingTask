using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaimlerTSS_CodingTask
{
    /// <summary>
    /// Provides cref="Interval{T}"/> helper functions.
    /// </summary>
    public class IntervalHelper
    {
        /// <summary>
        /// Merges overlapping <see cref="Interval{T}"/> from the given list and returns them as a new list of merged <see cref="Interval{T}"/>.
        /// \nExample: Input: [25,30] [2,19] [14, 23] [4,8]  Output: [2,23] [25,30]
        /// \nThrows <see cref="ArgumentNullException"/> if <paramref name="intervalList"/> is 'Null'
        /// </summary>
        /// <typeparam name="T">The generic type must be <see cref="IComparable"/>.</typeparam>
        /// <param name="intervalList">A list of <see cref="Interval{T}"/> which merge the overlaping <see cref="Interval{T}"/>. </param>
        /// <returns>Returns a new list of merged <see cref="Interval{T}"/>, based from the <paramref name="intervalList"/>.</returns>
        public static List<Interval<T>> Merge<T>(in List<Interval<T>> intervalList) where T : IComparable
        {
            if (intervalList == null)
                throw new ArgumentNullException();

            List<Interval<T>> listOfMergedIntervals = new List<Interval<T>>();

            //Goes throw the list and faces all Intervals to each other
            for(int i=0; i< intervalList.Count; i++)
            {
                Interval<T> nextInterval = intervalList[i];
                for (int ii=0; ii < intervalList.Count; ii++)
                {
                    //Makes no sense to compare with same element
                    if (i == ii)
                        continue;

                    var tmpInterval = MergeIntervals<T>(nextInterval, intervalList[ii]);

                    //If tmpInterval is not null then they do overlaps and the merged interval will be written to 'nextInterval'.
                    if (tmpInterval != null)
                        nextInterval = tmpInterval;


                }
                listOfMergedIntervals.Add(nextInterval);
            }
            
            //Deletes all double added Intervals in list and returns the result.
            return listOfMergedIntervals.Distinct().ToList();
        }

        /// <summary>
        /// Merges two <see cref="Interval{T}"/> if they do overlap to each other
        /// \nThrows <see cref="ArgumentNullException"/> if <paramref name="interval1"/> or <paramref name="interval2"/> is null
        /// </summary>
        /// <typeparam name="T">The generic type must be <see cref="IComparable"/>.</typeparam>
        /// <param name="interval1">Will be merged with the second interval</param>
        /// <param name="interval2">Will be merged with the first interval</param>
        /// <returns>If <paramref name="interval1"/> and <paramref name="interval2"/> are overlapping it returns a new <see cref="Interval{T}"/>. If not the it returns a 'Null-Reference'  </returns>
        public static Interval<T> MergeIntervals<T>(Interval<T> interval1, Interval<T> interval2) where T: IComparable
        {
            if (interval1 == null || interval2 == null)
                throw new ArgumentNullException();

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

        /// <summary>
        /// Checks whether two <see cref="Interval{T}"/> are overlapping. 
        /// \nOverlapping is True if the two following conditions are False:
        /// <list type="bullet">
        /// <item><description>Lower Bound of <paramref name="interval1"/> is bigger than Upper Bound of <paramref name="interval2"/></description></item>
        /// <item><description>Upper Bound of <paramref name="interval1"/> is smaller than Lower Bound of <paramref name="interval2"/></description></item>
        /// </list>
        /// \nThrows <see cref="ArgumentNullException"/> if <paramref name="interval1"/> or <paramref name="interval2"/> is null
        /// </summary>
        /// <typeparam name="T">The generic type must be <see cref="IComparable"/>.</typeparam>
        /// <param name="interval1">Is checked for overlapping with <paramref name="interval2"/>.</param>
        /// <param name="interval2">Is checked for overlapping with <paramref name="interval1"/>.</param>
        /// <returns>
        /// Returns 'True' if <paramref name="interval1"/> does overlaps with <paramref name="interval2"/>.\n
        /// Returns 'False' if <paramref name="interval1"/> does not overlaps with <paramref name="interval2"/>
        /// </returns>
        public static bool Overlaps<T>(Interval<T> interval1, Interval<T> interval2) where T: IComparable
        {
            if (interval1 == null || interval2 == null)
                throw new ArgumentNullException();
            return (interval1.LowerBound.CompareTo(interval2.UpperBound) == 1 || interval1.UpperBound.CompareTo(interval2.LowerBound) == -1) ? false : true;
        }
    }
}
