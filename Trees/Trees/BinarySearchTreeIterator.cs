using System;
using System.Collections.Generic;

namespace Trees
{
    public class BinarySearchTreeIterator : BinarySearchTree
    {
        private readonly Queue<int> _nodes;

        public BinarySearchTreeIterator(TreeNode root)
        {
            _nodes = new Queue<int>();
            Root = root;

            InOrderTraverse(root, _nodes);
        }

        private void InOrderTraverse(TreeNode root, Queue<int> nodes)
        {
            if(root == null)
            {
                return;
            }

            InOrderTraverse(root.left, nodes);
            nodes.Enqueue(root.val);
            InOrderTraverse(root.right, nodes);
        }

        public bool HasNext()
        {
            return _nodes.Count > 0;
        }

        public int Next()
        {
            return _nodes.Dequeue();
        }
    }
}
