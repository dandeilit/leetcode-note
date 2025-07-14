namespace Code
{
    /// <summary>
    /// 1290. Convert Binary Number in a Linked List to Integer
    /// 1290. 二进制链表转整数
    /// 
    /// Given head which is a reference node to a singly-linked list. The value of each node in the linked list is either 0 or 1. The linked list holds the binary representation of a number.
    /// 给你一个单链表的引用结点 head。链表中每个结点的值不是 0 就是 1。已知此链表是一个整数数字的二进制表示形式。
    /// 
    /// Return the decimal value of the number in the linked list.
    /// 请你返回该链表所表示数字的 十进制值 。
    /// 
    /// The most significant bit is at the head of the linked list.
    /// 最高位 在链表的头部。
    /// 
    /// </summary>
    public class Convert_Binary_Number_in_a_Linked_List_to_Integer
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public int GetDecimalValue(ListNode head)
        {
            var val = head.val;
            while (head.next != null)
            {
                head = head.next;
                val = val * 2 + head.val;
            }
            return val;
        }
    }
}
