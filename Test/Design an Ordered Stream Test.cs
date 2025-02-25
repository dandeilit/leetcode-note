using Code;

namespace Test
{
    public class Design_an_Ordered_Stream_Test
    {
        public static TheoryData<int, string[], (int, string)[], string[][]> TestData => new TheoryData<int, string[], (int, string)[], string[][]>()
        {
            { 5, ["insert", "insert", "insert", "insert", "insert"],[(3, "ccccc"), (1, "aaaaa"), (2, "bbbbb"), (5, "eeeee"), (4, "ddddd")],[[], ["aaaaa"], ["bbbbb", "ccccc"], [], ["ddddd", "eeeee"]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, string[] commands, (int, string)[] paramters, string[][] expected)
        {
            var actual = new string[commands.Length][];
            var obj = new Design_an_Ordered_Stream.OrderedStream(n);

            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "insert":
                        actual[i] = obj.Insert(paramters[i].Item1, paramters[i].Item2).ToArray();
                        break;
                    default:
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }
    }
}
