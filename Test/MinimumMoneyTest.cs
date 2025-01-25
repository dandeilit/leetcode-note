using Code;

namespace Test
{
    public class MinimumMoneyTest
    {
        public static TheoryData<int[][], long> TestData => new TheoryData<int[][], long>()
        {
            { [[2,1],[5,0],[4,2]],10},
            { [[3,0],[0,3]],3},
            { [[7,2],[0,10],[5,0],[4,1],[5,8],[5,9]],18},
            { [[3,9],[0,4],[7,10],[3,5],[0,9],[9,3],[7,4],[0,0],[3,3],[8,0]],24},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] transactions, long expected)
        {
            var minimumMoney = new MinimumMoney();
            var actual = minimumMoney.Solution(transactions);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[][] transactions, long expected)
        {
            var minimumMoney = new MinimumMoney();
            var actual = minimumMoney.Solution2(transactions);

            Assert.Equal(expected, actual);
        }
    }
}
