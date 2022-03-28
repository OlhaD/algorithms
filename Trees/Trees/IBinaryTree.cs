using System;

namespace Trees
{
    public interface IBinaryTree
    {
        TreeNode Root { get; }

        void Add(int value);

        void Remove(int value);

        TreeNode Find(TreeNode root, int value);

        void TraverseInOrder(TreeNode root, Action<int> print);

        void TraversePreOrder(TreeNode root, Action<int> print);

        void TraversePostOrder(TreeNode root, Action<int> print);

        void TraverseBreadthFirst(TreeNode root, Action<int> print);

        void TraverseBreadthFirstWithoutQueue(TreeNode root, Action<int> print);
    }
}
