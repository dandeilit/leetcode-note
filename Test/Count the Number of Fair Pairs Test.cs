using Code;

namespace Test
{
    public class Count_the_Number_of_Fair_Pairs_Test
    {
        public static TheoryData<int[], int, int, long> TestData => new TheoryData<int[], int, int, long> {
            { [0,1,7,4,4,5],3,6,6},
            { [1,7,9,2,5],11,11,1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int lower, int upper, long expected)
        {
            var count_the_Number_of_Fair_Pairs = new Count_the_Number_of_Fair_Pairs();
            var actual = count_the_Number_of_Fair_Pairs.CountFairPairs(nums, lower, upper);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int lower, int upper, long expected)
        {
            var count_the_Number_of_Fair_Pairs = new Count_the_Number_of_Fair_Pairs();
            var actual = count_the_Number_of_Fair_Pairs.CountFairPairs2(nums, lower, upper);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(int[] nums, int lower, int upper, long expected)
        {
            var count_the_Number_of_Fair_Pairs = new Count_the_Number_of_Fair_Pairs();
            var actual = count_the_Number_of_Fair_Pairs.CountFairPairs3(nums, lower, upper);
            Assert.Equal(expected, actual);
        }
    }
}
