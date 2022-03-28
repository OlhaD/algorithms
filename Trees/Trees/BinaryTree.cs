using System;
using System.Collections.Generic;

namespace Trees
{
    public class BinaryTree : IBinaryTree
    {
        public TreeNode Root { get; private set; }

        public BinaryTree(int root)
        {
            Root = new TreeNode(root);
        }

        public int GetLowerCommonAncestor(TreeNode root, int first, int second)
        {
            var dict = FillDictWithNodes(root, root, new Dictionary<int, int>());

            if(!dict.ContainsKey(first) || !dict.ContainsKey(second))
            {
                return -1;
            }

            var leftParrent = first;
            var rightParrent = second;
            do
            {
                rightParrent = second;
                while (rightParrent != root.val)
                {
                    if (leftParrent == rightParrent)
                    {
                        return leftParrent;
                    }

                    rightParrent = dict[rightParrent];
                }

                if (leftParrent == rightParrent)
                {
                    return leftParrent;
                }

                leftParrent = dict[leftParrent];
            }
            while (leftParrent != root.val);

            return leftParrent == rightParrent  ? leftParrent : - 1;
        }

        private Dictionary<int, int> FillDictWithNodes(TreeNode root, TreeNode parent, Dictionary<int, int> dict)
        {
            if(root == null)
            {
                return dict;
            }

            FillDictWithNodes(root.left, root, dict);

            if (dict.ContainsKey(root.val))
            {
                throw new DivideByZeroException();
            }
            dict.Add(root.val, parent.val);

            FillDictWithNodes(root.right, root, dict);

            return dict;
        }

        public void Add(int value)
        {
            throw new NotImplementedException();
        }

        public void Remove(int value)
        {
            throw new NotImplementedException();
        }

        public TreeNode Find(TreeNode root, int value)
        {
            throw new NotImplementedException();
        }

        public void TraverseInOrder(TreeNode root, Action<int> print)
        {
            throw new NotImplementedException();
        }

        public void TraversePreOrder(TreeNode root, Action<int> print)
        {
            throw new NotImplementedException();
        }

        public void TraversePostOrder(TreeNode root, Action<int> print)
        {
            throw new NotImplementedException();
        }

        public void TraverseBreadthFirst(TreeNode root, Action<int> print)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                print(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        public void TraverseBreadthFirstWithoutQueue(TreeNode root, Action<int> print)
        {
            throw new NotImplementedException();
        }
    }
}
