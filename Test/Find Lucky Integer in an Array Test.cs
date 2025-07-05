using Code;

namespace Test
{
    public class Find_Lucky_Integer_in_an_Array_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [2,2,3,4],2},
            { [1,2,2,3,3,3],3},
            { [2,2,2,3,3],-1},
            { [5],-1},
            { [7,7,7,7,7,7,7],7},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] arr, int expected)
        {
            var find_Lucky_Integer_in_an_Array = new Find_Lucky_Integer_in_an_Array();
            var actual = find_Lucky_Integer_in_an_Array.FindLucky(arr);
            Assert.Equal(expected, actual);
        }
    }
}
