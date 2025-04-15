using Code;

namespace Test
{
    public class Count_Good_Triplets_in_an_Array_Test
    {
        public static TheoryData<int[], int[], long> TestData => new TheoryData<int[], int[], long> {
            { [2,0,1,3],[0,1,2,3],1},
            { [4,0,1,3,2],[4,1,0,2,3],4},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums1, int[] nums2, long expected)
        {
            var count_Good_Triplets_in_an_Array = new Count_Good_Triplets_in_an_Array();
            var actual = count_Good_Triplets_in_an_Array.GoodTriplets(nums1, nums2);
            Assert.Equal(expected, actual);
        }
    }
}
