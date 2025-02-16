using Code;

namespace Test
{
    public class Replace_Elements_with_Greatest_Element_on_Right_Side_Test
    {
        public static TheoryData<int[], int[]> TestData => new TheoryData<int[], int[]>()
        {
            { [17,18,5,4,6,1],[18,6,6,6,1,-1]},
            { [400],[-1]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] arr, int[] expected)
        {
            var replace_Elements_with_Greatest_Element_on_Right_Side = new Replace_Elements_with_Greatest_Element_on_Right_Side();
            var actual = replace_Elements_with_Greatest_Element_on_Right_Side.ReplaceElements(arr);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] arr, int[] expected)
        {
            var replace_Elements_with_Greatest_Element_on_Right_Side = new Replace_Elements_with_Greatest_Element_on_Right_Side();
            var actual = replace_Elements_with_Greatest_Element_on_Right_Side.ReplaceElements2(arr);

            Assert.Equal(expected, actual);
        }
    }
}
