using Code;

namespace Test
{
    public class Permutations_II_Test
    {
        public static TheoryData<int[], int[][]> TestData => new TheoryData<int[], int[][]>()
        {
            { [1,1,2],[[1,1,2],[1,2,1],[2,1,1]]},
            { [1,2,3],[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[][] expected)
        {
            var permutations_II = new Permutations_II();
            var actual = permutations_II.PermuteUnique(nums);

            Assert.Equal(expected, actual);
        }
    }
}
