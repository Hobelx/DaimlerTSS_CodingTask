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
            Assert.False(IntervalHelper.Overlaps<int>(null, null));
            Assert.False(IntervalHelper.Overlaps<int>(null, new Interval<int>(2, 5)));
            Assert.False(IntervalHelper.Overlaps<int>(new Interval<int>(2, 5), null));

            Assert.False(IntervalHelper.Overlaps<float>(null, null));
            Assert.False(IntervalHelper.Overlaps<float>(null, new Interval<float>(2.0f, 5.0f)));
            Assert.False(IntervalHelper.Overlaps<float>(new Interval<float>(2.0f, 5.0f), null));
        }
        [Fact]
        public void Overlap_IntervalInsideOtherInterval()
        {
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(1, 10), new Interval<int>(2,4)));
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(2, 4), new Interval<int>(1, 10)));

            Assert.True(IntervalHelper.Overlaps<float>(new Interval<float>(1.2f, 10.4f), new Interval<float>(2.4f, 4.4f)));
            Assert.True(IntervalHelper.Overlaps<float>(new Interval<float>(2.4f, 4.4f), new Interval<float>(1.4f, 10.4f)));
        }
        [Fact]
        public void Overlap_IntervalOverlapsOtherInterval()
        {
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(1, 10), new Interval<int>(8, 12)));
            Assert.True(IntervalHelper.Overlaps<int>(new Interval<int>(8, 12), new Interval<int>(1, 10)));

            Assert.True(IntervalHelper.Overlaps<float>(new Interval<float>(1.2f, 10.4f), new Interval<float>(2.4f, 4.4f)));
            Assert.True(IntervalHelper.Overlaps<float>(new Interval<float>(2.4f, 4.4f), new Interval<float>(1.4f, 10.4f)));
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
            Assert.Equal(null, IntervalHelper.MergeIntervals<float>(new Interval<float>(5, 10), new Interval<float>(14, 20)));

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
