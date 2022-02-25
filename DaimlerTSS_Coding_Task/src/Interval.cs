using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaimlerTSS_CodingTask
{
    /// <summary>
    /// Generic Interval which supports comparable types.\n
    /// It consists of one including lower and one including upper boundary
    /// </summary>
    /// <typeparam name="T">The generic type must be IComparable.</typeparam>
    class Interval<T> where T : IComparable
    {

        public Interval(T lowerBound, T upperBound) => (this.LowerBound, this.UpperBound) = (lowerBound, upperBound);

        /// <summary>
        /// Represents the including lower bound
        /// </summary>
        public T LowerBound { get;  set; }
        /// <summary>
        /// Represents the including upper bound
        /// </summary>
        public T UpperBound { get;  set; }

        /// <summary>
        /// Checks the Equality of this and the given Object(<see cref="Interval{T}"/>)
        /// </summary>
        /// <param name="obj">Must be another <see cref="Interval{T}"/> . Otherwise it returns 'False'.</param>
        /// <returns>Returns 'True' if <see cref="LowerBound"/> and <see cref="UpperBound"/> of <paramref name="obj"/> and this object are equal </returns>
        public override bool Equals(object obj)
        {
            if (obj is not Interval<T>)
                return false;

            Interval<T> interval = obj as Interval<T>;

            return LowerBound.CompareTo(interval.LowerBound) == 0 && UpperBound.CompareTo(interval.UpperBound) == 0 ? true : false;
        }

        /// <summary>
        /// Calculates the hash value of this <see cref="Interval{T}"/>. Is needed to call <see cref="Equals(object)"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return String.Format("{0}|{1}", LowerBound, UpperBound).GetHashCode();
        }

    }
}
