using Code;

namespace Test
{
    public class The_Number_of_Beautiful_Subsets_Test
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [2,4,6],2,4},
            { [1],1,1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var the_Number_of_Beautiful_Subsets = new The_Number_of_Beautiful_Subsets();
            var actual = the_Number_of_Beautiful_Subsets.BeautifulSubsets(nums, k);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int k, int expected)
        {
            var the_Number_of_Beautiful_Subsets = new The_Number_of_Beautiful_Subsets();
            var actual = the_Number_of_Beautiful_Subsets.BeautifulSubsets2(nums, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(int[] nums, int k, int expected)
        {
            var the_Number_of_Beautiful_Subsets = new The_Number_of_Beautiful_Subsets();
            var actual = the_Number_of_Beautiful_Subsets.BeautifulSubsets3(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
