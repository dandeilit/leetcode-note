using Code;

namespace Test
{
    public class Lexicographical_Numbers_Test
    {
        public static TheoryData<int, int[]> TestData => new TheoryData<int, int[]> {
            { 13,[1,10,11,12,13,2,3,4,5,6,7,8,9]},
            { 2,[1,2]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int[] expected)
        {
            var lexicographical_Numbers = new Lexicographical_Numbers();
            var actual = lexicographical_Numbers.LexicalOrder(n);
            Assert.Equal(expected, actual);
        }
    }
}
