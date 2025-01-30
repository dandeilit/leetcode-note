namespace Code
{
    /// <summary>
    /// 350. Intersection of Two Arrays II
    /// 
    /// Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.
    /// 给定两个整数数组 nums1 和 nums2，返回它们的交集数组。结果中的每个元素必须与它在两个数组中出现的次数相同，您可以按任何顺序返回结果。
    /// 
    /// Follow up:
    /// 进阶：
    ///
    /// * What if the given array is already sorted? How would you optimize your algorithm?
    /// * 如果给定的数组已经排序怎么办？你会如何优化你的算法？
    /// 
    /// * What if nums1's size is small compared to nums2's size? Which algorithm is better?
    /// * 如果 nums1 的大小与 nums2 的大小相比很小怎么办？哪种算法更好？
    /// 
    /// * What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
    /// * 如果 nums2 的元素存储在磁盘上，并且内存有限，以至于你无法一次将所有元素加载到内存中怎么办？
    /// 
    /// </summary>
    public class Intersection_of_Two_Arrays_II
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return Intersect(nums2, nums1);
            }

            var dict = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            var ans = new List<int>();
            foreach (var num in nums2)
            {
                if (dict.ContainsKey(num) && dict[num] > 0)
                {
                    dict[num]--;
                    ans.Add(num);
                }
            }

            // 切片语法糖
            return [.. ans];
        }

        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect2(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            var intersection = new List<int>();
            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    intersection.Add(nums1[i]);
                    i++;
                    j++;
                }
            }
            return intersection.ToArray();
        }
    }
}
