using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KataSolutions.SumOfIntervals
{
    public class SumOfIntervalsKata
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            // sort the array
            // remove intervals that exist inside other intervals e.g. (4,5) is inside (3, 6)
            // concatenate intervals that overlap e.g. (1, 5) and (4, 7) => (1, 7) anmd remove the unnecessary intervals
            // sum the intervals of the updated array

            int sumIntervals = 0;

            if (intervals.Length < 1)
            {
                return 0;
            }

            (int, int)[] updatedIntervalArray = intervals.ToArray();
            RemoveIntervalsWithRangeInsideAnotherInterval(ref intervals);
            ConcatenateIntervals(ref updatedIntervalArray);


            // sort intervals
            (int, int)[] sortedIntervals = intervals.OrderBy(x => x.Item1).ToArray();

            // remove any intervals that fit inside another interval
            foreach (var outerInterval in sortedIntervals)
            {
                foreach(var innerInterval in sortedIntervals)
                {
                    if (outerInterval.Item2 > innerInterval.Item2)
                    {
                        
                    }
                }
            }

            // check if each interval overlaps the next
            for (int i = 0; i < intervals.Length; i++)
            {
                if (i != intervals.Length - 1 && intervals[i].Item2 > intervals[i + 1].Item1)
                {
                    sumIntervals--;
                }

                sumIntervals += CalculateInterval(intervals[i].Item1, intervals[i].Item2);
            }

            return sumIntervals;
        }

        private static (int, int)[] ConcatenateIntervals(ref (int, int)[] updatedIntervalArray)
        {
            throw new NotImplementedException();
        }

        private static (int, int)[] RemoveIntervalsWithRangeInsideAnotherInterval(ref (int, int)[] intervals)
        {
            throw new NotImplementedException();
        }

        private static int CalculateInterval(int start, int end)
        {
            return end - start;
        }
    }
}
