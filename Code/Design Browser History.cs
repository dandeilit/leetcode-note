namespace Code
{
    /// <summary>
    /// 1472. Design Browser History
    /// 
    /// You have a browser of one tab where you start on the homepage and you can visit another url, get back in the history number of steps or move forward in the history number of steps.
    /// 有一个单标签浏览器，从主页开始，然后可以访问另一个 url，返回历史记录中的步骤数或按照历史记录中的步骤数前进。
    /// 
    /// Implement the BrowserHistory class:
    /// 实现 BrowserHistory 类：
    /// 
    /// * BrowserHistory(string homepage) Initializes the object with the homepage of the browser.
    /// * BrowserHistory(string homepage) 使用浏览器的主页初始化对象。
    /// 
    /// * void visit(string url) Visits url from the current page. It clears up all the forward history.
    /// * void visit(string url) 从当前页面访问 url。它会清除所有前进历史记录。
    /// 
    /// * string back(int steps) Move steps back in history. If you can only return x steps in the history and steps > x, you will return only x steps. Return the current url after moving back in history at most steps.
    /// * string back(int steps) 在历史记录中向后移动步骤。如果您只能在历史记录中返回 x 步骤并且步骤 > x，则将仅返回 x 步骤。在历史记录中向后移动最多步骤后返回当前 url。
    /// 
    /// * string forward(int steps) Move steps forward in history. If you can only forward x steps in the history and steps > x, you will forward only x steps. Return the current url after forwarding in history at most steps.
    /// * string forward(int steps) 在历史记录中向前移动步骤。如果您只能在历史记录中前进 x 步骤并且步骤 > x，则将仅前进 x 步骤。在历史记录中前进最多步骤后返回当前 url。
    /// 
    /// </summary>
    public class Design_Browser_History
    {
        public class BrowserHistory
        {
            IList<string> history;
            int index;

            public BrowserHistory(string homepage)
            {
                history = new List<string>() { homepage };
                index = 0;
            }

            public void Visit(string url)
            {
                index++;
                for (var i = history.Count - 1; i >= index; i--)
                {
                    history.RemoveAt(i);
                }
                history.Add(url);
            }

            public string Back(int steps)
            {
                index -= steps;
                if (index < 0) index = 0;

                return history[index];
            }

            public string Forward(int steps)
            {
                index += steps;
                if (index >= history.Count) index = history.Count - 1;
                return history[index];
            }
        }
    }
}
