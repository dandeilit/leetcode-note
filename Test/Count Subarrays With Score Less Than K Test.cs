using Code;

namespace Test
{
    public class Count_Subarrays_With_Score_Less_Than_K_Test
    {
        public static TheoryData<int[], long, long> TestData => new TheoryData<int[], long, long> {
            { [2,1,4,3,5],10,6},
            { [1,1,1],5,5},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, long k, long expected)
        {
            var count_Subarrays_With_Score_Less_Than_K = new Count_Subarrays_With_Score_Less_Than_K();
            var actual = count_Subarrays_With_Score_Less_Than_K.CountSubarrays(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}
