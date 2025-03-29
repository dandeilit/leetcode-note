namespace Code
{
    /// <summary>
    /// 2360. Longest Cycle in a Graph
    /// 2360. 图中的最长环
    /// 
    /// You are given a directed graph of n nodes numbered from 0 to n - 1, where each node has at most one outgoing edge.
    /// 给你一个 n 个节点的 有向图 ，节点编号为 0 到 n - 1 ，其中每个节点 至多 有一条出边。
    /// 
    /// The graph is represented with a given 0-indexed array edges of size n, indicating that there is a directed edge from node i to node edges[i]. If there is no outgoing edge from node i, then edges[i] == -1.
    /// 图用一个大小为 n 下标从 0 开始的数组 edges 表示，节点 i 到节点 edges[i] 之间有一条有向边。如果节点 i 没有出边，那么 edges[i] == -1 。
    /// 
    /// Return the length of the longest cycle in the graph. If no cycle exists, return -1.
    /// 请你返回图中的 最长 环，如果没有任何环，请返回 -1 。
    /// 
    /// A cycle is a path that starts and ends at the same node.
    /// 一个环指的是起点和终点是 同一个 节点的路径。
    /// 
    /// </summary>
    public class Longest_Cycle_in_a_Graph
    {

        /// <summary>
        /// 从每个节点开始进行遍历
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int LongestCycle(int[] edges)
        {
            int n = edges.Length;
            int[] label = new int[n];
            int current_label = 0, ans = -1;
            for (int i = 0; i < n; ++i)
            {
                if (label[i] != 0)
                {
                    continue;
                }
                int pos = i, start_label = current_label;
                while (pos != -1)
                {
                    ++current_label;
                    // 如果遇到了已经遍历过的节点
                    if (label[pos] != 0)
                    {
                        // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                        if (label[pos] > start_label)
                        {
                            ans = Math.Max(ans, current_label - label[pos]);
                        }
                        break;
                    }
                    label[pos] = current_label;
                    pos = edges[pos];
                }
            }
            return ans;
        }
    }
}
