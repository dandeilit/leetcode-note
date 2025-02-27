using System.Text;

namespace Code
{
    /// <summary>
    /// 2296. Design a Text Editor
    /// 
    /// Design a text editor with a cursor that can do the following:
    /// 设计一个带有光标的文本编辑器，它可以执行以下操作：
    /// 
    /// * Add text to where the cursor is.
    /// * 在光标所在的位置添加文本。
    /// 
    /// * Delete text from where the cursor is (simulating the backspace key).
    /// * 从光标所在的位置删除文本（模拟退格键）。
    /// 
    /// * Move the cursor either left or right.
    /// * 将光标向左或向右移动。
    /// 
    /// When deleting text, only characters to the left of the cursor will be deleted. The cursor will also remain within the actual text and cannot be moved beyond it. More formally, we have that 0 <= cursor.position <= currentText.length always holds.
    /// 删除文本时，只会删除光标左侧的字符。光标还将保留在实际文本内，不能移到文本之外。更正式地说，我们始终认为 0 <= cursor.position <= currentText.length。
    /// 
    /// Implement the TextEditor class:
    /// 实现 TextEditor 类：
    /// 
    /// * TextEditor() Initializes the object with empty text.
    /// * TextEditor() 使用空文本初始化对象。
    /// 
    /// * void addText(string text) Appends text to where the cursor is. The cursor ends to the right of text.
    /// * void addText(string text) 将文本附加到光标所在的位置。光标在文本右侧结束。
    /// 
    /// * int deleteText(int k) Deletes k characters to the left of the cursor. Returns the number of characters actually deleted.
    /// * int deleteText(int k) 删除光标左侧的 k 个字符。返回实际删除的字符数。
    /// 
    /// * string cursorLeft(int k) Moves the cursor to the left k times. Returns the last min(10, len) characters to the left of the cursor, where len is the number of characters to the left of the cursor.
    /// * string cursorLeft(int k) 将光标向左移动 k 次。返回光标左侧最后 min(10, len) 个字符，其中 len 是光标左侧的字符数。
    /// 
    /// * string cursorRight(int k) Moves the cursor to the right k times. Returns the last min(10, len) characters to the left of the cursor, where len is the number of characters to the left of the cursor.
    /// * string cursorRight(int k) 将光标向右移动 k 次。返回光标左侧最后 min(10, len) 个字符，其中 len 是光标左侧的字符数。
    /// 
    /// Follow-up: Could you find a solution with time complexity of O(k) per call?
    /// 进阶：您能找到每次调用时间复杂度为 O(k) 的解决方案吗？
    /// 
    /// </summary>
    public class Design_a_Text_Editor
    {
        /// <summary>
        /// StringBuilder 超时
        /// </summary>
        public class TextEditor
        {
            StringBuilder text;
            int cursor;

            public TextEditor()
            {
                text = new StringBuilder();
                cursor = 0;
            }

            public void AddText(string text)
            {
                this.text.Insert(cursor, text);
                cursor += text.Length;
            }

            public int DeleteText(int k)
            {
                if (cursor - k < 0)
                {
                    k = cursor;
                    cursor = 0;
                }
                else
                {
                    cursor -= k;
                }
                text.Remove(cursor, k);
                return k;
            }

            public string CursorLeft(int k)
            {
                if (cursor - k < 0)
                {
                    cursor = 0;
                }
                else
                {
                    cursor -= k;
                }

                var len = Math.Min(10, cursor);
                return text.ToString().Substring(cursor - len, len);
            }

            public string CursorRight(int k)
            {
                if (cursor + k > text.Length)
                {
                    cursor = text.Length;
                }
                else
                {
                    cursor += k;
                }

                var len = Math.Min(10, cursor);
                return text.ToString().Substring(cursor - len, len);
            }
        }

        /// <summary>
        /// 双向链表
        /// </summary>
        public class TextEditor2
        {
            private Node cursor;

            public TextEditor2()
            {
                cursor = new Node('\0');
            }

            public void AddText(string text)
            {
                foreach (char c in text)
                {
                    cursor.Insert(c);
                }
            }

            public int DeleteText(int k)
            {
                int count = 0;
                while (k > 0 && cursor.Prev != null)
                {
                    cursor.Remove();
                    k--;
                    count++;
                }
                return count;
            }

            public string CursorLeft(int k)
            {
                while (k > 0 && cursor.Prev != null)
                {
                    cursor = cursor.Prev;
                    k--;
                }
                Node head = cursor;
                for (int i = 0; i < 10 && head.Prev != null; i++)
                {
                    head = head.Prev;
                }
                return head.Range(cursor);
            }

            public string CursorRight(int k)
            {
                while (k > 0 && cursor.Next != null)
                {
                    cursor = cursor.Next;
                    k--;
                }
                Node head = cursor;
                for (int i = 0; i < 10 && head.Prev != null; i++)
                {
                    head = head.Prev;
                }
                return head.Range(cursor);
            }
        }

        public class Node
        {
            public char Val;
            public Node Prev, Next;

            public Node(char val)
            {
                Val = val;
            }

            public void Insert(char val)
            {
                Node node = new Node(val);
                node.Next = this;
                node.Prev = this.Prev;
                if (this.Prev != null)
                {
                    this.Prev.Next = node;
                }
                this.Prev = node;
            }

            public void Remove()
            {
                Node node = this.Prev;
                this.Prev = node.Prev;
                if (node.Prev != null)
                {
                    node.Prev.Next = this;
                }
            }

            public string Range(Node end)
            {
                StringBuilder sb = new StringBuilder();
                Node node = this;
                while (node != end)
                {
                    sb.Append(node.Val);
                    node = node.Next;
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 栈
        /// 分别使用两个栈 left 和 right 保存光标左侧和右侧的文本。
        /// </summary>
        public class TextEditor3
        {
            private LinkedList<char> left;
            private LinkedList<char> right;

            public TextEditor3()
            {
                left = new LinkedList<char>();
                right = new LinkedList<char>();
            }

            public void AddText(string text)
            {
                foreach (char c in text)
                {
                    left.AddLast(c);
                }
            }

            public int DeleteText(int k)
            {
                int count = 0;
                while (k > 0 && left.Count > 0)
                {
                    left.RemoveLast();
                    count++;
                    k--;
                }
                return count;
            }

            public string CursorLeft(int k)
            {
                int move = Math.Min(k, left.Count);
                for (int i = 0; i < move; i++)
                {
                    right.AddLast(left.Last.Value);
                    left.RemoveLast();
                }
                return GetLeftText();
            }

            public string CursorRight(int k)
            {
                int move = Math.Min(k, right.Count);
                for (int i = 0; i < move; i++)
                {
                    left.AddLast(right.Last.Value);
                    right.RemoveLast();
                }
                return GetLeftText();
            }

            private string GetLeftText()
            {
                var text = new char[Math.Min(10, left.Count)];
                var current = left.Last;
                int index = text.Length - 1;
                while (current != null && index >= 0)
                {
                    text[index--] = current.Value;
                    current = current.Previous;
                }
                return new string(text);
            }
        }
    }
}
