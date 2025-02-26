using static Code.Design_Browser_History;

namespace Test
{
    public class Design_Browser_History_Test
    {
        public static TheoryData<string[], object[][], string[]> TestData => new TheoryData<string[], object[][], string[]>()
        {
            { ["BrowserHistory","visit","visit","visit","back","back","forward","visit","forward","back","back"],[["leetcode.com"],["google.com"],["facebook.com"],["youtube.com"],[1],[1],[1],["linkedin.com"],[2],[2],[7]],[null,null,null,null,"facebook.com","google.com","facebook.com",null,"linkedin.com","google.com","leetcode.com"]},
            { ["BrowserHistory","visit","forward","forward","visit","visit","back","visit","visit","forward","back","visit","visit","visit","forward","forward","visit","visit","back","visit","forward","visit","visit","visit","back"],[["jrbilt.com"],["uiza.com"],[3],[3],["fveyl.com"],["hyhqfqf.com"],[3],["cccs.com"],["bivz.com"],[6],[1],["cmbw.com"],["iywwwfn.com"],["sktbhdx.com"],[8],[10],["bskj.com"],["thw.com"],[6],["hgesj.com"],[6],["ctb.com"],["fllnc.com"],["fs.com"],[7]],[null,null,"uiza.com","uiza.com",null,null,"jrbilt.com",null,null,"bivz.com","cccs.com",null,null,null,"sktbhdx.com","sktbhdx.com",null,null,"jrbilt.com",null,"hgesj.com",null,null,null,"jrbilt.com"]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] commands, object[][] paramters, string[] expected)
        {
            var actual = new string[commands.Length];

            BrowserHistory browserHistory = new BrowserHistory((string)paramters[0][0]);

            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "visit":
                        browserHistory.Visit((string)paramters[i][0]);
                        actual[i] = null;
                        break;
                    case "back":
                        actual[i] = browserHistory.Back((int)paramters[i][0]);
                        break;
                    case "forward":
                        actual[i] = browserHistory.Forward((int)paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }
    }
}
