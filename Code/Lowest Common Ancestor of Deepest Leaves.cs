namespace Code
{
    /// <summary>
    /// 1123. Lowest Common Ancestor of Deepest Leaves
    /// 1123. 最深叶节点的最近公共祖先
    /// 
    /// Given the root of a binary tree, return the lowest common ancestor of its deepest leaves.
    /// 给你一个有根节点 root 的二叉树，返回它 最深的叶节点的最近公共祖先 。
    /// 
    /// Recall that:
    /// 回想一下：
    /// 
    /// * The node of a binary tree is a leaf if and only if it has no children
    /// * 叶节点 是二叉树中没有子节点的节点
    /// 
    /// * The depth of the root of the tree is 0. if the depth of a node is d, the depth of each of its children is d + 1.
    /// * 树的根节点的 深度 为 0，如果某一节点的深度为 d，那它的子节点的深度就是 d+1
    /// 
    /// * The lowest common ancestor of a set S of nodes, is the node A with the largest depth such that every node in S is in the subtree with root A.
    /// * 如果我们假定 A 是一组节点 S 的 最近公共祖先，S 中的每个节点都在以 A 为根节点的子树中，且 A 的深度达到此条件下可能的最大值。
    /// 
    /// </summary>
    public class Lowest_Common_Ancestor_of_Deepest_Leaves
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            return f(root).Item1;
        }

        private Tuple<TreeNode, int> f(TreeNode root)
        {
            if (root == null)
            {
                return new Tuple<TreeNode, int>(root, 0);
            }

            Tuple<TreeNode, int> left = f(root.left);
            Tuple<TreeNode, int> right = f(root.right);

            if (left.Item2 > right.Item2)
            {
                return new Tuple<TreeNode, int>(left.Item1, left.Item2 + 1);
            }
            if (left.Item2 < right.Item2)
            {
                return new Tuple<TreeNode, int>(right.Item1, right.Item2 + 1);
            }
            return new Tuple<TreeNode, int>(root, left.Item2 + 1);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static class TreeNodeExtension
    {
        private static TreeNode ToNode(this int? val)
        {
            if (val == null) return null;
            return new TreeNode(val.Value);
        }

        public static TreeNode ToTree(this int?[] arr)
        {
            if (arr.Length <= 0 || arr[0] == null)
            {
                return null;
            }

            TreeNode root = arr[0].ToNode();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int index = 1;
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null) continue;
                if (index < arr.Length)
                {
                    node.left = arr[index++].ToNode();
                    queue.Enqueue(node.left);
                }
                if (index < arr.Length)
                {
                    node.right = arr[index++].ToNode();
                    queue.Enqueue(node.right);
                }
            }
            return root;
        }

        public static int?[] ToArray(this TreeNode root)
        {
            List<int?> arr = new List<int?>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null) continue;

                arr.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return arr.ToArray();
        }
    }
}
