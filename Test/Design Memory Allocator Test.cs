using static Code.Design_Memory_Allocator;

namespace Test
{
    public class Design_Memory_Allocator_Test
    {
        public static TheoryData<int, string[], int[][], int[]> TestData => new TheoryData<int, string[], int[][], int[]>()
        {
            { 10,["allocate", "allocate", "allocate", "freeMemory", "allocate", "allocate", "allocate", "freeMemory", "allocate", "freeMemory"],[[1, 1], [1, 2], [1, 3], [2], [3, 4], [1, 1], [1, 1], [1], [10, 2], [7]],[0, 1, 2, 1, 3, 1, 6, 3, -1, 0]},
            { 50,["allocate","allocate","allocate","allocate","freeMemory","freeMemory","freeMemory","allocate","allocate","allocate","allocate","freeMemory","freeMemory","freeMemory","freeMemory","freeMemory","freeMemory","freeMemory","allocate","freeMemory","freeMemory","allocate","freeMemory","allocate","allocate","freeMemory","freeMemory","freeMemory","allocate","allocate","allocate","allocate","freeMemory","allocate","freeMemory","freeMemory","allocate","allocate","allocate","allocate","allocate","allocate","allocate","freeMemory","freeMemory","freeMemory","freeMemory"],[[12,6],[28,16],[17,23],[50,23],[6],[10],[10],[16,8],[17,41],[44,27],[12,45],[33],[8],[16],[23],[23],[23],[29],[38,32],[29],[6],[40,11],[16],[22,33],[27,5],[3],[10],[29],[16,14],[46,47],[48,9],[36,17],[33],[14,24],[16],[8],[2,50],[31,36],[17,45],[46,31],[2,6],[16,2],[39,30],[33],[45],[30],[27]],[0,12,-1,-1,12,0,0,-1,-1,-1,0,0,0,28,0,0,0,0,12,0,0,-1,0,-1,-1,0,0,0,-1,-1,-1,-1,0,-1,0,0,-1,-1,-1,-1,-1,-1,-1,0,12,0,0]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, string[] commands, int[][] paramters, int[] expected)
        {
            var actual = new int[commands.Length];
            Allocator obj = new Allocator(n);

            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "allocate":
                        actual[i] = obj.Allocate(paramters[i][0], paramters[i][1]);
                        break;
                    case "freeMemory":
                        actual[i] = obj.FreeMemory(paramters[i][0]);
                        break;
                    default:
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int n, string[] commands, int[][] paramters, int[] expected)
        {
            var actual = new int[commands.Length];
            Allocator2 obj = new Allocator2(n);

            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "allocate":
                        actual[i] = obj.Allocate(paramters[i][0], paramters[i][1]);
                        break;
                    case "freeMemory":
                        actual[i] = obj.FreeMemory(paramters[i][0]);
                        break;
                    default:
                        break;
                }
            }

            Assert.Equal(expected, actual);
        }
    }
}
