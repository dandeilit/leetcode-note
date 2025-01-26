using Code;

namespace Test
{
    public class CombinationSum2Test
    {
        public static TheoryData<int[], int, int[][]> TestData => new TheoryData<int[], int, int[][]>()
        {
            { [ 10, 1, 2, 7, 6, 1, 5], 8, [ [ 1, 7 ], [ 1, 2, 5 ], [ 2, 6 ], [ 1, 1, 6 ] ] },
            { [ 2, 5, 2, 1, 2 ], 5, [ [ 1, 2, 2 ], [ 5 ] ] },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] candidates, int target, int[][] expected)
        {
            var combinationSum2 = new CombinationSum2();
            var actual = combinationSum2.Solution(candidates, target);

            actual = actual.OrderBy(x => x.Count).ThenBy(x => x.Last()).ToArray();
            expected = expected.OrderBy(x => x.Length).ThenBy(x => x.Last()).ToArray();

            Assert.Equal(expected, actual);
        }
    }
}
