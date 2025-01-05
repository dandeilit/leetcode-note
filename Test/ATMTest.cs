using Code;

namespace Test
{
    public class ATMTest
    {
        public abstract class Event
        {
        }

        public class DepositEvent : Event
        {
            public int[] BanknotesCount { get; set; }
        }

        public class WithdrawEvent : Event
        {
            public int Amount { get; set; }
        }

        public static TheoryData<Event[], int[][]> TestData => new TheoryData<Event[], int[][]>
        {
            {
                new Event[]
                {
                    new DepositEvent { BanknotesCount = [0, 0, 1, 2, 1] },
                    new WithdrawEvent { Amount = 600 },
                    new DepositEvent { BanknotesCount = [0, 1, 0, 1, 1] },
                    new WithdrawEvent { Amount = 600 },
                    new WithdrawEvent { Amount = 550 },
                },
                [null, [0, 0, 1, 0, 1], null, [-1], [0, 1, 0, 0, 1]]
            },
        };

        private int[][] GetActual(ATM atm, Event[] events)
        {
            var actual = new Queue<int[]>();
            foreach (var e in events)
            {
                if (e is DepositEvent depositEvent)
                {
                    atm.Deposit(depositEvent.BanknotesCount);
                    actual.Enqueue(null);
                }
                else if (e is WithdrawEvent withdrawEvent)
                {
                    actual.Enqueue(atm.Withdraw(withdrawEvent.Amount));
                }
            }
            return actual.ToArray();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(Event[] events, int[][] expected)
        {
            var atm = new ATM();
            var actual = GetActual(atm, events);
            Assert.Equal(expected, actual);
        }
    }
}
