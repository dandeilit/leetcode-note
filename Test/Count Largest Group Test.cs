using Code;

namespace Test
{
    public class Count_Largest_Group_Test
    {
        public static TheoryData<int, int> TestData => new TheoryData<int, int> {
            { 13,4},
            { 2,2},
            { 15,6},
            { 24,5},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int expected)
        {
            var count_Largest_Group = new Count_Largest_Group();
            var actual = count_Largest_Group.CountLargestGroup(n);
            Assert.Equal(expected, actual);
        }
    }
}
