namespace Code
{
    /// <summary>
    /// 81. Search in Rotated Sorted Array II
    /// 
    /// There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).
    /// 有一个按非递减顺序排序的整数数组 nums（不一定具有不同的值）。
    /// 
    /// Before being passed to your function, nums is rotated at an unknown pivot index k (0 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,4,4,5,6,6,7] might be rotated at pivot index 5 and become [4,5,6,6,7,0,1,2,4,4].
    /// 在传递给函数之前，nums 会在未知的枢轴索引 k（0 <= k < nums.length）处旋转，使得结果数组为 [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]（从 0 开始）。例如，[0,1,2,4,4,4,5,6,6,7] 可能会在枢轴索引 5 处旋转并变为 [4,5,6,6,7,0,1,2,4,4]。
    /// 
    /// Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.
    /// 给定旋转后的数组 nums 和一个整数 target，如果 target 在 nums 中则返回 true，如果它不在 nums 中则返回 false。
    /// 
    /// You must decrease the overall operation steps as much as possible.
    /// 必须尽可能减少整体操作步骤。
    /// 
    /// Follow up: This problem is similar to Search in Rotated Sorted Array, but nums may contain duplicates. Would this affect the runtime complexity? How and why?
    /// 进阶：这个问题类似于旋转排序数组中的搜索，但数字可能包含重复项。这会影响运行时复杂度吗？如何影响以及为什么？
    /// 
    /// </summary>
    public class Search_in_Rotated_Sorted_Array_II
    {
        /// <summary>
        /// 分段遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            int n = nums.Length;
            if (target == nums[0] || target == nums[n - 1]) return true;
            if (target > nums[0])
            {
                for (int i = 1; i < n; i++)
                {
                    if (nums[i] < nums[i - 1]) return false;

                    if (nums[i] > target) return false;

                    if (nums[i] == target) return true;
                }
            }

            if (target < nums[n - 1])
            {
                for (int i = n - 2; i >= 0; i--)
                {
                    if (nums[i] > nums[i + 1]) return false;

                    if (nums[i] < target) return false;

                    if (nums[i] == target) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search2(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return false;
            }
            if (n == 1)
            {
                return nums[0] == target;
            }
            int l = 0, r = n - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                if (nums[l] == nums[mid] && nums[mid] == nums[r])
                {
                    l++;
                    r--;
                }
                else if (nums[l] <= nums[mid])
                {
                    if (nums[l] <= target && target < nums[mid])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[n - 1])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }
            return false;
        }
    }
}
