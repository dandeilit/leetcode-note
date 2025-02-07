using Code;

namespace Test
{
    public class Spiral_Matrix_II_Test
    {
        public static TheoryData<int, int[][]> TestData => new TheoryData<int, int[][]>()
        {
            { 3,[[1,2,3],[8,9,4],[7,6,5]]},
            { 1,[[1]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int[][] expected)
        {
            var spiral_Matrix_II = new Spiral_Matrix_II();
            var actual = spiral_Matrix_II.GenerateMatrix(n);

            Assert.Equal(expected, actual);
        }
    }
}
