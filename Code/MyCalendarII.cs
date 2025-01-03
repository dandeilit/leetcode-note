namespace Code
{
    /// <summary>
    /// 731. My Calendar II
    /// 
    /// You are implementing a program to use as your calendar. We can add a new event if adding the event will not cause a triple booking.
    /// 您正在实现一个程序来用作您的日历。如果添加活动不会导致三重预订，我们可以添加新活动。
    ///
    /// A triple booking happens when three events have some non-empty intersection(i.e., some moment is common to all the three events.).
    /// 当三个事件有一些非空交集（即，某个时刻对于所有三个事件来说是共同的）时，就会发生三重预订。

    /// The event can be represented as a pair of integers startTime and endTime that represents a booking on the half-open interval[startTime, endTime), the range of real numbers x such that startTime <= x < endTime.
    /// 该事件可以表示为一对整数startTime和endTime ，表示半开间隔[startTime, endTime)上的预订，实数x的范围使得startTime <= x < endTime 。
    /// 
    /// Implement the MyCalendarTwo class:
    /// 实现MyCalendarTwo类：
    /// 
    /// MyCalendarTwo() Initializes the calendar object.
    /// MyCalendarTwo()初始化日历对象。
    /// 
    /// boolean book(int startTime, int endTime) Returns true if the event can be added to the calendar successfully without causing a triple booking.Otherwise, return false and do not add the event to the calendar.
    /// boolean book(int startTime, int endTime) 如果事件可以成功添加到日历而不会导致三次预订，则返回true 。否则，返回false并且不将该事件添加到日历中。
    /// 
    /// </summary>
    public abstract class MyCalendarII
    {
        public abstract bool Book(int startTime, int endTime);

        /// <summary>
        /// 记录每日预定数，遍历判定（空间占用过高）
        /// </summary>
        public class MyCalendar1 : MyCalendarII
        {
            private int[] map;

            public MyCalendar1()
            {
                map = new int[(int)Math.Pow(10, 9)];
            }

            public override bool Book(int startTime, int endTime)
            {
                for (var i = startTime; i < endTime; i++)
                {
                    if (map[i] == 2)
                    {
                        return false;
                    }
                }

                for (var i = startTime; i < endTime; i++)
                {
                    map[i] += 1;
                }
                return true;
            }
        }

        /// <summary>
        /// 记录区间信息，遍历判定
        /// </summary>
        public class MyCalendar2 : MyCalendarII
        {
            List<Tuple<int, int>> booked;
            List<Tuple<int, int>> overlaps;

            public MyCalendar2()
            {
                booked = new List<Tuple<int, int>>();
                overlaps = new List<Tuple<int, int>>();
            }

            public override bool Book(int startTime, int endTime)
            {
                foreach (Tuple<int, int> tuple in overlaps)
                {
                    int l = tuple.Item1, r = tuple.Item2;
                    if (l < endTime && startTime < r)
                    {
                        return false;
                    }
                }
                foreach (Tuple<int, int> tuple in booked)
                {
                    int l = tuple.Item1, r = tuple.Item2;
                    if (l < endTime && startTime < r)
                    {
                        overlaps.Add(new Tuple<int, int>(Math.Max(l, startTime), Math.Min(r, endTime)));
                    }
                }
                booked.Add(new Tuple<int, int>(startTime, endTime));
                return true;
            }
        }

        /// <summary>
        /// 线段树
        /// </summary>
        public class MyCalendar3 : MyCalendarII
        {
            Dictionary<int, int[]> tree;

            public MyCalendar3()
            {
                tree = new Dictionary<int, int[]>();
            }

            public override bool Book(int start, int end)
            {
                Update(start, end - 1, 1, 0, 1000000000, 1);
                if (!tree.ContainsKey(1))
                {
                    tree.Add(1, new int[2]);
                }
                if (tree[1][0] > 2)
                {
                    Update(start, end - 1, -1, 0, 1000000000, 1);
                    return false;
                }
                return true;
            }

            public void Update(int start, int end, int val, int l, int r, int idx)
            {
                if (r < start || end < l)
                {
                    return;
                }
                if (!tree.ContainsKey(idx))
                {
                    tree.Add(idx, new int[2]);
                }
                if (start <= l && r <= end)
                {
                    tree[idx][0] += val;
                    tree[idx][1] += val;
                }
                else
                {
                    int mid = (l + r) >> 1;
                    Update(start, end, val, l, mid, 2 * idx);
                    Update(start, end, val, mid + 1, r, 2 * idx + 1);
                    if (!tree.ContainsKey(2 * idx))
                    {
                        tree.Add(2 * idx, new int[2]);
                    }
                    if (!tree.ContainsKey(2 * idx + 1))
                    {
                        tree.Add(2 * idx + 1, new int[2]);
                    }
                    tree[idx][0] = tree[idx][1] + Math.Max(tree[2 * idx][0], tree[2 * idx + 1][0]);
                }
            }
        }
    }
}
