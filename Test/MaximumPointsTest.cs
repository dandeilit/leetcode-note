using Code;

namespace Test
{
    public class MaximumPointsTest
    {
        public static TheoryData<int[][], int[], int, int> TestData => new TheoryData<int[][], int[], int, int>()
        {
            { [[0,1],[1,2],[2,3]],[10,10,3,3],5,11},
            { [[0,1],[0,2]],[8,4,4],0,16},
            { [[0,1],[2,0],[0,3],[4,2]],[7,5,0,9,3],4,10},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] edges, int[] coins, int k, int expected)
        {
            var maximumPoints = new MaximumPoints();
            var actual = maximumPoints.Solution(edges, coins, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[][] edges, int[] coins, int k, int expected)
        {
            var maximumPoints = new MaximumPoints();
            var actual = maximumPoints.Solution2(edges, coins, k);

            Assert.Equal(expected, actual);
        }
    }
}
