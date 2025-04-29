using Code;

namespace Test
{
    public class Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times_Test
    {
        public static TheoryData<int[], int, long> TestData => new TheoryData<int[], int, long> {
            { [1,3,2,3,3],2,6},
            { [1,4,2,1],3,0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, long expected)
        {
            var count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times = new Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times();
            var actual = count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times.CountSubarrays(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}
