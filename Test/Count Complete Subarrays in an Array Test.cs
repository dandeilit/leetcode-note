using Code;

namespace Test
{
    public class Count_Complete_Subarrays_in_an_Array_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [1,3,1,2,2],4},
            { [5,5,5,5],10},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var count_Complete_Subarrays_in_an_Array = new Count_Complete_Subarrays_in_an_Array();
            var actual = count_Complete_Subarrays_in_an_Array.CountCompleteSubarrays(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int expected)
        {
            var count_Complete_Subarrays_in_an_Array = new Count_Complete_Subarrays_in_an_Array();
            var actual = count_Complete_Subarrays_in_an_Array.CountCompleteSubarrays2(nums);
            Assert.Equal(expected, actual);
        }
    }
}
