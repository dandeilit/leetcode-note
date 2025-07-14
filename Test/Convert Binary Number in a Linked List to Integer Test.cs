using Code;
using static Code.Convert_Binary_Number_in_a_Linked_List_to_Integer;

namespace Test
{
    public class Convert_Binary_Number_in_a_Linked_List_to_Integer_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [1,0,1],5},
            { [0],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] array, int expected)
        {
            var convert_Binary_Number_in_a_Linked_List_to_Integer = new Convert_Binary_Number_in_a_Linked_List_to_Integer();

            var head = new ListNode(array[array.Length - 1]);
            for (var i = array.Length - 2; i >= 0; i--)
            {
                head = new ListNode(array[i], head);
            }

            var actual = convert_Binary_Number_in_a_Linked_List_to_Integer.GetDecimalValue(head);
            Assert.Equal(expected, actual);
        }
    }
}
