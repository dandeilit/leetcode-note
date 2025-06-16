using Code;

namespace Test
{
    public class Maximum_Difference_Between_Increasing_Elements_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [7,1,5,4],4},
            { [9,4,3,2],-1},
            { [1,5,2,10],9},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var maximum_Difference_Between_Increasing_Elements = new Maximum_Difference_Between_Increasing_Elements();
            var actual = maximum_Difference_Between_Increasing_Elements.MaximumDifference(nums);
            Assert.Equal(expected, actual);
        }
    }
}
