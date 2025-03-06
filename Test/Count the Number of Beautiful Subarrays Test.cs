using Code;

namespace Test
{
    public class Count_the_Number_of_Beautiful_Subarrays_Test
    {
        public static TheoryData<int[], long> TestData => new TheoryData<int[], long>()
        {
            { [4,3,1,2,4],2},
            { [1,10,4],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, long expected)
        {
            var count_the_Number_of_Beautiful_Subarrays = new Count_the_Number_of_Beautiful_Subarrays();
            var actual = count_the_Number_of_Beautiful_Subarrays.BeautifulSubarrays(nums);

            Assert.Equal(expected, actual);
        }
    }
}
