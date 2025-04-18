using Code;

namespace Test
{
    public class Count_Number_of_Bad_Pairs_Test
    {
        public static TheoryData<int[], long> TestData => new TheoryData<int[], long> {
            { [4,1,3,3],5},
            { [1,2,3,4,5],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, long expected)
        {
            var count_Number_of_Bad_Pairs = new Count_Number_of_Bad_Pairs();
            var actual = count_Number_of_Bad_Pairs.CountBadPairs(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, long expected)
        {
            var count_Number_of_Bad_Pairs = new Count_Number_of_Bad_Pairs();
            var actual = count_Number_of_Bad_Pairs.CountBadPairs2(nums);
            Assert.Equal(expected, actual);
        }
    }
}
