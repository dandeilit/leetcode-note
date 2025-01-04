namespace Code
{
    /// <summary>
    /// 732. My Calendar III
    /// 
    /// A k-booking happens when k events have some non-empty intersection (i.e., there is some time that is common to all k events.)
    /// 当k事件有一些非空交集（即，有一些时间是所有k事件共同的）时，就会发生k预订。
    /// 
    /// You are given some events [startTime, endTime), after each given event, return an integer k representing the maximum k-booking between all the previous events.
    /// 给定一些事件[startTime, endTime) ，在每个给定事件之后，返回一个整数k表示所有先前事件之间的最大k预订。
    /// 
    /// Implement the MyCalendarThree class:
    /// 实现MyCalendarThree类：
    /// 
    /// MyCalendarThree() Initializes the object.
    /// MyCalendarThree()初始化该对象。
    /// 
    /// int book(int startTime, int endTime) Returns an integer k representing the largest integer such that there exists a k-booking in the calendar.
    /// int book(int startTime, int endTime) 返回一个整数k ，表示日历中存在k预订的最大整数。
    /// 
    /// </summary>
    public abstract class MyCalendarIII
    {
        public abstract int Book(int startTime, int endTime);

        /// <summary>
        /// 线段树
        /// </summary>
        public class MyCalendar1 : MyCalendarIII
        {
            private Dictionary<int, int[]> tree;

            public MyCalendar1()
            {
                tree = new Dictionary<int, int[]>();
            }

            public override int Book(int startTime, int endTime)
            {
                Update(startTime, endTime - 1, 0, 1000000000, 1);
                return tree[1][0];
            }

            public void Update(int start, int end, int l, int r, int idx)
            {
                if (r < start || end < l)
                {
                    return;
                }
                if (start <= l && r <= end) // 节点范围为传入范围子集
                {
                    if (!tree.ContainsKey(idx))
                    {
                        tree.Add(idx, new int[2]);
                    }
                    tree[idx][0]++; // 区间最大值 +1
                    tree[idx][1]++; // 懒惰标记 +1
                }
                else
                {
                    int mid = (l + r) >> 1;
                    Update(start, end, l, mid, 2 * idx); // 左节点查询更新
                    Update(start, end, mid + 1, r, 2 * idx + 1); // 右节点查询更新

                    // 补充节点信息
                    if (!tree.ContainsKey(idx))
                    {
                        tree.Add(idx, new int[2]);
                    }
                    if (!tree.ContainsKey(2 * idx))
                    {
                        tree.Add(2 * idx, new int[2]);
                    }
                    if (!tree.ContainsKey(2 * idx + 1))
                    {
                        tree.Add(2 * idx + 1, new int[2]);
                    }

                    // 区间最大值计算规则
                    tree[idx][0] = tree[idx][1] + Math.Max(tree[2 * idx][0], tree[2 * idx + 1][0]);
                }
            }
        }

        /// <summary>
        /// 线段树（更直观的写法）
        /// </summary>
        public class MyCalendar2 : MyCalendarIII
        {
            private class Node
            {
                public int l;
                public int r;
                public Node ln;
                public Node rn;
                public int max;
                public int lazy; //区间增加的值
                public Node(int l, int r)
                {
                    this.l = l;
                    this.r = r;

                }
            }

            //动态开点线段树区间查询修改
            Node root;

            public MyCalendar2()
            {
                root = new Node(0, 1000000000);
            }

            public override int Book(int startTime, int endTime)
            {
                Update(root, startTime, endTime - 1);

                return root.max;
            }

            private void Update(Node n, int left, int right)
            {
                //更新区间内+1
                if (left <= n.l && right >= n.r)
                {
                    n.max++;
                    n.lazy++;
                    return;
                }

                int mid = (n.l + n.r) / 2;
                if (n.ln == null)
                    n.ln = new Node(n.l, mid);
                if (n.rn == null)
                    n.rn = new Node(mid + 1, n.r);

                //更新lazy
                if (n.lazy > 0)
                {
                    n.ln.lazy += n.lazy;
                    n.ln.max += n.lazy;

                    n.rn.lazy += n.lazy;
                    n.rn.max += n.lazy;

                    n.lazy = 0;
                }


                if (left <= mid)
                    Update(n.ln, left, right);
                if (right > mid)
                    Update(n.rn, left, right);

                n.max = Math.Max(n.ln.max, n.rn.max);
            }
        }
    }
}
