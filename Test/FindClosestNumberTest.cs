using Code;

namespace Test
{
    public class FindClosestNumberTest
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [-4,-2,1,4,8], 1},
            { [2,-1,1], 1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var findClosestNumber = new FindClosestNumber();
            var actual = findClosestNumber.Solution(nums);

            Assert.Equal(expected, actual);
        }
    }
}
