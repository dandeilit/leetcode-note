namespace Code
{
    /// <summary>
    /// 2241. Design an ATM Machine
    /// 
    /// There is an ATM machine that stores banknotes of 5 denominations: 20, 50, 100, 200, and 500 dollars. Initially the ATM is empty. The user can use the machine to deposit or withdraw any amount of money.
    /// 有一台 ATM 机，存放 5 面额的钞票： 20 、 50 、 100 、 200 、和 500 美元。最初，ATM 机是空的。用户可以使用该机器存入或提取任意金额的资金。
    /// 
    /// When withdrawing, the machine prioritizes using banknotes of larger values.
    /// 取款时，机器优先使用面值较大的纸币。
    /// 
    /// For example, if you want to withdraw $300 and there are 2 $50 banknotes, 1 $100 banknote, and 1 $200 banknote, then the machine will use the $100 and $200 banknotes.
    /// 例如，如果您要提取 $300 ，并且有 2 $50 钞票， 1 $100 钞票，和 1 $200 钞票，则机器将使用 $100 和 $200 钞票。
    /// 
    /// However, if you try to withdraw $600 and there are 3 $200 banknotes and 1 $500 banknote, then the withdraw request will be rejected because the machine will first try to use the $500 banknote and then be unable to use banknotes to complete the remaining $100. Note that the machine is not allowed to use the $200 banknotes instead of the $500 banknote.
    /// 但是，如果您尝试提取 $600 并且有 3 $200 钞票和 1 $500 钞票，则提现请求将被拒绝，因为机器将首先尝试使用 $500 钞票，然后无法使用钞票完成剩余的 $100 。请注意，机器不允许使用 $200 纸币代替 $500 纸币。
    /// 
    /// Implement the ATM class:
    /// 实现ATM类：
    /// 
    /// ATM() Initializes the ATM object.
    /// ATM() 初始化 ATM 对象。
    /// 
    /// void deposit(int[] banknotesCount) Deposits new banknotes in the order $20, $50, $100, $200, and $500.
    /// void deposit(int[] banknotesCount) 按照 $20 、 $50 、 $100 、 $200 和 $500
    /// 
    /// int[] withdraw(int amount) Returns an array of length 5 of the number of banknotes that will be handed to the user in the order $20, $50, $100, $200, and $500, and update the number of banknotes in the ATM after withdrawing. Returns [-1] if it is not possible (do not withdraw any banknotes in this case).
    /// int[] withdraw(int amount) 返回一个长度为 5 的数组，其中包含将按照 $20 、 $50 、 $50 的顺序交给用户的钞票数量。 $100 、 $200 和 $500 ，并在取款后更新 ATM 中的钞票数量。如果不可能，则返回 [-1] （在这种情况下不要提取任何纸币）。
    /// 
    /// </summary>
    public class ATM
    {
        int[] _banknotes = new int[] { 20, 50, 100, 200, 500 };
        int[] _banknotesCount = new int[5];

        public ATM()
        {

        }

        public void Deposit(int[] banknotesCount)
        {
            for (int i = 0; i < 5; i++)
            {
                _banknotesCount[i] += banknotesCount[i];
            }
        }

        public int[] Withdraw(int amount)
        {
            var remaining = amount;
            var result = new int[5];
            for (int i = 4; i >= 0; i--)
            {
                var banknote = _banknotes[i];
                if (remaining >= banknote)
                {
                    var count = remaining / banknote;
                    result[i] = Math.Min(count, _banknotesCount[i]);

                    remaining -= result[i] * banknote;
                }
            }

            if (remaining > 0)
            {
                return [-1];
            }

            for (int i = 4; i >= 0; i--)
            {
                _banknotesCount[i] -= result[i];
            }

            return result;
        }
    }
}
