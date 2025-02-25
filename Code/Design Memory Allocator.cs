namespace Code
{
    /// <summary>
    /// 2502. Design Memory Allocator
    /// 
    /// You are given an integer n representing the size of a 0-indexed memory array. All memory units are initially free.
    /// 给定一个整数 n，表示 0 起始索引内存数组的大小。所有内存单元最初都是空闲的。
    /// 
    /// You have a memory allocator with the following functionalities:
    /// 您有一个具有以下功能的内存分配器：
    /// 
    /// 1. Allocate a block of size consecutive free memory units and assign it the id mID.
    /// 1. 分配一个大小为连续空闲内存单元的块，并为其分配 id mID。
    /// 
    /// 2. Free all memory units with the given id mID.
    /// 2. 释放所有具有给定 id mID 的内存单元。
    /// 
    /// Note that:
    /// 请注意：
    /// 
    /// * Multiple blocks can be allocated to the same mID.
    /// * 可以将多个块分配给同一个 mID。
    /// 
    /// * You should free all the memory units with mID, even if they were allocated in different blocks.
    /// * 您应该释放所有具有 mID 的内存单元，即使它们分配在不同的块中。
    /// 
    /// Implement the Allocator class:
    /// 实现 Allocator 类：
    /// 
    /// * Allocator(int n) Initializes an Allocator object with a memory array of size n.
    /// * Allocator(int n) 使用大小为 n 的内存数组初始化 Allocator 对象。
    /// 
    /// * int allocate(int size, int mID) Find the leftmost block of size consecutive free memory units and allocate it with the id mID. Return the block's first index. If such a block does not exist, return -1.
    /// * int allocate(int size, int mID) 查找最左边的 size 个连续空闲内存单元块，并将其分配为 id mID。返回该块的第一个索引。如果不存在这样的块，则返回 -1。
    /// 
    /// * int freeMemory(int mID) Free all memory units with the id mID. Return the number of memory units you have freed.
    /// * int freeMemory(int mID) 释放所有 id 为 mID 的内存单元。返回已释放的内存单元数。
    /// 
    /// </summary>
    public class Design_Memory_Allocator
    {
        public class Allocator
        {
            byte[] blocks;
            IDictionary<int, IList<int[]>> maps;

            public Allocator(int n)
            {
                blocks = new byte[n];
                maps = new Dictionary<int, IList<int[]>>();
            }

            public int Allocate(int size, int mID)
            {
                int startIndex = 0;
                int count = 0;
                for (var i = 0; i < blocks.Length; i++)
                {
                    if ((i == 0 || blocks[i - 1] == 1) && blocks[i] == 0)
                    {
                        startIndex = i;
                        count = 1;
                    }

                    if (i > 0 && blocks[i - 1] == 0 && blocks[i] == 0)
                    {
                        count++;
                    }

                    if (count >= size)
                    {
                        break;
                    }
                }

                if (count < size)
                {
                    return -1;
                }

                for (var i = startIndex; i < startIndex + size; i++)
                {
                    blocks[i] = 1;
                }

                if (!maps.ContainsKey(mID))
                {
                    maps[mID] = new List<int[]>();
                }
                maps[mID].Add([startIndex, size]);

                return startIndex;
            }

            public int FreeMemory(int mID)
            {
                if (!maps.ContainsKey(mID)) return 0;

                int ans = 0;
                foreach (var map in maps[mID])
                {
                    ans += map[1];
                    for (var i = map[0]; i < map[0] + map[1]; i++)
                    {
                        blocks[i] = 0;
                    }
                }
                maps[mID] = new List<int[]>();
                return ans;
            }
        }


        public class Allocator2
        {
            private int n;
            private int[] memory;

            public Allocator2(int n)
            {
                this.n = n;
                this.memory = new int[n];
            }

            public int Allocate(int size, int mID)
            {
                int count = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (memory[i] != 0)
                    {
                        count = 0;
                    }
                    else
                    {
                        ++count;
                        if (count == size)
                        {
                            for (int j = i - count + 1; j <= i; ++j)
                            {
                                memory[j] = mID;
                            }
                            return i - count + 1;
                        }
                    }
                }
                return -1;
            }

            public int FreeMemory(int mID)
            {
                int count = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (memory[i] == mID)
                    {
                        ++count;
                        memory[i] = 0;
                    }
                }
                return count;
            }
        }
    }
}
