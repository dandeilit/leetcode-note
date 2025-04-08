namespace Code
{
    /// <summary>
    /// 3396. Minimum Number of Operations to Make Elements in Array Distinct
    /// 3396. 使数组元素互不相同所需的最少操作次数
    /// 
    /// You are given an integer array nums. You need to ensure that the elements in the array are distinct. To achieve this, you can perform the following operation any number of times:
    /// 给你一个整数数组 nums，你需要确保数组中的元素 互不相同 。为此，你可以执行以下操作任意次：
    /// 
    /// Remove 3 elements from the beginning of the array. If the array has fewer than 3 elements, remove all remaining elements.
    /// 从数组的开头移除 3 个元素。如果数组中元素少于 3 个，则移除所有剩余元素。
    /// 
    /// Note that an empty array is considered to have distinct elements. Return the minimum number of operations needed to make the elements in the array distinct.
    /// 注意：空数组也视作为数组元素互不相同。返回使数组元素互不相同所需的 最少操作次数 。
    /// 
    /// </summary>
    public class Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct
    {
        public int MinimumOperations(int[] nums)
        {
            int n = nums.Length;
            int removeCount = 0;
            HashSet<int> map = new HashSet<int>();
            for (var i = n - 1; i >= 0; i--)
            {
                if (map.Contains(nums[i]))
                {
                    removeCount = i + 1;
                    break;
                }

                map.Add(nums[i]);
            }
            return (int)Math.Ceiling(removeCount / 3.0);
        }
    }
}
