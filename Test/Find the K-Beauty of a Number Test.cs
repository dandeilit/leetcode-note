using Code;

namespace Test
{
    public class Find_the_K_Beauty_of_a_Number_Test
    {
        public static TheoryData<int, int, int> TestData => new TheoryData<int, int, int>()
        {
            { 240,2,2},
            { 430043,2,2},
            { 10,1,1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int num, int k, int expected)
        {
            var find_the_K_Beauty_of_a_Number = new Find_the_K_Beauty_of_a_Number();
            var actual = find_the_K_Beauty_of_a_Number.DivisorSubstrings(num, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int num, int k, int expected)
        {
            var find_the_K_Beauty_of_a_Number = new Find_the_K_Beauty_of_a_Number();
            var actual = find_the_K_Beauty_of_a_Number.DivisorSubstrings2(num, k);

            Assert.Equal(expected, actual);
        }
    }
}
