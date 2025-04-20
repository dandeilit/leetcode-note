using Code;

namespace Test
{
    public class Rabbits_in_Forest_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int> {
            { [1,1,2],5},
            { [10,10,10],11},
            { [1,0,1,0,0],5},
            { [0,0,1,1,1],6},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] answers, int expected)
        {
            var rabbits_in_Forest = new Rabbits_in_Forest();
            var actual = rabbits_in_Forest.NumRabbits(answers);
            Assert.Equal(expected, actual);
        }
    }
}
