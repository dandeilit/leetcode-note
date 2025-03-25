using Code;

namespace Test
{
    public class Difference_of_Number_of_Distinct_Values_on_Diagonals_Test
    {
        public static TheoryData<int[][], int[][]> TestData => new TheoryData<int[][], int[][]>()
        {
            { [[1,2,3],[3,1,5],[3,2,1]],[[1,1,0],[1,0,1],[0,1,1]]},
            { [[1]],[[0]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] grid, int[][] expected)
        {
            var difference_of_Number_of_Distinct_Values_on_Diagonals = new Difference_of_Number_of_Distinct_Values_on_Diagonals();
            var actual = difference_of_Number_of_Distinct_Values_on_Diagonals.DifferenceOfDistinctValues(grid);
            Assert.Equal(expected, actual);
        }
    }
}
