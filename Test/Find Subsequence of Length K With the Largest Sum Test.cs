using Code;

namespace Test
{
    public class Find_Subsequence_of_Length_K_With_the_Largest_Sum_Test
    {
        public static TheoryData<int[], int, int[]> TestData => new TheoryData<int[], int, int[]> {
            { [2,1,3,3],2,[3,3]},
            { [-1,-2,3,4],3,[-1,3,4]},
            { [3,4,3,3],2,[3,4]},
            { [50,-75],2,[50,-75]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int[] expected)
        {
            var find_Subsequence_of_Length_K_With_the_Largest_Sum = new Find_Subsequence_of_Length_K_With_the_Largest_Sum();
            var actual = find_Subsequence_of_Length_K_With_the_Largest_Sum.MaxSubsequence(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}
