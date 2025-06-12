using Code;

namespace Test
{
    public class Maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [1,2,4],3},
            { [-5,-10,-5],5},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array = new Maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array();
            var actual = maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array.MaxAdjacentDistance(nums);
            Assert.Equal(expected, actual);
        }
    }
}
