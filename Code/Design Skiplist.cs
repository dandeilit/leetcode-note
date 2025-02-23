namespace Code
{
    /// <summary>
    /// 1206. Design Skiplist
    /// 
    /// Design a Skiplist without using any built-in libraries.
    /// 设计一个不使用任何内置库的 Skiplist。
    /// 
    /// A skiplist is a data structure that takes O(log(n)) time to add, erase and search. Comparing with treap and red-black tree which has the same function and performance, the code length of Skiplist can be comparatively short and the idea behind Skiplists is just simple linked lists.
    /// Skiplist 是一种需要 O(log(n)) 时间来添加、删除和搜索的数据结构。与具有相同功能和性能的 treap 和红黑树相比，Skiplist 的代码长度相对较短，并且 Skiplist 背后的思想只是简单的链接列表。
    /// 
    /// You can see there are many layers in the Skiplist. Each layer is a sorted linked list. With the help of the top layers, add, erase and search can be faster than O(n). It can be proven that the average time complexity for each operation is O(log(n)) and space complexity is O(n).
    /// 你可以看到 Skiplist 中有很多层。每一层都是一个排序的链接列表。借助顶层，添加、删除和搜索可以比 O(n) 更快。可以证明每个操作的平均时间复杂度为 O(log(n))，空间复杂度为 O(n)。
    /// 
    /// See more about Skiplist: https://en.wikipedia.org/wiki/Skip_list
    /// 有关 Skiplist 的更多信息，请参阅：https://en.wikipedia.org/wiki/Skip_list
    /// 
    /// Implement the Skiplist class:
    /// 实现 Skiplist 类：
    /// 
    /// * Skiplist() Initializes the object of the skiplist.
    /// * Skiplist() 初始化跳跃表的对象。
    /// 
    /// * bool search(int target) Returns true if the integer target exists in the Skiplist or false otherwise.
    /// * bool search(int target) 如果整数 target 存在于 Skiplist 中，则返回 true，否则返回 false。
    /// 
    /// * void add(int num) Inserts the value num into the SkipList.
    /// * void add(int num) 将值 num 插入 SkipList。
    /// 
    /// * bool erase(int num) Removes the value num from the Skiplist and returns true. If num does not exist in the Skiplist, do nothing and return false. If there exist multiple num values, removing any one of them is fine.
    /// * bool erase(int num) 从 Skiplist 中删除值 num 并返回 true。如果 num 不存在于 Skiplist 中，则不执行任何操作并返回 false。如果存在多个 num 值，则删除其中任何一个都可以。
    /// 
    /// Note that duplicates may exist in the Skiplist, your code needs to handle this situation.
    /// 请注意，Skiplist 中可能存在重复项，您的代码需要处理这种情况。
    /// 
    /// </summary>
    public class Design_Skiplist
    {
        public class Skiplist
        {
            const int MAX_LEVEL = 32;
            const double P_FACTOR = 0.25;
            private SkiplistNode head;
            private int level;
            private Random random;

            public Skiplist()
            {
                this.head = new SkiplistNode(-1, MAX_LEVEL);
                this.level = 0;
                this.random = new Random();
            }

            public bool Search(int target)
            {
                SkiplistNode curr = this.head;
                for (int i = level - 1; i >= 0; i--)
                {
                    /* 找到第 i 层小于且最接近 target 的元素*/
                    while (curr.forward[i] != null && curr.forward[i].val < target)
                    {
                        curr = curr.forward[i];
                    }
                }
                curr = curr.forward[0];
                /* 检测当前元素的值是否等于 target */
                if (curr != null && curr.val == target)
                {
                    return true;
                }
                return false;
            }

            public void Add(int num)
            {
                SkiplistNode[] update = new SkiplistNode[MAX_LEVEL];
                Array.Fill(update, head);
                SkiplistNode curr = this.head;
                for (int i = level - 1; i >= 0; i--)
                {
                    /* 找到第 i 层小于且最接近 num 的元素*/
                    while (curr.forward[i] != null && curr.forward[i].val < num)
                    {
                        curr = curr.forward[i];
                    }
                    update[i] = curr;
                }
                int lv = RandomLevel();
                level = Math.Max(level, lv);
                SkiplistNode newNode = new SkiplistNode(num, lv);
                for (int i = 0; i < lv; i++)
                {
                    /* 对第 i 层的状态进行更新，将当前元素的 forward 指向新的节点 */
                    newNode.forward[i] = update[i].forward[i];
                    update[i].forward[i] = newNode;
                }
            }

            public bool Erase(int num)
            {
                SkiplistNode[] update = new SkiplistNode[MAX_LEVEL];
                SkiplistNode curr = this.head;
                for (int i = level - 1; i >= 0; i--)
                {
                    /* 找到第 i 层小于且最接近 num 的元素*/
                    while (curr.forward[i] != null && curr.forward[i].val < num)
                    {
                        curr = curr.forward[i];
                    }
                    update[i] = curr;
                }
                curr = curr.forward[0];
                /* 如果值不存在则返回 false */
                if (curr == null || curr.val != num)
                {
                    return false;
                }
                for (int i = 0; i < level; i++)
                {
                    if (update[i].forward[i] != curr)
                    {
                        break;
                    }
                    /* 对第 i 层的状态进行更新，将 forward 指向被删除节点的下一跳 */
                    update[i].forward[i] = curr.forward[i];
                }
                /* 更新当前的 level */
                while (level > 1 && head.forward[level - 1] == null)
                {
                    level--;
                }
                return true;
            }

            private int RandomLevel()
            {
                int lv = 1;
                /* 随机生成 lv */
                while (random.NextDouble() < P_FACTOR && lv < MAX_LEVEL)
                {
                    lv++;
                }
                return lv;
            }
        }

        public class SkiplistNode
        {
            public int val;
            public SkiplistNode[] forward;

            public SkiplistNode(int val, int maxLevel)
            {
                this.val = val;
                this.forward = new SkiplistNode[maxLevel];
            }
        }
    }
}
