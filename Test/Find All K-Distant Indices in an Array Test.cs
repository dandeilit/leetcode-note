using Code;

namespace Test
{
    public class Find_All_K_Distant_Indices_in_an_Array_Test
    {
        public static TheoryData<int[], int, int, int[]> TestData => new TheoryData<int[], int, int, int[]> {
            { [3,4,9,1,3,9,5],9,1,[1,2,3,4,5,6]},
            { [2,2,2,2,2],2,2,[0,1,2,3,4]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int key, int k, int[] expected)
        {
            var find_All_K_Distant_Indices_in_an_Array = new Find_All_K_Distant_Indices_in_an_Array();
            var actual = find_All_K_Distant_Indices_in_an_Array.FindKDistantIndices(nums, key, k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int key, int k, int[] expected)
        {
            var find_All_K_Distant_Indices_in_an_Array = new Find_All_K_Distant_Indices_in_an_Array();
            var actual = find_All_K_Distant_Indices_in_an_Array.FindKDistantIndices2(nums, key, k);
            Assert.Equal(expected, actual);
        }
    }
}
