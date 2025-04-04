using Code;

namespace Test
{
    public class Lowest_Common_Ancestor_of_Deepest_Leaves_Test
    {
        public static TheoryData<int?[], int?[]> TestData => new TheoryData<int?[], int?[]>()
        {
            { [3,5,1,6,2,0,8,null,null,7,4],[2,7,4]},
            { [1],[1]},
            { [0,1,3,null,2],[2]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int?[] arr, int?[] expected)
        {
            var lowest_Common_Ancestor_of_Deepest_Leaves = new Lowest_Common_Ancestor_of_Deepest_Leaves();
            var actual = lowest_Common_Ancestor_of_Deepest_Leaves.LcaDeepestLeaves(arr.ToTree());
            Assert.Equal(expected, actual.ToArray());
        }
    }
}
