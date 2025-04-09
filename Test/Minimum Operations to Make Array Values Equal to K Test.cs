using Code;

namespace Test
{
    public class Minimum_Operations_to_Make_Array_Values_Equal_to_K_Test
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [5,2,5,4,5],2,2},
            { [2,1,2],2,-1},
            { [9,7,5,3],1,4},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var minimum_Operations_to_Make_Array_Values_Equal_to_K = new Minimum_Operations_to_Make_Array_Values_Equal_to_K();
            var actual = minimum_Operations_to_Make_Array_Values_Equal_to_K.MinOperations(nums, k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int k, int expected)
        {
            var minimum_Operations_to_Make_Array_Values_Equal_to_K = new Minimum_Operations_to_Make_Array_Values_Equal_to_K();
            var actual = minimum_Operations_to_Make_Array_Values_Equal_to_K.MinOperations2(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}
