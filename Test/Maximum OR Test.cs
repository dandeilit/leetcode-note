using Code;

namespace Test
{
    public class Maximum_OR_Test
    {
        public static TheoryData<int[], int, long> TestData => new TheoryData<int[], int, long>()
        {
            { [12,9],1,30},
            { [8,1,2],2,35},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, long expected)
        {
            var maximum_OR = new Maximum_OR();
            var actual = maximum_OR.MaximumOr(nums, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int k, long expected)
        {
            var maximum_OR = new Maximum_OR();
            var actual = maximum_OR.MaximumOr2(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
