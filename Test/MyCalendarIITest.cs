using Code;

namespace Test
{
    public class MyCalendarIITest
    {
        public static TheoryData<string[], int[][], bool?[]> TestData => new TheoryData<string[], int[][], bool?[]>()
        {
            {["MyCalendarTwo", "book", "book", "book", "book", "book", "book"],[[], [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]],[null, true, true, true, false, true, true] },
        };

        private bool?[] GetActual(MyCalendarII myCalendarII, string[] eventKey, int[][] eventValue)
        {
            var actual = new Queue<bool?>();
            for (var i = 0; i < eventKey.Length; i++)
            {
                if (eventKey[i] == "book")
                {
                    actual.Enqueue(myCalendarII.Book(eventValue[i][0], eventValue[i][1]));
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
            var myCalendarII = new MyCalendarII.MyCalendar1();
            var actual = GetActual(myCalendarII, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] eventKey, int[][] eventValue, bool?[] expected)
        {
            var myCalendarII = new MyCalendarII.MyCalendar2();
            var actual = GetActual(myCalendarII, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(string[] eventKey, int[][] eventValue, bool?[] expected)
        {
            var myCalendarII = new MyCalendarII.MyCalendar3();
            var actual = GetActual(myCalendarII, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }
    }
}
