using Code;

namespace Test
{
    public class Count_Subarrays_of_Length_Three_With_a_Condition_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [1,2,1,4,1],1},
            { [1,1,1],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var count_Subarrays_of_Length_Three_With_a_Condition = new Count_Subarrays_of_Length_Three_With_a_Condition();
            var actual = count_Subarrays_of_Length_Three_With_a_Condition.CountSubarrays(nums);
            Assert.Equal(expected, actual);
        }
    }
}
