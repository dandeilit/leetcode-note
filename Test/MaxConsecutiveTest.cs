using Code;

namespace Test
{
    public class MaxConsecutiveTest
    {
        public static TheoryData<int, int, int[], int> TestData => new TheoryData<int, int, int[], int>()
        {
            {2,9,[4,6],3 },
            {6,8,[7,6,8],0 },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int bottom, int top, int[] special, int expected)
        {
            var maxConsecutive = new MaxConsecutive();
            var actual = maxConsecutive.Solution(bottom, top, special);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int bottom, int top, int[] special, int expected)
        {
            var maxConsecutive = new MaxConsecutive();
            var actual = maxConsecutive.Solution2(bottom, top, special);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(int bottom, int top, int[] special, int expected)
        {
            var maxConsecutive = new MaxConsecutive();
            var actual = maxConsecutive.Solution3(bottom, top, special);

            Assert.Equal(expected, actual);
        }
    }
}
