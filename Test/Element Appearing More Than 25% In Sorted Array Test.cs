using Code;

namespace Test
{
    public class Element_Appearing_More_Than_25__In_Sorted_Array_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [1,2,2,6,6,6,6,7,10],6},
            { [1,1],1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] arr, int expected)
        {
            var element_Appearing_More_Than_25__In_Sorted_Array = new Element_Appearing_More_Than_25__In_Sorted_Array();
            var actual = element_Appearing_More_Than_25__In_Sorted_Array.FindSpecialInteger(arr);

            Assert.Equal(expected, actual);
        }
    }
}
