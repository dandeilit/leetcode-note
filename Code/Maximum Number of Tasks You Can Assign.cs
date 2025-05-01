namespace Code
{
    /// <summary>
    /// 2071. Maximum Number of Tasks You Can Assign
    /// 2071. 你可以安排的最多任务数目
    /// 
    /// You have n tasks and m workers. Each task has a strength requirement stored in a 0-indexed integer array tasks, with the ith task requiring tasks[i] strength to complete. The strength of each worker is stored in a 0-indexed integer array workers, with the jth worker having workers[j] strength. Each worker can only be assigned to a single task and must have a strength greater than or equal to the task's strength requirement (i.e., workers[j] >= tasks[i]).
    /// 给你 n 个任务和 m 个工人。每个任务需要一定的力量值才能完成，需要的力量值保存在下标从 0 开始的整数数组 tasks 中，第 i 个任务需要 tasks[i] 的力量才能完成。每个工人的力量值保存在下标从 0 开始的整数数组 workers 中，第 j 个工人的力量值为 workers[j] 。每个工人只能完成 一个 任务，且力量值需要 大于等于 该任务的力量要求值（即 workers[j] >= tasks[i] ）。
    /// 
    /// Additionally, you have pills magical pills that will increase a worker's strength by strength. You can decide which workers receive the magical pills, however, you may only give each worker at most one magical pill.
    /// 除此以外，你还有 pills 个神奇药丸，可以给 一个工人的力量值 增加 strength 。你可以决定给哪些工人使用药丸，但每个工人 最多 只能使用 一片 药丸。
    /// 
    /// Given the 0-indexed integer arrays tasks and workers and the integers pills and strength, return the maximum number of tasks that can be completed.
    /// 给你下标从 0 开始的整数数组tasks 和 workers 以及两个整数 pills 和 strength ，请你返回 最多 有多少个任务可以被完成。
    /// 
    /// </summary>
    public class Maximum_Number_of_Tasks_You_Can_Assign
    {
        /// <summary>
        /// 二分查找 + 贪心选择
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="workers"></param>
        /// <param name="pills"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
        {
            int n = tasks.Length, m = workers.Length;
            Array.Sort(tasks);
            Array.Sort(workers);

            int left = 1, right = Math.Min(m, n), ans = 0;
            while (left <= right) // 二分查找
            {
                int mid = (left + right) / 2;
                if (check(tasks, workers, pills, strength, mid)) // 检测工作数是否可以完成 O(n+m)
                {
                    ans = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return ans;
        }

        private bool check(int[] tasks, int[] workers, int pills, int strength, int mid)
        {
            int m = workers.Length;
            int p = pills;
            var ws = new LinkedList<int>(); // 双端队列
            int ptr = m - 1; // 工人指针
            // 从大到小枚举每一个任务
            for (int i = mid - 1; i >= 0; --i)
            {
                while (ptr >= m - mid && workers[ptr] + strength >= tasks[i]) // 挑选最强工人
                {
                    // 所有吃丸子能完成tasks[i]的工人
                    ws.AddFirst(workers[ptr]);
                    --ptr;
                }
                if (ws.Count == 0)
                {
                    // 没有这样的人
                    return false;
                }
                else if (ws.Last.Value >= tasks[i])
                {
                    // 最强者能不能省丸子?
                    // 如果双端队列中最大的元素大于等于 tasks[i]
                    ws.RemoveLast();
                }
                else
                {
                    if (p == 0) // 是否还存在丸子
                    {
                        return false;
                    }
                    //最弱者吃丸子 刚好能完成工作
                    --p;
                    ws.RemoveFirst();
                }
            }
            return true;
        }
    }
}
