namespace Code
{
    /// <summary>
    /// 80. Remove Duplicates from Sorted Array II
    /// 
    /// Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.
    /// 给定一个按非降序排序的整数数组 nums，就地删除一些重复项，使得每个唯一元素最多出现两次。元素的相对顺序应保持不变。
    /// 
    /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
    /// 由于在某些语言中无法更改数组的长度，因此您必须将结果放在数组 nums 的第一部分。更正式地说，如果删除重复项后有 k 个元素，则 nums 的前 k 个元素应保存最终结果。前 k 个元素之后留下什么并不重要。
    /// 
    /// Return k after placing the final result in the first k slots of nums.
    /// 将最终结果放入 nums 的前 k 个槽中，返回 k。
    /// 
    /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
    /// 不要为另一个数组分配额外的空间。您必须通过使用 O(1) 额外内存就地修改输入数组来执行此操作。
    /// 
    /// </summary>
    public class Remove_Duplicates_from_Sorted_Array_II
    {
        public int RemoveDuplicates(int[] nums)
        {
            bool flag = true; // 标记数字是否已出现一次
            var start = 1;
            var end = nums.Length;
            while (start < end)
            {
                if (nums[start] == nums[start - 1])
                {
                    if (flag)
                    {
                        start++;
                        flag = false;
                    }
                    else
                    {
                        end--;
                        int x = nums[start];
                        for (var i = start + 1; i <= end; i++)
                        {
                            nums[i - 1] = nums[i];
                        }
                    }
                }
                else
                {
                    flag = true;
                    start++;
                }
            }
            return end;
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates2(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2)
            {
                return n;
            }
            int slow = 2; // 处理出的数组的长度 
            int fast = 2; // 已经检查过的数组的长度
            while (fast < n)
            {
                if (nums[slow - 2] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }
    }
}
