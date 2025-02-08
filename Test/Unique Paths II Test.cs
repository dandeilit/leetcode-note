using Code;

namespace Test
{
    public class Unique_Paths_II_Test
    {
        public static TheoryData<int[][], int> TestData => new TheoryData<int[][], int>()
        {
            { [[0,0,0],[0,1,0],[0,0,0]],2},
            { [[0,1],[0,0]],1},
            { [[0,0]],1},
            { [[0,0],[0,1]],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] obstacleGrid, int expected)
        {
            var unique_Paths_II = new Unique_Paths_II();
            var actual = unique_Paths_II.UniquePathsWithObstacles(obstacleGrid);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[][] obstacleGrid, int expected)
        {
            var unique_Paths_II = new Unique_Paths_II();
            var actual = unique_Paths_II.UniquePathsWithObstacles2(obstacleGrid);

            Assert.Equal(expected, actual);
        }
    }
}
