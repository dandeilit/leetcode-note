using Code;

namespace Test
{
    public class Minimum_Limit_of_Balls_in_a_Bag_Test
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [9],2,3},
            { [2,4,8,2],4,2},
            { [7,17],2,7},
            { [431,922,158,60,192,14,788,146,788,775,772,792,68,143,376,375,877,516,595,82,56,704,160,403,713,504,67,332,26],80,129}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int maxOperations, int expected)
        {
            var minimum_Limit_of_Balls_in_a_Bag = new Minimum_Limit_of_Balls_in_a_Bag();
            var actual = minimum_Limit_of_Balls_in_a_Bag.MinimumSize(nums, maxOperations);

            Assert.Equal(expected, actual);
        }
    }
}
