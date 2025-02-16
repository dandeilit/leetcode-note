namespace Code
{
    /// <summary>
    /// 1299. Replace Elements with Greatest Element on Right Side
    /// 
    /// Given an array arr, replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.
    /// 给定一个数组 arr，将数组中的每个元素替换为右元素之间的最大元素，然后用-1替换最后一个元素。
    /// 
    /// After doing so, return the array.
    /// 这样做后，返回数组。
    /// 
    /// </summary>
    public class Replace_Elements_with_Greatest_Element_on_Right_Side
    {
        public int[] ReplaceElements(int[] arr)
        {
            var n = arr.Length;
            if (n == 1)
            {
                return [-1];
            }

            if (n == 2)
            {
                return [arr[1], -1];
            }

            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            for (var i = 1; i < n; i++)
            {
                queue.Enqueue(i, arr[i]);
            }

            int start = 0;
            while (queue.Count > 0)
            {
                var inx = queue.Dequeue();
                while (inx < start)
                {
                    inx = queue.Dequeue();
                }

                for (var i = start; i < inx; i++)
                {
                    arr[i] = arr[inx];
                }
                start = inx;

                if (start == n - 1)
                {
                    arr[start] = -1;
                    break;
                }
            }

            return arr;
        }

        /// <summary>
        /// 逆序遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ReplaceElements2(int[] arr)
        {
            var n = arr.Length;
            int max = 0;
            int preNum = arr[n - 1];
            for (var i = n - 1; i > 0; i--)
            {
                if (preNum > max)
                {
                    max = preNum;
                }
                preNum = arr[i - 1];
                arr[i - 1] = max;
            }
            arr[n - 1] = -1;
            return arr;
        }
    }
}
