namespace Code
{
    /// <summary>
    /// 2080. Range Frequency Queries
    /// 
    /// Design a data structure to find the frequency of a given value in a given subarray.
    /// 设计一个数据结构来查找给定子数组中给定值的频率。
    /// 
    /// The frequency of a value in a subarray is the number of occurrences of that value in the subarray.
    /// 子数组中某个值的频率是该值在子数组中出现的次数。
    /// 
    /// Implement the RangeFreqQuery class:
    /// 实现 RangeFreqQuery 类：
    /// 
    /// * RangeFreqQuery(int[] arr) Constructs an instance of the class with the given 0-indexed integer array arr.
    /// * RangeFreqQuery(int[] arr) 使用给定的 0 索引整数数组 arr 构造该类的实例。
    /// 
    /// * int query(int left, int right, int value) Returns the frequency of value in the subarray arr[left...right].
    /// * int query(int left, int right, int value) 返回子数组 arr[left...right] 中值的频率。
    /// 
    /// A subarray is a contiguous sequence of elements within an array. arr[left...right] denotes the subarray that contains the elements of nums between indices left and right (inclusive).
    /// 子数组是数组内元素的连续序列。arr[left...right] 表示包含左侧和右侧索引之间（包括）nums 元素的子数组。
    /// 
    /// </summary>
    public class Range_Frequency_Queries
    {
        /// <summary>
        /// 哈希 + SortedSet
        /// 超时
        /// SortedSet.GetViewBetween() 时间复杂度为 O(logn) 但 SortedSet.GetCount() 时间复杂度为 O(n)
        /// </summary>
        public class RangeFreqQuery
        {
            IDictionary<int, SortedSet<int>> map = new Dictionary<int, SortedSet<int>>();
            public RangeFreqQuery(int[] arr)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    if (map.ContainsKey(arr[i]))
                    {
                        map[arr[i]].Add(i);
                    }
                    else
                    {
                        map[arr[i]] = new SortedSet<int>() { i };
                    }
                }
            }

            public int Query(int left, int right, int value)
            {
                if (!map.ContainsKey(value))
                {
                    return 0;
                }

                var view = map[value].GetViewBetween(left, right);
                return view == null ? 0 : view.Count;
            }
        }

        /// <summary>
        /// 哈希表 + 二分查找
        /// </summary>
        public class RangeFreqQuery2
        {
            // 数值为键，出现下标数组为值的哈希表
            private Dictionary<int, List<int>> occurrence;

            public RangeFreqQuery2(int[] arr)
            {
                occurrence = new Dictionary<int, List<int>>();
                // 顺序遍历数组初始化哈希表
                for (int i = 0; i < arr.Length; ++i)
                {
                    if (!occurrence.ContainsKey(arr[i]))
                    {
                        occurrence[arr[i]] = new List<int>();
                    }
                    occurrence[arr[i]].Add(i);
                }
            }

            public int Query(int left, int right, int value)
            {
                // 查找对应的出现下标数组，不存在则为空
                if (!occurrence.TryGetValue(value, out var pos))
                {
                    pos = new List<int>();
                }
                // 两次二分查找计算子数组内出现次数
                int l = LowerBound(pos, left);
                int r = UpperBound(pos, right);
                return r - l;
            }

            private int LowerBound(List<int> pos, int target)
            {
                int low = 0, high = pos.Count - 1;
                while (low <= high)
                {
                    int mid = low + (high - low) / 2;
                    if (pos[mid] < target)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                return low;
            }

            private int UpperBound(List<int> pos, int target)
            {
                int low = 0, high = pos.Count - 1;
                while (low <= high)
                {
                    int mid = low + (high - low) / 2;
                    if (pos[mid] <= target)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                return low;
            }
        }
    }
}
