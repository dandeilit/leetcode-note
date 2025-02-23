using Code;

namespace Test
{
    public class Design_Skiplist_Test
    {
        public static TheoryData<string[], int[][], bool?[]> TestData => new TheoryData<string[], int[][], bool?[]>()
        {
            { ["Skiplist", "add", "add", "add", "search", "add", "search", "erase", "erase", "search"],[[], [1], [2], [3], [0], [4], [1], [0], [1], [1]],[null, null, null, null, false, null, true, false, true, false]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] operators, int[][] paramters, bool?[] expected)
        {
            var skiplist = new Design_Skiplist.Skiplist();
            var actual = new bool?[operators.Length];
            for (var i = 0; i < operators.Length; i++)
            {
                switch (operators[i])
                {
                    case "search":
                        actual[i] = skiplist.Search(paramters[i][0]);
                        break;
                    case "add":
                        skiplist.Add(paramters[i][0]);
                        actual[i] = null;
                        break;
                    case "erase":
                        actual[i] = skiplist.Erase(paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }
    }
}
