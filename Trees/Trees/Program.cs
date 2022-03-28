using System;
using System.Collections.Generic;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTreeTasks1(1);
            // tree.Root.Left = new Node(10);
            // tree.Root.Right = new Node(20);

            // tree.Root.Left.Left = new Node(8);
            // //tree.Root.Left.Left.Left = new Node(6);
            //// tree.Root.Left.Left.Left.Left = new Node(3);
            // tree.Root.Left.Right = new Node(12);

            // tree.Root.Right.Left = new Node(18);
            // tree.Root.Right.Right = new Node(25);
            
            tree.Root.left = new TreeNode(3);
            tree.Root.right = new TreeNode(2);
            tree.Root.left.left = new TreeNode(5);

            var tree1 = new BinaryTreeTasks1(2);
            tree1.Root.left = new TreeNode(1);
            tree1.Root.left.right = new TreeNode(4);
            tree1.Root.right = new TreeNode(3);
            tree1.Root.right.right = new TreeNode(7);

            var a = tree.MergeTrees(tree.Root, tree1.Root);
            var b = a;
        }
    }
}
