using Code;

namespace Test
{
    public class Maximum_Distance_in_Arrays_Test
    {
        public static TheoryData<int[][], int> TestData => new TheoryData<int[][], int>()
        {
            { [[1,2,3],[4,5],[1,2,3]],4},
            { [[1],[1]],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] arrays, int expected)
        {
            var maximum_Distance_in_Arrays = new Maximum_Distance_in_Arrays();
            var actual = maximum_Distance_in_Arrays.MaxDistance(arrays);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[][] arrays, int expected)
        {
            var maximum_Distance_in_Arrays = new Maximum_Distance_in_Arrays();
            var actual = maximum_Distance_in_Arrays.MaxDistance2(arrays);

            Assert.Equal(expected, actual);
        }
    }
}
