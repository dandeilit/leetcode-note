using Code;

namespace Test
{
    public class Subsets_II_Test
    {
        public static TheoryData<int[], int[][]> TestData => new TheoryData<int[], int[][]>()
        {
            { [1,2,2],[[],[1],[1,2],[1,2,2],[2],[2,2]]},
            { [0],[[],[0]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[][] expected)
        {
            var subsets_II = new Subsets_II();
            var actual = subsets_II.SubsetsWithDup(nums);

            Assert.Equal(expected.Length, actual.Count);
            foreach (var item in actual)
            {
                Assert.Contains(item, expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int[][] expected)
        {
            var subsets_II = new Subsets_II();
            var actual = subsets_II.SubsetsWithDup2(nums);

            Assert.Equal(expected.Length, actual.Count);
            foreach (var item in actual)
            {
                Assert.Contains(item, expected);
            }
        }
    }
}
