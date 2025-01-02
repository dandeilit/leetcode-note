namespace Code
{
    /// <summary>
    /// 729. My Calendar I
    /// 
    /// You are implementing a program to use as your calendar. We can add a new event if adding the event will not cause a double booking.
    /// 您正在实现一个程序来用作您的日历。如果添加活动不会导致重复预订，我们可以添加新活动。
    /// 
    /// A double booking happens when two events have some non-empty intersection(i.e., some moment is common to both events.).
    /// 当两个事件有一些非空交集（即，某些时刻对于两个事件来说是共同的）时，就会发生重复预订。
    /// 
    /// The event can be represented as a pair of integers startTime and endTime that represents a booking on the half-open interval[startTime, endTime), the range of real numbers x such that startTime <= x < endTime.
    /// 该事件可以表示为一对整数startTime和endTime ，表示半开间隔[startTime, endTime)上的预订，实数x的范围使得startTime <= x < endTime 。
    /// 
    /// Implement the MyCalendar class:
    /// 实现MyCalendar类：
    /// 
    /// MyCalendar() Initializes the calendar object.
    /// MyCalendar()初始化日历对象。
    /// 
    /// boolean book(int startTime, int endTime) Returns true if the event can be added to the calendar successfully without causing a double booking.Otherwise, return false and do not add the event to the calendar.
    /// boolean book(int startTime, int endTime) 如果事件可以成功添加到日历而不会导致重复预订，则返回true 。否则，返回false并且不将该事件添加到日历中。
    /// 
    /// </summary>
    public abstract class MyCalendarI
    {
        public abstract bool Book(int startTime, int endTime);


        /// <summary>
        /// 记录区间遍历
        /// </summary>
        public class MyCalendar1 : MyCalendarI
        {
            IList<int[]> timeSpan;
            public MyCalendar1()
            {
                timeSpan = new List<int[]>();

                var abc = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
            }

            public override bool Book(int startTime, int endTime)
            {
                if (timeSpan.Count == 0)
                {
                    timeSpan.Add([startTime, endTime]);
                    return true;
                }

                for (var i = 0; i < timeSpan.Count; i++)
                {
                    // 子集
                    if (startTime >= timeSpan[i][0] && endTime < timeSpan[i][1])
                    {
                        return false;
                    }

                    // 交集
                    if (startTime <= timeSpan[i][0] && endTime > timeSpan[i][0])
                    {
                        return false;
                    }
                    if (endTime >= timeSpan[i][1] && startTime < timeSpan[i][1])
                    {
                        return false;
                    }
                }
                timeSpan.Add([startTime, endTime]);
                return true; ;
            }
        }


        /// <summary>
        /// 利用 List 的 Insert()，按 起始，结束，起始，结束 的顺序在 List 中存储排序好的区间信息
        /// 二分查找确定插入区间索引，根据区间信息判定是否存在交集
        /// </summary>
        public class MyCalendar2 : MyCalendarI
        {
            List<int> calendar = new List<int>(1000);
            public MyCalendar2()
            {

            }

            public override bool Book(int startTime, int endTime)
            {
                int index = calendar.BinarySearch(startTime);
                if (index < 0)
                {
                    index = ~index;

                    if (index % 2 == 1)
                    {
                        return false;
                    }

                    if (calendar.Count > index)
                    {
                        if (calendar[index] >= endTime)
                        {
                            calendar.Insert(index, startTime);
                            calendar.Insert(index + 1, endTime);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        calendar.Insert(index, startTime);
                        calendar.Insert(index + 1, endTime);
                        return true;
                    }
                }
                else
                {
                    if (index % 2 == 0)
                    {
                        return false;
                    }
                    if (calendar.Count > index + 1)
                    {
                        if (calendar[index + 1] >= endTime)
                        {
                            calendar.Insert(index + 1, startTime);
                            calendar.Insert(index + 2, endTime);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        calendar.Insert(index + 1, startTime);
                        calendar.Insert(index + 2, endTime);
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// 利用 SortedSet 的 GetViewBetween() 方法查询与 传入起始结束时间相近的前后区间信息，根据区间信息判定
        /// </summary>
        public class MyCalendar3 : MyCalendarI
        {
            SortedSet<int[]> booked;
            public MyCalendar3()
            {
                booked = new SortedSet<int[]>(Comparer<int[]>.Create((x, y) => x[0] - y[0]));
            }

            public override bool Book(int startTime, int endTime)
            {
                if (booked.Count == 0)
                {
                    booked.Add([startTime, endTime]);
                    return true;
                }

                if (startTime >= booked.Max[1] || endTime <= booked.Min[0])
                {
                    booked.Add([startTime, endTime]);
                    return true;
                }

                var right = booked.GetViewBetween([startTime + 1, 0], [int.MaxValue, 0]).Min;
                var left = booked.GetViewBetween([0, 0], [startTime, 0]).Max;

                if (left != null && right != null)
                {
                    if (left[1] <= startTime && right[0] >= endTime)
                    {
                        booked.Add([startTime, endTime]);
                        return true;
                    }

                }
                else if (left != null)
                {
                    if (left[1] <= startTime)
                    {
                        booked.Add([startTime, endTime]);
                        return true;
                    }
                }
                else if (right != null)
                {
                    if (right[0] >= endTime)
                    {
                        booked.Add([startTime, endTime]);
                        return true;
                    }
                }

                return false;
            }

        }

        /// <summary>
        /// 动态线段树
        /// [0,1e9)编号idx=1，[0,mid)编号idx=2, [mid,1e9)编号idx=3，以此类推，配合tree和lazy工作
        /// </summary>
        public class MyCalendar4 : MyCalendarI
        {
            ISet<int> tree; // tree 记录区间[l, r] 的是否存在标记为 1 的元素。
            ISet<int> lazy; // 懒标记 lazy 标记区间[l, r] 已经被预订

            public MyCalendar4()
            {
                tree = new HashSet<int>();
                lazy = new HashSet<int>();
            }

            public override bool Book(int start, int end)
            {
                if (Query(start, end - 1, 0, 1000000000, 1))
                {
                    return false;
                }
                Update(start, end - 1, 0, 1000000000, 1);
                return true;
            }

            public bool Query(int start, int end, int l, int r, int idx)
            {
                if (start > r || end < l)
                {
                    return false;
                }
                /* 如果该区间已被预订，则直接返回 */
                if (lazy.Contains(idx))
                {
                    return true;
                }
                if (start <= l && r <= end)
                {
                    return tree.Contains(idx);
                }
                else
                {
                    int mid = (l + r) >> 1;
                    if (end <= mid)
                    {
                        return Query(start, end, l, mid, 2 * idx);
                    }
                    else if (start > mid)
                    {
                        return Query(start, end, mid + 1, r, 2 * idx + 1);
                    }
                    else
                    {
                        return Query(start, end, l, mid, 2 * idx) | Query(start, end, mid + 1, r, 2 * idx + 1);
                    }
                }
            }

            public void Update(int start, int end, int l, int r, int idx)
            {
                if (r < start || end < l)
                {
                    return;
                }
                if (start <= l && r <= end)
                {
                    tree.Add(idx);
                    lazy.Add(idx);
                }
                else
                {
                    int mid = (l + r) >> 1;
                    Update(start, end, l, mid, 2 * idx);
                    Update(start, end, mid + 1, r, 2 * idx + 1);
                    tree.Add(idx);
                }
            }
        }
    }
}
