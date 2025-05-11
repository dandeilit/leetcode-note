using Code;

namespace Test
{
    public class Three_Consecutive_Odds_Test
    {
        public static TheoryData<int[], bool> TestData => new TheoryData<int[], bool> {
            { [2,6,4,1],false},
            { [1,2,34,3,4,5,7,23,12],true},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] arr, bool expected)
        {
            var three_Consecutive_Odds = new Three_Consecutive_Odds();
            var actual = three_Consecutive_Odds.ThreeConsecutiveOdds(arr);
            Assert.Equal(expected, actual);
        }
    }
}
