using Code;

namespace Test
{
    public class Where_Will_the_Ball_Fall_Test
    {
        public static TheoryData<int[][], int[]> TestData => new TheoryData<int[][], int[]>()
        {
            { [[1,1,1,-1,-1],[1,1,1,-1,-1],[-1,-1,-1,1,1],[1,1,1,1,-1],[-1,-1,-1,-1,-1]],[1,-1,-1,-1,-1]},
            { [[-1]],[-1]},
            { [[1,1,1,1,1,1],[-1,-1,-1,-1,-1,-1],[1,1,1,1,1,1],[-1,-1,-1,-1,-1,-1]],[0,1,2,3,4,-1]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] grid, int[] expected)
        {
            var where_Will_the_Ball_Fall = new Where_Will_the_Ball_Fall();
            var actual = where_Will_the_Ball_Fall.FindBall(grid);

            Assert.Equal(expected, actual);
        }
    }
}
