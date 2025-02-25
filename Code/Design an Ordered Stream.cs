namespace Code
{
    /// <summary>
    /// 1656. Design an Ordered Stream
    /// 
    /// There is a stream of n (idKey, value) pairs arriving in an arbitrary order, where idKey is an integer between 1 and n and value is a string. No two pairs have the same id.
    /// 存在一个由 n 个 (idKey, value) 对组成的流，这些对以任意顺序到达，其中 idKey 是介于 1 和 n 之间的整数，value 是字符串。没有两对具有相同的 id。
    /// 
    /// Design a stream that returns the values in increasing order of their IDs by returning a chunk (list) of values after each insertion. The concatenation of all the chunks should result in a list of the sorted values.
    /// 设计一个流，通过在每次插入后返回一个值块（列表），按其 ID 的升序返回值。所有块的连接应产生一个排序值的列表。
    /// 
    /// Implement the OrderedStream class:
    /// 实现 OrderedStream 类：
    /// 
    /// * OrderedStream(int n) Constructs the stream to take n values.
    /// * OrderedStream(int n) 构造流以接受 n 个值。
    /// 
    /// * String[] insert(int idKey, String value) Inserts the pair (idKey, value) into the stream, then returns the largest possible chunk of currently inserted values that appear next in the order.
    /// * String[] insert(int idKey, String value) 将对 (idKey, value) 插入流中，然后返回按顺序出现的当前插入值的最大可能块。
    /// 
    /// </summary>
    public class Design_an_Ordered_Stream
    {
        public class OrderedStream
        {
            string[] order;
            int n;
            int index = 0;

            public OrderedStream(int n)
            {
                this.n = n;
                order = new string[n];
            }

            public IList<string> Insert(int idKey, string value)
            {
                order[idKey - 1] = value;

                if (order[index] == null) return [];

                IList<string> res = new List<string>();
                while (index < n && order[index] != null)
                {
                    res.Add(order[index]);
                    index++;
                }

                return res;
            }
        }
    }
}
