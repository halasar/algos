using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class ArrayAlgos
    {

        
        /**
 * Definition for an interval.
 * public class Interval {
 *     int start;
 *     int end;
 *     Interval() { start = 0; end = 0; }
 *     Interval(int s, int e) { start = s; end = e; }
 * }
 */
    public class Interval {
     public int start;
     public int end;
     public Interval() { start = 0; end = 0; }
     public Interval(int s, int e) { start = s; end = e; }
    }
    /*
        Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
        You may assume that the intervals were initially sorted according to their start times.
        Example 1:
        Given intervals [1,3],[6,9] insert and merge [2,5] in as [1,5],[6,9].
        Example 2:
        Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].
        This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].
        Make sure the returned intervals are also sorted.
     */
    public List<Interval> Insert(List<Interval> intervals, Interval newInterval)
        {


            bool overlapped = false;
            bool done = false;

            var mergedList = new List<Interval>();

            for (int i = 0; i < intervals.Count; i++)
            {

                Interval current = intervals[i];

                if (overlapped == false && done == false && newInterval.end < current.start)
                {
                    mergedList.Add(newInterval);
                    mergedList.Add(current);
                    done = true;
                }
                else if (Math.Max(current.start, newInterval.start) <= Math.Min(current.end, newInterval.end))//there is an overlap
                {
                    if (overlapped == false)
                    {
                        var mergedInterval = new Interval();
                        mergedInterval.start = Math.Min(newInterval.start, current.start);
                        mergedInterval.end = Math.Max(newInterval.end, current.end);
                        mergedList.Add(mergedInterval);
                        overlapped = true;
                    }
                    else
                    {
                        var mergedInterval = mergedList[mergedList.Count - 1];
                        mergedInterval.end = Math.Max(newInterval.end, current.end);
                        overlapped = true;
                    }

                    if (i == intervals.Count - 1)
                    {
                        done = true;
                    }

                }
                else if (current.start > newInterval.end && overlapped == true)
                {
                    done = true;
                    mergedList.Add(current);
                }
                else
                {
                    mergedList.Add(current);

                }

            }

            if (!done)
            {
                mergedList.Add(newInterval);
            }
            return mergedList;
        }
    }
}
