using Code;

namespace Test
{
    public class MyCalendarITest
    {
        public static TheoryData<string[], int[][], bool?[]> TestData => new TheoryData<string[], int[][], bool?[]>() {
            { ["MyCalendar", "book", "book", "book"],[[], [10, 20], [15, 25], [20, 30]],[null, true, false, true]},
        };

        private bool?[] GetActual(MyCalendarI myCalendarI, string[] eventKey, int[][] eventValue)
        {
            var actual = new Queue<bool?>();
            for (var i = 0; i < eventKey.Length; i++)
            {
                if (eventKey[i] == "book")
                {
                    actual.Enqueue(myCalendarI.Book(eventValue[i][0], eventValue[i][1]));
                }
                else
                {
                    actual.Enqueue(null);
                }
            }
            return actual.ToArray();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] eventKey, int[][] eventValue, bool?[] expected)
        {
            var myCalendarI = new MyCalendarI.MyCalendar1();
            var actual = GetActual(myCalendarI, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] eventKey, int[][] eventValue, bool?[] expected)
        {
            var myCalendarI = new MyCalendarI.MyCalendar2();
            var actual = GetActual(myCalendarI, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(string[] eventKey, int[][] eventValue, bool?[] expected)
        {
            var myCalendarI = new MyCalendarI.MyCalendar3();
            var actual = GetActual(myCalendarI, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test4(string[] eventKey, int[][] eventValue, bool?[] expected)
        {
            var myCalendarI = new MyCalendarI.MyCalendar4();
            var actual = GetActual(myCalendarI, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }
    }
}
