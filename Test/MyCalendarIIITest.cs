using Code;

namespace Test
{
    public class MyCalendarIIITest
    {
        public static TheoryData<string[], int[][], int?[]> TestData => new TheoryData<string[], int[][], int?[]>()
        {
            { ["MyCalendarThree", "book", "book", "book", "book", "book", "book"],[[], [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]],[null, 1, 1, 2, 3, 3, 3]},
        };

        private int?[] GetActual(MyCalendarIII myCalendarIII, string[] eventKey, int[][] eventValue)
        {
            var actual = new Queue<int?>();
            for (var i = 0; i < eventKey.Length; i++)
            {
                if (eventKey[i] == "book")
                {
                    actual.Enqueue(myCalendarIII.Book(eventValue[i][0], eventValue[i][1]));
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
        public void Test(string[] eventKey, int[][] eventValue, int?[] expected)
        {
            var myCalendarIII = new MyCalendarIII.MyCalendar1();
            var actual = GetActual(myCalendarIII, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] eventKey, int[][] eventValue, int?[] expected)
        {
            var myCalendarIII = new MyCalendarIII.MyCalendar2();
            var actual = GetActual(myCalendarIII, eventKey, eventValue);

            Assert.Equal(expected, actual);
        }
    }
}
