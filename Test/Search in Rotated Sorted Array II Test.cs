using Code;

namespace Test
{
    public class Search_in_Rotated_Sorted_Array_II_Test
    {
        public static TheoryData<int[], int, bool> TestData => new TheoryData<int[], int, bool>()
        {
            { [2,5,6,0,0,1,2],0,true},
            { [2,5,6,0,0,1,2],3,false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int target, bool expected)
        {
            var search_in_Rotated_Sorted_Array_II = new Search_in_Rotated_Sorted_Array_II();
            var actual = search_in_Rotated_Sorted_Array_II.Search(nums, target);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int target, bool expected)
        {
            var search_in_Rotated_Sorted_Array_II = new Search_in_Rotated_Sorted_Array_II();
            var actual = search_in_Rotated_Sorted_Array_II.Search2(nums, target);

            Assert.Equal(expected, actual);
        }
    }
}
