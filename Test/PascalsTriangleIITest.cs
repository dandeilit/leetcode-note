using Code;

namespace Test
{
    public class PascalsTriangleIITest
    {
        public static TheoryData<int, int[]> TestData => new TheoryData<int, int[]>()
        {
            { 3,[1,3,3,1]},
            { 0,[1]},
            { 1,[1,1]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int rowIndex, int[] expected)
        {
            var pascalsTriangleII = new PascalsTriangleII();
            var actual = pascalsTriangleII.GetRow(rowIndex);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int rowIndex, int[] expected)
        {
            var pascalsTriangleII = new PascalsTriangleII();
            var actual = pascalsTriangleII.GetRow2(rowIndex);

            Assert.Equal(expected, actual);
        }
    }
}
