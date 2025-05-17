using Code;

namespace Test
{
    public class Sort_Colors_Test
    {
        public static TheoryData<int[], int[]> TestData => new TheoryData<int[], int[]> {
            { [2,0,2,1,1,0],[0,0,1,1,2,2]},
            { [2,0,1],[0,1,2]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[] expected)
        {
            var sort_Colors = new Sort_Colors();
            sort_Colors.SortColors(nums);
            Assert.Equal(expected, nums);
        }
    }
}
