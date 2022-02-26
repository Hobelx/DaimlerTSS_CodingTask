using DaimlerTSS_CodingTask;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace DaimlerTSS_Coding_Task_Tests
{
    public class IntervalHelperTests
    {
        

        //#Set01 for testing
        List<Interval<int>> listOfIntervals01 = new List<Interval<int>> { new Interval<int>(25, 30), new Interval<int>(2, 19), new Interval<int>(14, 23), new Interval<int>(4, 8) };
        List<Interval<int>> expectedResult01 = new List<Interval<int>> { new Interval<int>(2, 23), new Interval<int>(25, 30) };

        //#Set02 for testing
        List<Interval<int>> listOfIntervals02 = new List<Interval<int>> { new Interval<int>(-12, 10), new Interval<int>(-20, 8), new Interval<int>(70, 90), new Interval<int>(77, 88) };
        List<Interval<int>> expectedResult02 = new List<Interval<int>> { new Interval<int>(-20, 10), new Interval<int>(70, 90) };

        
        List<List<Interval<int>>> Set_listOfInterval = new List<List<Interval<int>>>();
        List<List<Interval<int>>> Set_expectedResult= new List<List<Interval<int>>>();

        public IntervalHelperTests()
        {
            Set_listOfInterval.Add(listOfIntervals01);
            Set_listOfInterval.Add(listOfIntervals02);

            Set_expectedResult.Add(expectedResult01);
            Set_expectedResult.Add(expectedResult02);

            
        }

        [Fact]
        public void Overlap_PassNullReference()
        {
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.Overlaps<int>(null, null));
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.Overlaps<int>(null, new Interval<int>(2, 10)));
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.Overlaps<int>(new Interval<int>(2, 10), null));
            
        }
        [Fact]
        public void Overlap_IntervalInsideOtherInterval()
        {
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(1, 10), new Interval<int>(2,4)));
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(2, 4), new Interval<int>(1, 10)));

            
        }
        [Fact]
        public void Overlap_IntervalOverlapsOtherInterval()
        {
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(1, 10), new Interval<int>(8, 12)));
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(8, 12), new Interval<int>(1, 10)));
        }

        [Fact]
        public void MergeInterval_IntervalOverlapsOtherInterval()
        {
            Assert.Equal(new Interval<int>(2, 10), IntervalHelper.MergeIntervals<int>(new Interval<int>(5, 10), new Interval<int>(2 , 5)));
            Assert.Equal(new Interval<int>(2, 10), IntervalHelper.MergeIntervals<int>(new Interval<int>(2, 5), new Interval<int>(5, 10)));
        }
        
        [Fact]
        public void MergeInterval_IntervalInsideOtherInterval()
        {
            Assert.Equal(new Interval<int>(5, 10), IntervalHelper.MergeIntervals<int>(new Interval<int>(5, 10), new Interval<int>(6, 8)));
            Assert.Equal(new Interval<int>(5, 10), IntervalHelper.MergeIntervals<int>(new Interval<int>(6, 8), new Interval<int>(5, 10)));
        }
        [Fact]
        public void MergeInterval_IntervalOutsideOtherInterval()
        {
            Assert.Equal(null, IntervalHelper.MergeIntervals<int>(new Interval<int>(5, 10), new Interval<int>(14, 20)));
        }

        [Fact]
        public void MergeInterval_NullIntervals()
        {
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.MergeIntervals<int>(null, null));
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.MergeIntervals<int>(null, new Interval<int>(2, 10)));
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.MergeIntervals<int>(new Interval<int>(2, 10), null));
        }

        [Fact]
        public void Merge_ListNullReference()
        {   
            Assert.Throws<ArgumentNullException>(() => IntervalHelper.Merge<int>(null));
        }

        

        [Fact]
        public void Merge_ListCountZero()
        {
            Assert.Equal(new List<Interval<int>>(), IntervalHelper.Merge<int>(new List<Interval<int>>()));
        }

        [Fact]
        public void Merge_CheckListExample()
        {
            for(int i=0; i<Set_listOfInterval.Count; i++)
            {
                var listOfIntervals = Set_listOfInterval[i];
                var expectedResult = Set_expectedResult[i];

                var resultListOfIntervals = IntervalHelper.Merge(listOfIntervals);
                foreach (Interval<int> interval in expectedResult)
                {
                    Assert.Contains(interval, resultListOfIntervals);
                }

                Assert.Equal(expectedResult.Count, resultListOfIntervals.Count);
            }
            
        }
        [Fact]
        public void Merge_AllItemsUnique()
        {
            for(int i=0; i<Set_listOfInterval.Count; i++)
            {
                var listOfIntervals = Set_listOfInterval[i];
                var resultLIstOfIntervals = IntervalHelper.Merge(listOfIntervals);
                Assert.Equal(resultLIstOfIntervals.Count, resultLIstOfIntervals.Distinct().Count());
            }
            
        }


    }
}
