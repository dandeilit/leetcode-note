using Code;

namespace Test
{
    public class Determine_the_Minimum_Sum_of_a_k_avoiding_Array_Test
    {
        public static TheoryData<int, int, int> TestData => new TheoryData<int, int, int>()
        {
            { 5,4,18},
            { 2,6,3},
            { 1,1,1},
            { 2,1,3},
            { 3,5,8},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int k, int expected)
        {
            var determine_the_Minimum_Sum_of_a_k_avoiding_Array = new Determine_the_Minimum_Sum_of_a_k_avoiding_Array();
            var actual = determine_the_Minimum_Sum_of_a_k_avoiding_Array.MinimumSum(n, k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int n, int k, int expected)
        {
            var determine_the_Minimum_Sum_of_a_k_avoiding_Array = new Determine_the_Minimum_Sum_of_a_k_avoiding_Array();
            var actual = determine_the_Minimum_Sum_of_a_k_avoiding_Array.MinimumSum2(n, k);
            Assert.Equal(expected, actual);
        }
    }
}
