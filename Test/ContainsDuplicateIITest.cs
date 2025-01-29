using Code;

namespace Test
{
    public class ContainsDuplicateIITest
    {
        public static TheoryData<int[], int, bool> TestData => new TheoryData<int[], int, bool>()
        {
            { [1,2,3,1],3,true},
            { [1,0,1,1],1,true},
            { [1,2,3,1,2,3],2,false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, bool expected)
        {
            var containsDuplicateII = new ContainsDuplicateII();
            var actual = containsDuplicateII.ContainsNearbyDuplicate(nums, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int k, bool expected)
        {
            var containsDuplicateII = new ContainsDuplicateII();
            var actual = containsDuplicateII.ContainsNearbyDuplicate2(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
