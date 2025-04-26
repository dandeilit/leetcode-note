using Code;

namespace Test
{
    public class Count_Subarrays_With_Fixed_Bounds_Test
    {
        public static TheoryData<int[], int, int, long> TestData => new TheoryData<int[], int, int, long> {
            { [1,3,5,2,7,5],1,5,2},
            { [1,1,1,1],1,1,10},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int minK, int maxK, long expected)
        {
            var count_Subarrays_With_Fixed_Bounds = new Count_Subarrays_With_Fixed_Bounds();
            var actual = count_Subarrays_With_Fixed_Bounds.CountSubarrays(nums, minK, maxK);
            Assert.Equal(expected, actual);
        }
    }
}
