using Code;

namespace Test
{
    public class Longest_Harmonious_Subsequence_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [1,3,2,2,5,2,3,7],5},
            { [1,2,3,4],2},
            { [1,1,1,1],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var longest_Harmonious_Subsequence = new Longest_Harmonious_Subsequence();
            var actual = longest_Harmonious_Subsequence.FindLHS(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int expected)
        {
            var longest_Harmonious_Subsequence = new Longest_Harmonious_Subsequence();
            var actual = longest_Harmonious_Subsequence.FindLHS2(nums);
            Assert.Equal(expected, actual);
        }
    }
}
