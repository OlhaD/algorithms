using System;
using System.Collections.Generic;

namespace Trees
{
    public class BinarySearchTree : IBinaryTree
    {
        public TreeNode Root { get; set; }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(int root)
        {
            Root = new TreeNode(root);
        }

        public void Add(int value)
        {
            Root = Add(Root, value);
        }

        private TreeNode Add(TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                if(Root == null) Root = root;
                return root;
            }

            if (root.val < value)
            {
                root.right = Add(root.right, value);
            }
            else if (root.val > value)
            {
                root.left = Add(root.left, value);
            }

            return root;
        }

        public void Add_Iterative(int value)
        {
            var current = Root;
            var previous = current;

            while (current != null)
            {
                if(current.val > value)
                {
                    previous = current;
                    current = current.left;
                }
                else
                {
                    previous = current;
                    current = current.right;
                }
            }

            if(previous.val > value)
            {
                previous.right = new TreeNode(value);
            }
            else
            {
                previous.left = new TreeNode(value);
            }
        }

        public void Remove(int value)
        {
            var parent = FindParent(Root, value);
            var nodeToDelete = Find(Root, value);
            // leaf node
            if (nodeToDelete.left == null && nodeToDelete.right == null)
            {
                if (parent.left != null && parent.left.val == value)
                {
                    parent.left = null;
                }
                else if (parent.right != null && parent.right.val == value)
                {
                    parent.right = null;
                }

                return;
            }

            // one child
            if (nodeToDelete.left == null && nodeToDelete.right != null)
            {
                parent.right = nodeToDelete.right;
                nodeToDelete.right = null;
            }
            else if (nodeToDelete.right == null && nodeToDelete.left != null)
            {
                parent.left = nodeToDelete.left;
                nodeToDelete.left = null;
            }
            else
            {
                // two children
                TreeNode nodeToSwap = null;
                TreeNode nodeToSwapParent = null;
                if (nodeToDelete.right != null)
                {
                    // find smalest on the right
                    var current = nodeToDelete.right;
                    nodeToSwapParent = nodeToDelete;
                    while (current.left != null)
                    {
                        nodeToSwapParent = current;
                        current = current.left;
                    }
                    nodeToSwap = current;
                }
                else
                {
                    // find biggest on the left
                    var current = nodeToDelete.left;
                    nodeToSwapParent = nodeToDelete;
                    while (current.right != null)
                    {
                        nodeToSwapParent = current;
                        current = current.right;
                    }
                    nodeToSwap = current;
                }

                if (parent.val > nodeToSwap.val)
                {
                    parent.left.val = nodeToSwap.val;
                }
                else
                {
                    parent.right.val = nodeToSwap.val;
                }

                if (nodeToSwapParent.left != null && nodeToSwapParent.left.val == nodeToSwap.val)
                {
                    nodeToSwapParent.left = null;
                }
                if (nodeToSwapParent.right != null && nodeToSwapParent.right.val == nodeToSwap.val)
                {
                    nodeToSwapParent.right = null;
                }
            }
        }

        public TreeNode Find(TreeNode root, int value)
        {
            if (root == null)
            {
                return root;
            }
            if(root.left != null && root.left.val == value)
            {
                return root.left;
            }
            if (root.right != null && root.right.val == value)
            {
                return root.right;
            }

            if (root.left.val > value)
            {
                return Find(root.left, value);
            }
            else
            {
                return Find(root.right, value);
            }
        }

        private TreeNode FindParent(TreeNode root, int value)
        {
            if (root == null || (root.left != null && root.left.val == value) ||
                (root.right != null && root.right.val == value))
            {
                return root;
            }

            if (root.left.val > value)
            {
                return FindParent(root.left, value);
            }
            else
            {
                return FindParent(root.right, value);
            }
        }

        public void TraverseInOrder(TreeNode root, Action<int> print)
        {
            if(root == null)
            {
                return;
            }

            TraverseInOrder(root.left, print);
            print(root.val);
            TraverseInOrder(root.right, print);
        }

        public void TraversePreOrder(TreeNode root, Action<int> print)
        {
            if(root == null)
            {
                return;
            }

            print(root.val);
            TraversePreOrder(root.left, print);
            TraversePreOrder(root.right, print);
        }

        public void TraversePostOrder(TreeNode root, Action<int> print)
        {
            if(root == null)
            {
                return;
            }

            TraversePostOrder(root.left, print);
            TraversePostOrder(root.right, print);

            print(root.val);
        }

        // O(n)
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

        //  O(n^2) in worst case.
        public void TraverseBreadthFirstWithoutQueue(TreeNode root, Action<int> print)
        {
            var height = GetHeight(root);
            for(int i = 1; i <= height; i++)
            {
                PrintPerLevel(root, i, print);
            }
        }

        private int GetHeight(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            var leftHeight = GetHeight(root.left);
            var rightHeight = GetHeight(root.right);

            return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
        }

        private void PrintPerLevel(TreeNode root, int level, Action<int> print)
        {
            if(root == null)
            {
                return;
            }
            if(level == 1)
            {
                print(root.val);
            }
            else if(level > 1)
            {
                PrintPerLevel(root.left, level - 1, print);
                PrintPerLevel(root.right, level - 1, print);
            }
        }

        public void TraverseInOrderIterative(TreeNode root, Action<int> print)
        {
            var stack = new Stack<TreeNode>();
            var current = root;

            while(stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                var node = stack.Pop();
                print(node.val);
                current = node.right;
            }
        }

        // not the best way
        public List<int> TraversePostOrderIterative(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var resultStack = new Stack<int>();
            stack.Push(root);
            var current = root;

            while (stack.Count > 0)
            {
                current = stack.Pop();
                resultStack.Push(current.val);

                if (current.left != null)
                {
                    stack.Push(current.left);
                }

                if (current.right != null)
                {
                    stack.Push(current.right);
                }
            }

            foreach (var el in resultStack)
            {
                result.Add(el);
            }

            return result;
        }
    }
}
