using Code;

namespace Test
{
    public class Sum_of_Beauty_in_the_Array_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [1,2,3],2},
            { [2,4,6,4],1},
            { [3,2,1],0},
            { [6,8,3,7,8,9,4,8],2},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var sum_of_Beauty_in_the_Array = new Sum_of_Beauty_in_the_Array();
            var actual = sum_of_Beauty_in_the_Array.SumOfBeauties(nums);

            Assert.Equal(expected, actual);
        }
    }
}
