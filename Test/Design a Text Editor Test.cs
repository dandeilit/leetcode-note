using static Code.Design_a_Text_Editor;

namespace Test
{
    public class Design_a_Text_Editor_Test
    {
        public static TheoryData<string[], object[][], object[]> TestData => new TheoryData<string[], object[][], object[]>()
        {
            { ["TextEditor", "addText", "deleteText", "addText", "cursorRight", "cursorLeft", "deleteText", "cursorLeft", "cursorRight"],[[], ["leetcode"], [4], ["practice"], [3], [8], [10], [2], [6]],[null, null, 4, null, "etpractice", "leet", 4, "", "practi"]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] commands, object[][] paramters, object[] expected)
        {
            var actual = new object[commands.Length];

            TextEditor textEditor = new TextEditor();
            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "addText":
                        textEditor.AddText((string)paramters[i][0]);
                        actual[i] = null;
                        break;
                    case "deleteText":
                        actual[i] = textEditor.DeleteText((int)paramters[i][0]);
                        break;
                    case "cursorLeft":
                        actual[i] = textEditor.CursorLeft((int)paramters[i][0]);
                        break;
                    case "cursorRight":
                        actual[i] = textEditor.CursorRight((int)paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] commands, object[][] paramters, object[] expected)
        {
            var actual = new object[commands.Length];

            TextEditor2 textEditor = new TextEditor2();
            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "addText":
                        textEditor.AddText((string)paramters[i][0]);
                        actual[i] = null;
                        break;
                    case "deleteText":
                        actual[i] = textEditor.DeleteText((int)paramters[i][0]);
                        break;
                    case "cursorLeft":
                        actual[i] = textEditor.CursorLeft((int)paramters[i][0]);
                        break;
                    case "cursorRight":
                        actual[i] = textEditor.CursorRight((int)paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(string[] commands, object[][] paramters, object[] expected)
        {
            var actual = new object[commands.Length];

            TextEditor3 textEditor = new TextEditor3();
            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "addText":
                        textEditor.AddText((string)paramters[i][0]);
                        actual[i] = null;
                        break;
                    case "deleteText":
                        actual[i] = textEditor.DeleteText((int)paramters[i][0]);
                        break;
                    case "cursorLeft":
                        actual[i] = textEditor.CursorLeft((int)paramters[i][0]);
                        break;
                    case "cursorRight":
                        actual[i] = textEditor.CursorRight((int)paramters[i][0]);
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
