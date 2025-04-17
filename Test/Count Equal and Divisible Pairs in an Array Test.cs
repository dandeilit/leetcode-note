using Code;

namespace Test
{
    public class Count_Equal_and_Divisible_Pairs_in_an_Array_Test
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int> {
            { [3,1,2,2,2,1,3],2,4},
            { [1,2,3,4],1,0},
            { [5,5,9,2,5,5,9,2,2,5,5,6,2,2,5,2,5,4,3],7,18}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var count_Equal_and_Divisible_Pairs_in_an_Array = new Count_Equal_and_Divisible_Pairs_in_an_Array();
            var actual = count_Equal_and_Divisible_Pairs_in_an_Array.CountPairs(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}
