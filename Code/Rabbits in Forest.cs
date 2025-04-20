namespace Code
{
    /// <summary>
    /// 781. Rabbits in Forest
    /// 781. 森林中的兔子
    /// 
    /// There is a forest with an unknown number of rabbits. We asked n rabbits "How many rabbits have the same color as you?" and collected the answers in an integer array answers where answers[i] is the answer of the i-th rabbit.
    /// 森林中有未知数量的兔子。提问其中若干只兔子 "还有多少只兔子与你（指被提问的兔子）颜色相同?" ，将答案收集到一个整数数组 answers 中，其中 answers[i] 是第 i 只兔子的回答。
    /// 
    /// Given the array answers, return the minimum number of rabbits that could be in the forest.
    /// 给你数组 answers ，返回森林中兔子的最少数量。
    /// 
    /// </summary>
    public class Rabbits_in_Forest
    {
        public int NumRabbits(int[] answers)
        {
            int ans = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (var i = 0; i < answers.Length; i++)
            {
                if (!map.ContainsKey(answers[i]))
                {
                    map.Add(answers[i], 1);
                }
                else
                {
                    map[answers[i]]++;
                }
            }

            foreach (var item in map)
            {
                ans += (item.Key + item.Value) / (item.Key + 1) * (item.Key + 1);
            }
            return ans;
        }
    }
}
