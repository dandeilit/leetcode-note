using Code;

namespace Test
{
    public class Range_Addition_II_Test
    {
        public static TheoryData<int, int, int[][], int> TestData => new TheoryData<int, int, int[][], int>()
        {
            { 3,3,[[2,2],[3,3]],4},
            { 3,3,[[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3]],4},
            { 3,3,[],9},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int m, int n, int[][] ops, int expected)
        {
            var range_Addition_II = new Range_Addition_II();
            var actual = range_Addition_II.MaxCount(m, n, ops);

            Assert.Equal(expected, actual);
        }
    }
}
