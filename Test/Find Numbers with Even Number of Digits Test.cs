using Code;

namespace Test
{
    public class Find_Numbers_with_Even_Number_of_Digits_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [12,345,2,6,7896],2},
            { [555,901,482,1771],1},
            { [100000],1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var find_Numbers_with_Even_Number_of_Digits = new Find_Numbers_with_Even_Number_of_Digits();
            var actual = find_Numbers_with_Even_Number_of_Digits.FindNumbers(nums);
            Assert.Equal(expected, actual);
        }
    }
}
