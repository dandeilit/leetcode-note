using Code;

namespace Test
{
    public class Finding_3_Digit_Even_Numbers_Test
    {
        public static TheoryData<int[], int[]> TestData => new TheoryData<int[], int[]> {
            { [2,1,3,0],[102,120,130,132,210,230,302,310,312,320]},
            { [2,2,8,8,2],[222,228,282,288,822,828,882]},
            { [3,7,5],[]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] digits, int[] expected)
        {
            var finding_3_Digit_Even_Numbers = new Finding_3_Digit_Even_Numbers();
            var actual = finding_3_Digit_Even_Numbers.FindEvenNumbers(digits);
            Assert.Equal(expected, actual);
        }
    }
}
