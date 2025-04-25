using Code;

namespace Test
{
    public class Count_of_Interesting_Subarrays_Test
    {
        public static TheoryData<int[], int, int, long> TestData => new TheoryData<int[], int, int, long> {
            { [3,2,4],2,1,3},
            { [3,1,9,6],3,0,2},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int modulo, int k, long expected)
        {
            var count_of_Interesting_Subarrays = new Count_of_Interesting_Subarrays();
            var actual = count_of_Interesting_Subarrays.CountInterestingSubarrays(nums, modulo, k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int modulo, int k, long expected)
        {
            var count_of_Interesting_Subarrays = new Count_of_Interesting_Subarrays();
            var actual = count_of_Interesting_Subarrays.CountInterestingSubarrays2(nums, modulo, k);
            Assert.Equal(expected, actual);
        }
    }
}
