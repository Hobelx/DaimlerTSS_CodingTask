using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaimlerTSS_CodingTask
{
    class Interval<T> where T : IComparable
    {

        public Interval(T lowerBound, T upperBound) => (this.LowerBound, this.UpperBound) = (lowerBound, upperBound);


        public T LowerBound { get;  set; }
        public T UpperBound { get;  set; }


        public override bool Equals(object obj)
        {
            if (obj is not Interval<T>)
                return false;

            Interval<T> interval = obj as Interval<T>;

            return LowerBound.CompareTo(interval.LowerBound) == 0 && UpperBound.CompareTo(interval.UpperBound) == 0 ? true : false;
        }

        public override int GetHashCode()
        {
            return String.Format("{0}|{1}", LowerBound, UpperBound).GetHashCode();
        }

    }
}
