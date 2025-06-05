namespace Code
{
    /// <summary>
    /// 1061. Lexicographically Smallest Equivalent String
    /// 1061. 按字典序排列最小的等效字符串
    /// 
    /// You are given two strings of the same length s1 and s2 and a string baseStr.
    /// 给出长度相同的两个字符串s1 和 s2 ，还有一个字符串 baseStr 。
    /// 
    /// We say s1[i] and s2[i] are equivalent characters.
    /// 其中  s1[i] 和 s2[i]  是一组等价字符。
    /// 
    /// * For example, if s1 = "abc" and s2 = "cde", then we have 'a' == 'c', 'b' == 'd', and 'c' == 'e'.
    /// * 举个例子，如果 s1 = "abc" 且 s2 = "cde"，那么就有 'a' == 'c', 'b' == 'd', 'c' == 'e'。
    /// 
    /// Equivalent characters follow the usual rules of any equivalence relation:
    /// 等价字符遵循任何等价关系的一般规则：
    /// 
    /// * Reflexivity: 'a' == 'a'.
    /// * 自反性 ：'a' == 'a'
    /// 
    /// * Symmetry: 'a' == 'b' implies 'b' == 'a'.
    /// * 对称性 ：'a' == 'b' 则必定有 'b' == 'a'
    /// 
    /// * Transitivity: 'a' == 'b' and 'b' == 'c' implies 'a' == 'c'.
    /// * 传递性 ：'a' == 'b' 且 'b' == 'c' 就表明 'a' == 'c'
    /// 
    /// For example, given the equivalency information from s1 = "abc" and s2 = "cde", "acd" and "aab" are equivalent strings of baseStr = "eed", and "aab" is the lexicographically smallest equivalent string of baseStr.
    /// 例如， s1 = "abc" 和 s2 = "cde" 的等价信息和之前的例子一样，那么 baseStr = "eed" , "acd" 或 "aab"，这三个字符串都是等价的，而 "aab" 是 baseStr 的按字典序最小的等价字符串
    /// 
    /// Return the lexicographically smallest equivalent string of baseStr by using the equivalency information from s1 and s2.
    /// 利用 s1 和 s2 的等价信息，找出并返回 baseStr 的按字典序排列最小的等价字符串。
    /// 
    /// </summary>
    public class Lexicographically_Smallest_Equivalent_String
    {
        public class UnionFind
        {
            private int[] parent;

            public UnionFind(int n)
            {
                parent = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                }
            }

            public int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            public void Unite(int x, int y)
            {
                x = Find(x);
                y = Find(y);
                if (x == y)
                {
                    return;
                }
                if (x > y)
                {
                    int temp = x;
                    x = y;
                    y = temp;
                }
                // 总是让字典序更小的作为集合代表字符
                parent[y] = x;
            }
        }

        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="baseStr"></param>
        /// <returns></returns>
        public string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            var uf = new UnionFind(26);
            for (int i = 0; i < s1.Length; i++)
            {
                uf.Unite(s1[i] - 'a', s2[i] - 'a');
            }

            char[] result = new char[baseStr.Length];
            for (int i = 0; i < baseStr.Length; i++)
            {
                result[i] = (char)('a' + uf.Find(baseStr[i] - 'a'));
            }
            return new string(result);
        }
    }
}
