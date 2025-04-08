using Code;

namespace Test
{
    public class Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [1,2,3,4,2,3,3,5,7],2},
            { [4,5,6,4,4],2},
            { [6,7,8,9],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct = new Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct();
            var actual = minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct.MinimumOperations(nums);
            Assert.Equal(expected, actual);
        }
    }
}
