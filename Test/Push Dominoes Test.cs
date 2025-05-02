using Code;

namespace Test
{
    public class Push_Dominoes_Test
    {
        public static TheoryData<string, string> TestData => new TheoryData<string, string> {
            { "RR.L","RR.L"},
            { ".L.R...LR..L..","LL.RR.LLRRLL.."},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string dominoes, string expected)
        {
            var push_Dominoes = new Push_Dominoes();
            var actual = push_Dominoes.PushDominoes(dominoes);
            Assert.Equal(expected, actual);
        }
    }
}
