using Code;

namespace Test
{
    public class Find_the_Count_of_Good_Integers_Test
    {
        public static TheoryData<int, int, long> TestData => new TheoryData<int, int, long> {
            { 3,5,27},
            { 1,4,2},
            { 5,6,2468},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int k, long expected)
        {
            var find_the_Count_of_Good_Integers = new Find_the_Count_of_Good_Integers();
            var actual = find_the_Count_of_Good_Integers.CountGoodIntegers(n, k);
            Assert.Equal(expected, actual);
        }
    }
}
