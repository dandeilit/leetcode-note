using Code;

namespace Test
{
    public class Count_Symmetric_Integers_Test
    {
        public static TheoryData<int, int, int> TestData => new TheoryData<int, int, int>()
        {
            { 1,100,9},
            { 1200,1230,4},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int low, int high, int expected)
        {
            var count_Symmetric_Integers = new Count_Symmetric_Integers();
            var actual = count_Symmetric_Integers.CountSymmetricIntegers(low, high);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int low, int high, int expected)
        {
            var count_Symmetric_Integers = new Count_Symmetric_Integers();
            var actual = count_Symmetric_Integers.CountSymmetricIntegers2(low, high);
            Assert.Equal(expected, actual);
        }
    }
}
