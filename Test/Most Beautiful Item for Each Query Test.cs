using Code;

namespace Test
{
    public class Most_Beautiful_Item_for_Each_Query_Test
    {
        public static TheoryData<int[][], int[], int[]> TestData => new TheoryData<int[][], int[], int[]>()
        {
            { [[1,2],[3,2],[2,4],[5,6],[3,5]],[1,2,3,4,5,6],[2,4,5,5,6,6]},
            { [[1,2],[1,2],[1,3],[1,4]],[1],[4]},
            { [[10,1000]],[5],[0]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] items, int[] queries, int[] expected)
        {
            var most_Beautiful_Item_for_Each_Query = new Most_Beautiful_Item_for_Each_Query();
            var actual = most_Beautiful_Item_for_Each_Query.MaximumBeauty(items, queries);

            Assert.Equal(expected, actual);
        }
    }
}
