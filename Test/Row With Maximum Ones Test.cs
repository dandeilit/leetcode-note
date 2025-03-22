using Code;

namespace Test
{
    public class Row_With_Maximum_Ones_Test
    {
        public static TheoryData<int[][], int[]> TestData => new TheoryData<int[][], int[]>()
        {
            { [[0,1],[1,0]],[0,1]},
            { [[0,0,0],[0,1,1]],[1,2]},
            { [[0,0],[1,1],[0,0]],[1,2]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] mat, int[] expected)
        {
            var row_With_Maximum_Ones = new Row_With_Maximum_Ones();
            var actual = row_With_Maximum_Ones.RowAndMaximumOnes(mat);
            Assert.Equal(expected, actual);
        }
    }
}
