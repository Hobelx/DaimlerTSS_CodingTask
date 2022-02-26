using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using DaimlerTSS_CodingTask;

namespace DaimlerTSS_Coding_Task_Tests
{
    public class IntervalTests
    {
        int testLowerBound = 3;
        int testUpperBound = 10;
        [Fact]
        public void Interval_LowerBoundBiggerThanUpperBound()
        {
            Assert.Throws<ArgumentException>(() => new Interval<int>(testUpperBound, testLowerBound));
        }

        [Fact]
        public void Interval_SetUpperAndLowerBound()
        {
            Interval<int> interval = new Interval<int>(testLowerBound, testUpperBound);
            Assert.Equal(testUpperBound, interval.UpperBound);
            Assert.Equal(testLowerBound, interval.LowerBound);
        }

        [Fact]
        public void Interval_CheckEqualityOfIntervals()
        {
            var interval = new Interval<int>(testLowerBound, testUpperBound);
            Assert.True(interval.Equals(new Interval<int>(testLowerBound, testUpperBound)));
            Assert.False(interval.Equals(new Interval<int>(testLowerBound, testUpperBound + 1)));
        }
    }
}
