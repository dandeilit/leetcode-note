using Code;

namespace Test
{
    public class Count_Number_of_Balanced_Permutations_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int> {
            { "123",2},
            { "112",1},
            { "12345",0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string num, int expected)
        {
            var count_Number_of_Balanced_Permutations = new Count_Number_of_Balanced_Permutations();
            var actual = count_Number_of_Balanced_Permutations.CountBalancedPermutations(num);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string num, int expected)
        {
            var count_Number_of_Balanced_Permutations = new Count_Number_of_Balanced_Permutations();
            var actual = count_Number_of_Balanced_Permutations.CountBalancedPermutations2(num);
            Assert.Equal(expected, actual);
        }
    }
}
