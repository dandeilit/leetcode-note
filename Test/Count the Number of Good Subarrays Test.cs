using Code;

namespace Test
{
    public class Count_the_Number_of_Good_Subarrays_Test
    {
        public static TheoryData<int[], int, long> TestData => new TheoryData<int[], int, long> {
            { [1,1,1,1,1],10,1},
            { [3,1,4,3,2,2,4],2,4},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var count_the_Number_of_Good_Subarrays = new Count_the_Number_of_Good_Subarrays();
            var actual = count_the_Number_of_Good_Subarrays.CountGood(nums, k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int k, int expected)
        {
            var count_the_Number_of_Good_Subarrays = new Count_the_Number_of_Good_Subarrays();
            var actual = count_the_Number_of_Good_Subarrays.CountGood2(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}
