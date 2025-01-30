using Code;

namespace Test
{
    public class Intersection_of_Two_Arrays_II_Test
    {
        public static TheoryData<int[], int[], int[]> TestData => new TheoryData<int[], int[], int[]>()
        {
            { [1,2,2,1],[2,2],[2,2]},
            { [4,9,5],[9,4,9,8,4],[4,9]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums1, int[] nums2, int[] expected)
        {
            var intersection_of_Two_Arrays_II = new Intersection_of_Two_Arrays_II();
            var actual = intersection_of_Two_Arrays_II.Intersect(nums1, nums2);

            Array.Sort(expected);
            Array.Sort(actual);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums1, int[] nums2, int[] expected)
        {
            var intersection_of_Two_Arrays_II = new Intersection_of_Two_Arrays_II();
            var actual = intersection_of_Two_Arrays_II.Intersect2(nums1, nums2);

            Array.Sort(expected);
            Array.Sort(actual);

            Assert.Equal(expected, actual);
        }
    }
}
